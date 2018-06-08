using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Medida
    {
        public int MedidaId { get; set; }
        [Display(Name ="Especifique la unidad Medida")]
        [Required (ErrorMessage ="Campo Requerido")]
        public string Detalle { get; set; }
        [Display(Name ="Abreviatura de la unidad de Medida")]
        [Required(ErrorMessage ="Campo Obligatorio")]
        public string Abreviatura { get; set; }

    }
}
