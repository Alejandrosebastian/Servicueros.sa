using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Curtido
    {
        public int CurtidoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Peso { get; set; }
        public string Observaciones { get; set; }
        public decimal NPieles { get; set; }
        public string codicurtido { get; set; }
        //RELACIONES
        public int FormulaId { get; set; }
        public Formula Formula { get; set; }
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
        //public int ClasificacionTripaId  { get; set; }
        //public ClasificacionTripa ClasificacionTripa { get; set; }
        public int BodegaTripaId { get; set; }
        public Bodegatripa BodegaTripa { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }
        public int BomboId { get; set; }
        public Bombo Bombo { get; set; }
        public int BodegaId { get; set; }
        public Bodega Bodega { get; set; }

    }
}
