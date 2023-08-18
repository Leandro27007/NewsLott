using NewsLott.ServiciosSegundoPlano.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class NavegadorFirefox : INavegador
    {
        private FirefoxDriver _driver;

        public NavegadorFirefox()
        {
            //EdgeOptions opciones = new EdgeOptions();
            //opciones.AddArgument("--headless");
            //opciones.AddArgument("--window-size=1280,1024");
            //opciones.AddArgument("--start-maximized");
            _driver = new FirefoxDriver(/*opciones*/);
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
                _driver = new FirefoxDriver();
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
