using NewsLott.Datos.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsLott.DTOs
{
    public class ResultadoQuinielaDTO
    {
        public string IdLoteria { get; set; }
        public string Primera { get; set; }
        public string Segunda { get; set; }
        public string Tercera { get; set; }
        public DateTime FechaResultado { get; set; }
        public int IdEstadoResultado { get; set; }

    }
}
