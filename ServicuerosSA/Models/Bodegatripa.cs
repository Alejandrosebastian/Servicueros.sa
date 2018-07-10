using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Bodegatripa
    {

        public int BodegaTripaId { get; set; }
        public bool activo { get; set; }
        public int NumeroPieles { get; set; }
        public int peso { get; set; }
        
        //Relaciones
        public int DescarneId { get; set; }
        public Descarne Descarnes { get; set; }
        public int ClasificacionTripaId { get; set; }
        public ClasificacionTripa ClasificacionTripa { get; set; }
        public int Personal { get; set; }
        public Personal personal { get; set; }
        
    }
}
