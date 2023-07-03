using System.ComponentModel.DataAnnotations;

namespace NewsLott.Datos.Modelos
{
    public class EstadoConsumidor
    {
        [Key]
        public int IdEstadoConsumidor { get; set; }
        [MaxLength(20)]
        public string NombreEstado { get; set; }
        public List<Consumidor> Consumidores { get; set; }

    }
}
