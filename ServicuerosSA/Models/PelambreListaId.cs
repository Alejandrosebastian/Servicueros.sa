using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class PelambreListaId
    {
        public int pelambreId { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public int BodegaId1 { get; set; }
        public Bodega1 Bodega1 { get; set; }
        public int BomboId { get; set; }
        public Bombo Bombo { get; set; }
        public int FormulaId { get; set; }
        public Formula Formula { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
        public bool Activo { get; set; }
        public string Codigo { get; set; }
        public int TotalPieles { get; set; }
        public int Peso { get; set; }
        public string CodigoLote { get; set; }
        public string codigopelambre { get; set; }

    }
}
