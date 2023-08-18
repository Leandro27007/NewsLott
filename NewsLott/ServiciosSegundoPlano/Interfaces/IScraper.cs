using HtmlAgilityPack;

namespace NewsLott.ServiciosSegundoPlano.Interfaces
{
    public interface IScraper
    {
        Task RasparWeb();
        Task<HtmlDocument> ObtenerWebHtml();

    }
}
