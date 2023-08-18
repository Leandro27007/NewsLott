using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLott.Entidades
{
    public class ResultadoDeLoteria
    {
        [Key]
        public string IdResultadoDeLoteria { get; set; }
        public string NumerosPremiados { get; set; }
        public Loteria Loteria { get; set; }

        [ForeignKey(nameof(Loteria))]
        public string IdLoteria { get; set; }
        public DateTime FechaResultado { get; set; }
    }
}
