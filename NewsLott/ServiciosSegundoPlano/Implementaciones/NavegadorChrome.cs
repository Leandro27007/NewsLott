using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using NewsLott.ServiciosSegundoPlano.Interfaces;
using OpenQA.Selenium.Chrome;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class NavegadorChrome : INavegador, IDisposable
    {


        private ChromeDriver _driver;

        public NavegadorChrome()
        {
            ChromeOptions opciones = new ChromeOptions();
            opciones.AddArgument("--headless");
            opciones.AddArgument("--window-size=1920,1080");
            opciones.AddArgument("--start-maximized");
            //opciones.AddArgument("--disable-extensions");
            //opciones.AddArgument("--proxy-bypass-list=*");
            //opciones.AddArgument("--proxy-server='direct://'");
            //opciones.AddArgument("--disable-gpu");
            //opciones.AddArgument("--disable-dev-shw-usuage");
            //opciones.AddArgument("--no-sandbox");
            //opciones.AddArgument("--ignore-certificate-errors");
            opciones.AddArgument("--user-agent=Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36");
            _driver = new ChromeDriver(opciones);
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
                _driver = new ChromeDriver();
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
