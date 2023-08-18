using NewsLott.ServiciosSegundoPlano.Interfaces;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class PaginaWebConectate : IScrapeableWeb
    {

        /// <summary>
        /// elemento o etiquetas que contienen el nombre de la loteria en el resultado ej: <div>SoyLaLoteria<div/> 
        /// </summary>
        /// 

        public string Url { get; set; }
        public string XPathElementoNombreLoteriaResultadoHijo { get; set; }
        public string XPathElementoFechaResultadoHijo { get; set; }
        public string XPathElementoNumeroResultadoHijo { get; set; }
        /// <summary>
        /// Contenedor padre, dentro de este se encuentran elementos como: NombreLoteriaResultado, FechaResultado, NumerosResultados.
        /// </summary>
        public string XPathElementoContenedorPadre { get; set; }


        public PaginaWebConectate()
        {
            this.Url = "https://www.conectate.com.do/loterias/";
            /*
                Se debe seguir esta nomeclatura de xPath, Teniendo encuenta que las etiquetas Hijas estan dentro de etiquetas padres.
                
             */

            this.XPathElementoNombreLoteriaResultadoHijo = """//div[@class="game-details"]/a/span""";
            this.XPathElementoFechaResultadoHijo = """//div[@class="session-details"]/span[@class="session-date session-badge"]""";
            this.XPathElementoNumeroResultadoHijo = """//div[@class="game-scores ball-mode"]/span""";

            //Aqui se usa una condicional or en el xpath por que en esta pagina web los resultados con la fecha actual - 1 dia, se le agrega la class past.
            //De todas formas nos interesa verificar si se encuentran ya o no en nuestro repositorio de datos.
            this.XPathElementoContenedorPadre = """//div[@class="game-block "] | //div[@class="game-block past"]""";

        }

    }
}
