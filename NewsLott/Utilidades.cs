using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace NewsLott
{
    public static class Utilidades
    {
        public static bool EstaElElemento(WebDriverWait wait, By by)
        {
			try
			{
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
				return true;
			}
			catch (Exception)
			{
                return false;
            }

        }

        /// <summary>
        /// Retorna verdadero si el valor se puede convertir a entero
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool EsEntero(string valor)
        {
            if (int.TryParse(valor, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
