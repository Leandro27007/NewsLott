using System.ComponentModel.DataAnnotations;

namespace NewsLott.Datos.Modelos
{
    public class Loteria
    {
        [Key]
        [MaxLength(20)]
        public string IdLoteria { get; set; }
        [Required]
        [MaxLength(20)]
        public string NombreLoteria { get; set; }
        public List<ResultadoQuiniela>? ResultadosQuiniela { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
