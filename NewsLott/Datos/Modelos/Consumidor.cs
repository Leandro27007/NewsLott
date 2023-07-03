using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLott.Datos.Modelos
{
    public class Consumidor
    {
        [Key]
        public int IdConsumidor { get; set; }
        [MaxLength(20)]
        public string NumeroTelefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EstadoConsumidor EstadoConsumidor { get; set; }
        [ForeignKey("EstadoConsumidor")]
        public int IdEstadoConsumidor { get; set; }
    }
}
