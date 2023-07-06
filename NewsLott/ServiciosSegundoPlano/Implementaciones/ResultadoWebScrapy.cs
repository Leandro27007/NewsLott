using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using NewsLott.Datos;
using NewsLott.Datos.Modelos;
using NewsLott.DTOs;
using NewsLott.ServiciosSegundoPlano.Interfaces;
using ScrapySharp.Extensions;
using System.Globalization;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class ResultadoWebScrappy : IResultadoWebScrapy
    {

        //Esta url es a la que hare el web-scapy
        private const string UrlPagina = "https://loteriadominicanas.com/loteria/";
        private readonly NewsLottDbContext _db;

        public ResultadoWebScrappy(NewsLottDbContext db)
        {
            this._db = db;
        }


        public async Task<object> CargarResultadosAsync()
        {
            try
            {
                var consultaLoteria = _db.Set<Loteria>();
                var consultaResultadoQuiniela = _db.Set<ResultadoQuiniela>();

                //Obtengo los ids de las loterias, estos ids son los mismos id de las etiquetas html que tienen los resultados, en el htmlDocument cargado.
                List<string> idsLoterias = await consultaLoteria.Select(l => l.IdLoteria).ToListAsync();


                //Obtengo el documento donde estan las loterias y sus resultados
                var documentoHtml = this.ObtenerPaginaHtml(string.Empty);

                //Lista para nodos html que contienen las loterias,resultados y su fecha.
                List<HtmlNode> loteriasConResultados = new List<HtmlNode>();

                //Lleno la lista con los nodos html de loterias segun el id de mi base de dato.
                //Si no se encuentra un elemento con ese id lo dejara nulo.
                foreach (var idLoteria in idsLoterias)
                {
                    //Si no se encuenta el elemento generara una exepcion
                    var elementoLoteriaConResultado = documentoHtml.DocumentNode.CssSelect($"article.{idLoteria}").First();

                    //********HACER VALIDACIONES, PARA NO GUARDAR EN LA LISTA UN RESULTADO INCOMPLETO

                    //Créo este elemento h1 para poder almacenar el idLoteria dentro del elemento
                    //Lo necesitare mas adelante para identificarlo e introducir ese id en el objModel que va para la BD
                    var h1ConIdLoteria = documentoHtml.CreateElement("h1");
                    var textoH1 = documentoHtml.CreateTextNode(idLoteria);
                    /*textoH1.SetAttributeValue("Class", "IdLoteria");*/ //Le coloco una class al h1 para poder obtenerlo precisamente mas adelante
                    h1ConIdLoteria.AppendChild(textoH1);
                    elementoLoteriaConResultado.AppendChild(h1ConIdLoteria);

                    //Agrego el nodohtml a la lista
                    loteriasConResultados.Add(elementoLoteriaConResultado);

                }

                //Lista para los resultados, esto es lo que agregare a mi base de datos.
                List<ResultadoQuiniela> resultadoQuinielas = new List<ResultadoQuiniela>();

                foreach (var item in loteriasConResultados)
                {

                    var nodesNumero = item.CssSelect("div.data div.c").ToList();
                    string idLoteriaDesdeH1 = item.CssSelect("h1").First().InnerText;
                    string fechaResultado = item.CssSelect("span.tag").First().InnerText.ToString();


                    //Coloco la fecha en el formato correcto correspondiente a la propiedad FechaResultado del modelo ResultadoQuiniela.
                    DateTime fechaResultadoFormateada = DateTime.ParseExact(fechaResultado, "dd-MM-yyyy", CultureInfo.InvariantCulture);


                    //Valido si existe un registro en la base de datos que tenga misma fecha y Id que el resultado obtenido del documentoHtml que deseo agregar.
                    // Si existe entonces no lo agrego por que ya se supone que fue agregado, de lo contrario lo agrego.
                    if (await consultaResultadoQuiniela.FirstOrDefaultAsync(l => l.FechaResultado == fechaResultadoFormateada 
                                                                        && l.IdLoteria == idLoteriaDesdeH1) == null)
                    {
                        resultadoQuinielas.Add(new ResultadoQuiniela()
                        {
                            IdLoteria = idLoteriaDesdeH1,
                            Primera = nodesNumero.First().InnerText.Trim(),
                            Segunda = nodesNumero.Skip(1).First().InnerText.Trim(),
                            Tercera = nodesNumero.Skip(2).First().InnerText.Trim(),
                            FechaResultado = fechaResultadoFormateada
                        });

                    }
                }

                //Agrego la lista a la base de datos, marco la entidad como agregada
                await _db.Set<ResultadoQuiniela>().AddRangeAsync(resultadoQuinielas);
                //GuardoCambios. si no ocurrio ningun error al guardar cambios, retorno el numero de filas afectadas.
                int filasAfectadas = await _db.SaveChangesAsync();

                Console.WriteLine($"Filas afectadas {filasAfectadas}");
                return new CodigoEstadoDTO() { StatusCode = 200, Mensaje = $"Se agregaron {filasAfectadas} registros", ObjRespuesta = filasAfectadas };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR {ex.Message}");

                //Si ocurre un error al guardar cambios en la DB retorno un mensaje de error.
                return new CodigoEstadoDTO() { StatusCode = 500, Mensaje = $"A Ocurrido un error. ErrorMessage: {ex.Message}" };
            }
        }

        public HtmlDocument ObtenerPaginaHtml(string? nombreCarpeta)
            => new HtmlWeb().Load(UrlPagina);


    }
}

