using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLott.Entidades
{
    public class CompaniaDeLoteria
    {
        [Key]
        public string IdCompaniaDeLoteria { get; set; }
        public string NombreCompania { get; set; }
        public List<Loteria> Loterias { get; set; }
    }
}
