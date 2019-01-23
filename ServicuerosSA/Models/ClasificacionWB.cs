using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ServicuerosSA.Models
{
    public class ClasificacionWB
    {
        public int ClasificacionwbId { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroPieles { get; set; }
        public string Observaciones { get; set; }
       


    }
}
