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
        public decimal NumeroPieles { get; set; }
        public int peso { get; set; }
        public DateTime fecha { get; set; }
        public string codigolote { get; set; }

        //Relaciones
        public int DescarneId { get; set; }
        public Descarne Descarnes { get; set; }
       public int ClasificacionTripaId { get; set; }
       public ClasificacionTripa ClasificacionTripa { get; set; }
        
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }

        public int BodegaId { get; set; }
        public Bodega bodega { get; set; }

    }
}
