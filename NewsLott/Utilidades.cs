using System.Text;

namespace NewsLott
{
    public class Utilidades
    {
        public static string InvertirCadena(string cadena)
        {
            char[] arregloCaracteres = cadena.ToCharArray();
            Array.Reverse(arregloCaracteres);
            return new string(arregloCaracteres);
        }

    }
}
