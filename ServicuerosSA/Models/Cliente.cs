using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        public string RUC { get; set; }





        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]

        public string Teleofno { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string correo { get; set; }
    }
}
