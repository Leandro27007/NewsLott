using System.ComponentModel.DataAnnotations;

namespace NewsLott.Datos.Modelos
{
    public class EstadoResultado
    {
        [Key]
        public int IdEstadoResultado { get; set; }
        [MaxLength(20)]
        public string NombreEstado { get; set; } //Reciente, No Reciente
        public List<ResultadoQuiniela> ResultadosQuiniela { get; set; }
        //Si es reciente o no.  Dejara de ser reciente cuando si hay un nuevo resultado en la misma loteria

    }
}
