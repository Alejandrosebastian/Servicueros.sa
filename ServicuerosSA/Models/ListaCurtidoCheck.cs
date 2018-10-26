using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class ListaCurtidoCheck
    {
        public int BodegaId { get; set; }
        public string Detalle { get; set; }
        public int BodegaTripaId { get; set; }
        public int peso { get; set; }
        public decimal NumeroPieles { get; set; }
        public string CodigoLote { get; set; }
        public string Abreviatura { get; set; }
        public int MedidaId { get; set; }
    }
}
