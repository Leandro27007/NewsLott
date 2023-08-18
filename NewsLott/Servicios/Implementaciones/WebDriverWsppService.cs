using NewsLott.Constantes;
using NewsLott.Servicios.Interfaces;
using NewsLott.ServiciosSegundoPlano.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace NewsLott.Servicios.Implementaciones
{
    public class WebDriverWsppService : IWebDriverWsppService
    {
        protected WebDriver _driver;
        public WebDriverWsppService(INavegador navegador)
        {
            /*TENIA ESTE CODIGO ANTES< PERO AHORA NO  LO NECESITO POR QUE DESACOPLE UN POCO, MI WebDriverWsspService
            No NECESITA CREAR EL OBJETO DE EDGE DRIVER O CUALQUIER OTRA INSTANCIA DE NAVEGADOR, EN CAMBIO LO RECIBE
            YA CREADO POR EL CONSTRUCTOR MEDIANTE EL METODO DE LA INTERFAZ INavegador*/
            //EdgeOptions opciones = new EdgeOptions();
            //opciones.AddArgument("--headless");
            ////opciones.AddArgument("--window-size=1280,1024");
            ////opciones.AddArgument("--start-maximized");
            //_driver = new EdgeDriver(opciones);

            this._driver = navegador.ObtenerDriver();
        }
        public string VincularWsppPorQr()
        {
            _driver.Navigate().GoToUrl($"https://web.whatsapp.com");

            return "Navegando a Wssp Web, Revise el QR en su instancia del navegador.";
        }

        public string VincularWsppPorNumero(string numeroCelular)
        {
            var condicionEsperada = SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists;
            string codigo = "";

            WebDriverWait wait20 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            WebDriverWait wait5 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            Console.WriteLine(_driver.Url.ToString());

            if (_driver.Url.ToString() != "https://web.whatsapp.com/")
            {
                _driver.Navigate().GoToUrl($"https://web.whatsapp.com/send?phone={numeroCelular}");
            }
            try
            {
                Screenshot ss1 = ((ITakesScreenshot)_driver).GetScreenshot();
                ss1.SaveAsFile(@"C:\Users\ICraz\OneDrive\Escritorio\FromTry.png", ScreenshotImageFormat.Png);

                IWebElement? resultadoDeBusqueda = wait20.Until(condicionEsperada(By.CssSelector(ElementosHtml.cssBotonVincularPorNumero)));
                resultadoDeBusqueda.Click();

                var inputCelular = wait5.Until(condicionEsperada(By.XPath(ElementosHtml.xPathInputNumeroVincular)));
                inputCelular.SendKeys("8297552708");

                var btnSiguiente = wait5.Until(condicionEsperada(By.ClassName(ElementosHtml.classBntVincular)));
                btnSiguiente.Click();

                wait5.Until(condicionEsperada(By.CssSelector(ElementosHtml.cssCodigoConfirmacion)));
                var codigoConfirmacion = _driver.FindElements(By.CssSelector(ElementosHtml.cssCodigoConfirmacion));


                foreach (var item in codigoConfirmacion)
                {
                    codigo += item.Text;
                }

                return codigo;
            }
            catch (Exception ex)
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\ICraz\OneDrive\Escritorio\FromCatch.png",
                ScreenshotImageFormat.Png);

                return $"Ocurrio un error: {ex.Message}";
            }
        }
        public string CerrarSesionWspp()
        {
            try
            {
                var condicionEsperada = SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists;
                var menu = _driver.FindElement(By.CssSelector("[title*='Menu']"));
                menu.Click();

                var elementosDelMenu = _driver.FindElements(By.ClassName(ElementosHtml.classBtnCerrar));
                var btnCerrar = elementosDelMenu.Skip(5).First();
                btnCerrar.Click();

                var btnConfirmarCerrar = _driver.FindElement(By.ClassName(ElementosHtml.classBtnConfirmarCerrar));
                btnConfirmarCerrar.Click();

                return "Se cerror la cession";
            }
            catch (Exception ex)
            {
                return $"Ocurrio un error al intentar cerrar sesion: {ex.Message}";
            }
        }
    }
   
}
