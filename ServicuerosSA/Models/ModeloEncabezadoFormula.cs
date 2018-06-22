using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class ModeloEncabezadoFormula
    {
        public string Codigo { get; set; }
        public string Version { get; set; }
        public string FechaCreacionFormula { get; set; }
        public string FechaImpresion { get; set; }
        public string FechaValida { get; set; }
        public string Parada { get; set; } //idPelambre
        public string Bombo { get; set; }
        public string Peso { get; set; }
        public string Cantidad { get; set; }
        public string Promedio { get; set; }
        public string NombreAutoirzado { get; set; }
        public string NombreProcesado { get; set; }
        public string NombreEntregado { get; set; }
        public string TipoPiel { get; set; }

    }
}
