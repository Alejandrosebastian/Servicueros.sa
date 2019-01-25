using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class DescarnelistId
    {
        public int descarneId { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public bool activo { get; set; }
        public string codigodescarne { get; set; }
        public string codigolote { get; set; }
        public string codiunicodescarne { get; set; }
        public int PelambreId { get; set; }
        public Pelambre Pelambres { get; set; }
        public int PersonalId { get; set; }
        public Personal personales { get; set; }
    }
}
