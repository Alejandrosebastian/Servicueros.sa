using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ServicuerosSA.Models
{
    public class Componente
    {
        public int ComponenteId { get; set; }
        [Display (Name ="Nombre del componente")]
        [Required(ErrorMessage ="Campo Requerido")]
        public string Detalle { get; set; }
        [Display(Name ="Porcentaje de Componente")]
        [Required (ErrorMessage ="Campo requerido")]
        public string Porcentaje{ get; set; }
       [Display(Name = " Tiempo ")]
        [Required(ErrorMessage = "Campo Requerido")]   
        public int Tiempo  { get; set; }
      

        //RELACIONES
        public int FormulaId { get; set; }
        public Formula formula { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }
    }
}
