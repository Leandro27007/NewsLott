using NewsLott.ServiciosSegundoPlano.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class NavegadorEdge : INavegador, IDisposable
    {
        private EdgeDriver _driver;

        public NavegadorEdge()
        {
            EdgeOptions opciones = new EdgeOptions();
            opciones.AddArgument("--headless");
            opciones.AddArgument("--window-size=1280,1024");
            opciones.AddArgument("--start-maximized");
            _driver = new EdgeDriver(opciones);
        }

        public WebDriver ObtenerDriver()
        {
            return _driver;
        }

        public string ObtenerNombreDriver()
        {
            return _driver.Title.ToString();
        }

        public bool ReiniciarDriver()
        {
            try
            {
                this.CerrarDriver();
                _driver = new EdgeDriver();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CerrarDriver()
        {
            try
            {
                _driver.Close();
                this.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
