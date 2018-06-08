using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class ListaClasificacionesModel
    {
        public int Bodega1Id { get; set; }
        public string NombreBodega { get; set; }
        public string Estante { get; set; }
        public string CodigoLote { get; set; }
        public int NumeroPieles { get; set; }
        public int Peso { get; set; }
        public string Clasificacion { get; set; }
        public string TipoPiel { get; set; }
    }
}
