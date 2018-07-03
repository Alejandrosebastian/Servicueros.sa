using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class ClasificacionTripa
    {
        public int ClasificacionTripaId { get; set; }
        [Display(Name = "Tipo de Clasificacion")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Detalle { get; set; }
        [Display(Name = "Peso de la clasificacion en kilos")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int peso { get; set; }

    }
}
