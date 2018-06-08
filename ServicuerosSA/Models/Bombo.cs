using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ServicuerosSA.Models
{
    public class Bombo
    {
        public int BomboId { get; set; }
        [Display(Name = "Numero de Bombo ")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Num_bombo { get; set; }
        [Display(Name = "Capacidad de Bombo en kilos ")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Capacidad { get; set; }
        [Display(Name = " Fecha de Ingreso al Bombo ")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        
        //RELACIONES
       

    }
}
