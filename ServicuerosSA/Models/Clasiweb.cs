using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Clasiweb
    {
        public int clasiwebId { get; set; }
        public string Detalle { get; set; }
        public int ClasificacionwbId { get; set; }
        public ClasificacionWB clasificacionwb { get; set; }

    }
}
