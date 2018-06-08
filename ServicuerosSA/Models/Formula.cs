using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ServicuerosSA.Models
{
    public class Formula
    {
        public int FormulaId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre de la Formula")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha de creacion de la formula ")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Creacion { get; set; }

        [Display(Name ="Ingrese Proceso")]
        [Required(ErrorMessage ="Campo Obligatori")]
        public string TipoProceso { get; set; }
        public int TipoPielId { get; set; }
        public TipoPiel tipoPiel { get; set; }
    }
}
