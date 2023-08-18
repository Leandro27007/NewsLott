using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLott.Entidades
{
    public class Loteria
    {
        [Key]
        public string IdLoteria { get; set; }
        public string NombreLoteria { get; set; }
        public CompaniaDeLoteria CompaniaDeLoteria { get; set; }
        [ForeignKey(nameof(CompaniaDeLoteria))]
        public string IdCompaniaDeLoteria { get; set; }
        public List<ResultadoDeLoteria> ResultadoDeLoterias { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
