using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Personal
    {
        public int PersonalId { get; set; }

        [Display(Name = "Numero de cedula")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Revise que el  numero de cedula sea correcto maximo 10 caracteres ")]
        public string Cedula { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo requqerido")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        
        public int SexoId { get; set; }
        [Display(Name = "Genero")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Campo Rrequerido")]
        [Display(Name = "Telefono ")]
        [StringLength(17, MinimumLength = 9, ErrorMessage = "El numero de caracteres debe ser entre 9 y 17")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo Rrequerido")]
        [Display(Name = "Celular")]
        [StringLength(17, MinimumLength = 9, ErrorMessage = "El numero de caracteres debe ser entre 9 y 17")]
        public string Celular { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        
    }
}
