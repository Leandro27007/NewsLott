using System.Globalization;
using System.Text;

namespace utilidades
{
    public static class Utils
    {
        public static string OrganizarNumeros(string numeros)
        {
            string listaNumeros = "";
            listaNumeros = numeros.Replace("-", " - ");
            return listaNumeros;
        }


        public static string ReemplazarEspaciosPorGuionBajo(string cadena)
        {
            string texto = "";
            texto = cadena.Trim().Replace(" ", "_");
            return texto;
        }


       public static string RemoverAcentosDiacriticos(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder result = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }


    }
}
