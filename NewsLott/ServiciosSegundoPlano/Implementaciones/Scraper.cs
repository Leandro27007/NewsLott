using HtmlAgilityPack;
using NewsLott.DAL.Repositorio.Interfaces;
using NewsLott.Entidades;
using NewsLott.ServiciosSegundoPlano.Interfaces;
using System.Globalization;
using utilidades;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class Scraper : IScraper
    {
        private IScrapeableWeb _webParaRaspar;
        private IResultadoLoteriaRepositorio _resultadoLoteriaRepositorio;
        private ILoteriaRepositorio _loteriaRepositorio;

        public Scraper(IScrapeableWeb webParaRaspar, IResultadoLoteriaRepositorio resultadoLoteriaRepositorio, ILoteriaRepositorio loteriaRepositorio)
        {
            this._webParaRaspar = webParaRaspar;
            this._resultadoLoteriaRepositorio = resultadoLoteriaRepositorio;
            this._loteriaRepositorio = loteriaRepositorio;
        }

        public async Task RasparWeb()
        {
            HtmlDocument paginaHtml = await this.ObtenerWebHtml();

            List<HtmlNode> nodosContenedoresDeResultados = paginaHtml.DocumentNode.SelectNodes(_webParaRaspar.XPathElementoContenedorPadre).ToList();
            List<ResultadoDeLoteria> listaObjResultadoDeLoteria = new();


            //AGRUPAR ESTE PROCESO EN UN TRY CATCH Y HACER QUE EL ERROR SE ALMACENE EN LOGS

            foreach (var item in nodosContenedoresDeResultados)
            {
                string idLoteria = item.SelectNodes("." + _webParaRaspar.XPathElementoNombreLoteriaResultadoHijo).First().InnerText;
                string fechaResultado = item.SelectNodes("." + _webParaRaspar.XPathElementoFechaResultadoHijo).First().InnerText.Trim();
                string numerosPremiados = "";

                //Formatear el idLoteria 
                idLoteria = Utils.ReemplazarEspaciosPorGuionBajo(idLoteria);
                idLoteria = idLoteria.ToLower();
                idLoteria = Utils.RemoverAcentosDiacriticos(idLoteria);
                //------------------

                string idResultado = idLoteria + "_" + fechaResultado;

                var existeElResultado = await _resultadoLoteriaRepositorio.ObtenerAsync(r => r.IdResultadoDeLoteria == idResultado);
                var existeLaLoteria = await _loteriaRepositorio.ObtenerAsync(l => l.IdLoteria == idLoteria);

                if (existeElResultado == null && existeLaLoteria != null)
                {
                    //Tambien me trae una barra invertida y una n en el text
                    //Error ACA, me trae todos los numeros, creo que el error esta en el Xpath que tiene un div con doble // barra 

                    var nodosNumerosPremiados = item.SelectNodes("." + _webParaRaspar.XPathElementoNumeroResultadoHijo).ToList();

                    //En alguna paginas el Loto Pool de la compania Real y el de la Leidsa tienen el mismo nombre pero se diferencian en
                    //la cantidad de numeros, aca verifico si el idLoteria es igual al de $"loto_pool_{fechaResultado}" y tiene 4 numeros
                    //entonces si es verdadero cambio el id a "real_loto_pool_{fechaResultado}" para evitar conflictos de PK.
                    if (idResultado == $"loto_pool_{fechaResultado}" && nodosNumerosPremiados.Count == 4)
                    {

                        idResultado = $"real_loto_pool_{fechaResultado}";
                        idLoteria = "real_loto_pool";

                        //Pregunto si no existe una loteria con ese id o si existe ya un registro (resultado) con ese id.
                        if (await _loteriaRepositorio.ObtenerAsync(l => l.IdLoteria == idLoteria) == null || await _resultadoLoteriaRepositorio.ObtenerAsync(r => r.IdResultadoDeLoteria == idResultado) != null)
                            continue;

                    }
                    //---------------------------------

                    foreach (var i in nodosNumerosPremiados)
                    {
                        numerosPremiados += $"{i.InnerText.Trim()}-";

                    }

                    listaObjResultadoDeLoteria.Add(new()
                    {
                        IdResultadoDeLoteria = idResultado,
                        NumerosPremiados = numerosPremiados,
                        FechaResultado = DateTime.ParseExact(fechaResultado, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        IdLoteria = idLoteria
                    });

                }
                else
                {
                    continue;
                }
            }


            try
            {

                if (listaObjResultadoDeLoteria.Count > 0)
                {

                    bool exitoso = await _resultadoLoteriaRepositorio.AgregarRangoAsync(listaObjResultadoDeLoteria);
                    if (exitoso)
                        Console.WriteLine("-----ALERT------ : Se Guardaron los datos correctamente");
                    Console.WriteLine($"Objetos guardados:{listaObjResultadoDeLoteria.Count} ");

                }
                else
                {
                    Console.WriteLine("-----ALERT------ : Lista de resultados vacia, no hay data para guardar");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un Error: {ex.Message}");
            }
        }

        public async Task<HtmlDocument> ObtenerWebHtml() => await new HtmlWeb().LoadFromWebAsync(this._webParaRaspar.Url);
    }
}