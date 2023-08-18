namespace NewsLott.ServiciosSegundoPlano.Interfaces
{
    public interface IScrapeableWeb
    {
        /// <summary>
        /// elemento o etiquetas que contienen el nombre de la loteria en el resultado ej: <div>SoyLaLoteria<div/> 
        /// </summary>
        public string XPathElementoNombreLoteriaResultadoHijo { get; set; }
        public string Url { get; set; }

        public string XPathElementoFechaResultadoHijo { get; set; }
        public string XPathElementoNumeroResultadoHijo { get; set; }
        public string XPathElementoContenedorPadre { get; set; }


    }
}
