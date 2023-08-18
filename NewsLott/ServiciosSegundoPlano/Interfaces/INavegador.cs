using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace NewsLott.ServiciosSegundoPlano.Interfaces
{
    public interface INavegador
    {
        WebDriver ObtenerDriver();
        string ObtenerNombreDriver();
        bool ReiniciarDriver();
        bool CerrarDriver();
    }
}
