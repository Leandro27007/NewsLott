using HtmlAgilityPack;
using NewsLott.Datos;
using NewsLott.DTOs;
using System.Runtime.InteropServices.ObjectiveC;

namespace NewsLott.ServiciosSegundoPlano.Interfaces
{
    public interface IResultadoWebScrapy
    {

        /// <summary>
        /// Carga los resultados de las loterias a la base de datos, si ya existe no los carga.
        /// </summary>
        /// <returns>Regresa un objeto con el estado (resultado) de la solicitud</returns>
        Task<object> CargarResultadosAsync();
        /// <summary>
        /// Ejemplo: nombreCarpeta = "LoteriaName" si tenemos la url"www.loteriasc#.com/{nombreCarpeta}" 
        /// </summary>
        /// <param name="nombreCarpeta"></param>
        /// <returns> Regresa un documento html del esquema de la pagina con todos sus elementos</returns>
        HtmlDocument ObtenerPaginaHtml(string? nombreCarpeta);

    }
}
