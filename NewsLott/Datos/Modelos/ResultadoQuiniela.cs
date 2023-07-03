﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLott.Datos.Modelos
{
    public class ResultadoQuiniela
    {
        [Key]
        [MaxLength(20)]
        public string IdResultado { get; set; }
        [Required]
        [MaxLength(20)]
        public string Primera { get; set; }
        [Required]
        [MaxLength(20)]
        public string Segunda { get; set; }
        [Required]
        [MaxLength(20)]
        public string Tercera { get; set; }
        public DateTime FechaResultado { get; set; }
        [Required]
        [MaxLength(20)]
        [ForeignKey("Loteria")]
        public string IdLoteria { get; set; }
        public Loteria Loteria { get; set; }
        public EstadoResultado EstadoResultado { get; set; }
        [ForeignKey("EstadoResultado")]
        public int IdEstadoResultado { get; set; }
    }
}
