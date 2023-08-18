using NewsLott.Entidades;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace NewsLott.Constantes
{
    public static class Diccionario
    {

        private static readonly Dictionary<string, Expression<Func<ResultadoDeLoteria, bool>>> diccExpreciones = new()
        {
            {"ganamas", r => r.IdLoteria == "gana_mas"},
            {"gana-mas", r => r.IdLoteria == "gana_mas"},
            {"gana mas", r => r.IdLoteria == "gana_mas"},
            {"1", r => r.IdLoteria == "gana_mas"},

            {"primera", r => r.IdLoteria == "la_primera"},
            {"la primera", r => r.IdLoteria == "la_primera"},
            {"2", r => r.IdLoteria == "la_primera"},

            {"primera noche", r => r.IdLoteria == "primera_noche"},
            {"la primera noche", r => r.IdLoteria == "primera_noche"},
            {"3", r => r.IdLoteria == "primera_noche"},

            {"nacional", r => r.IdLoteria == "loteria_nacional"},
            {"la nacional", r => r.IdLoteria == "loteria_nacional"},
            {"4", r => r.IdLoteria == "loteria_nacional"},

            {"new york tarde", r => r.IdLoteria == "new_york_3:30"},
            {"newyork", r => r.IdLoteria == "new_york_3:30"},
            {"newyor", r => r.IdLoteria == "new_york_3:30"},
            {"new yor", r => r.IdLoteria == "new_york_3:30"},
            {"nueva york", r => r.IdLoteria == "new_york_3:30"},
            {"nueba yor", r => r.IdLoteria == "new_york_3:30"},
            {"nueba york", r => r.IdLoteria == "new_york_3:30"},
            {"nuebayor", r => r.IdLoteria == "new_york_3:30"},
            {"5", r => r.IdLoteria == "new_york_3:30"},

            {"pegamas", r => r.IdLoteria == "pega_3_mas"},
            {"pega 3 mas", r => r.IdLoteria == "pega_3_mas"},
            {"pega mas", r => r.IdLoteria == "pega_3_mas"},
            {"pega 3 ma", r => r.IdLoteria == "pega_3_mas"},
            {"pega3 mas", r => r.IdLoteria == "pega_3_mas"},
            {"pega3mas", r => r.IdLoteria == "pega_3_mas"},
            {"pega3ma", r => r.IdLoteria == "pega_3_mas"},
            {"6", r => r.IdLoteria == "pega_3_mas"},

            {"quiniela la suerte", r => r.IdLoteria == "la_suerte_md"},
            {"la suerte medio dia", r => r.IdLoteria == "la_suerte_md"},
            {"la suerte", r => r.IdLoteria == "la_suerte_md"},
            {"lasuerte", r => r.IdLoteria == "la_suerte_md"},
            {"suerte", r => r.IdLoteria == "la_suerte_md"},
            {"7", r => r.IdLoteria == "la_suerte_md"},
              

            {"loteka", r => r.IdLoteria == "quiniela_loteka"},
            {"la loteka", r => r.IdLoteria == "quiniela_loteka"},
            {"quiniela loteka", r => r.IdLoteria == "quiniela_loteka"},
            {"loteca", r => r.IdLoteria == "quiniela_loteka"},
            {"la loteca", r => r.IdLoteria == "quiniela_loteka"},
            {"8", r => r.IdLoteria == "quiniela_loteka"},
              
              
            {"real", r => r.IdLoteria == "quiniela_real"},
            {"lareal", r => r.IdLoteria == "quiniela_real"},
            {"la real", r => r.IdLoteria == "quiniela_real"},
            {"quiniela real", r => r.IdLoteria == "quiniela_real"},
            {"quinielareal", r => r.IdLoteria == "quiniela_real"},
            {"9", r => r.IdLoteria == "quiniela_real"},
        };


        /// <summary>
        /// Permite obtener un exprecion que puede ser utilizada para buscar data en mi repositorio
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Expression<Func<ResultadoDeLoteria, bool>>? ObtenerExprecionDesdeElDiccionario(string key)
        {
            
            string? llave = key.ToLower();

            //Busco un valor en el diccionario que tenga la llave.
            var resultado = diccExpreciones.Where(d => d.Key == llave).FirstOrDefault().Value;

            //si no se encontro algun valor con dicha llave y el parametro key contiene espacios (osea mas de una palabra)
            //Itero las Key de mi diccionario buscando que alguna de las palabras que llegan en mi parametro coincidan
            //si una coincide entonces le agrego el valor de la key(string) a mi parametro para posteriormente hacer otro intento de busqueda
            if (resultado == null && key.Contains(" "))
            {

                foreach (var item in diccExpreciones.Keys)
                {
                    if (Regex.IsMatch(llave, item))
                    {
                        llave = item;
                        break;
                    }
                }

                //hago el segundo intento buscando una exprecion que tenga la llave. si no encuentro retorno su valor por defecto (null)
                resultado = diccExpreciones.Where(d => d.Key == llave).FirstOrDefault().Value;
            }
            return resultado;
        }
    }
}
