using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ServicuerosSA.Models
{
    public class Escurrido
    {
        public int EscurridoId { get; set; }
        [Display(Name ="Numero de pieles a Escurrir")]
        [Required(ErrorMessage ="Campo obligatorio")]
        public int Cantidad { get; set; }
        [Display(Name = "Fecha de ingreso de pieles a Escurrir")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string CodigoLote { get; set; }
        public bool Activo { get; set; }
        //RELACIONES
        public int BomboId { get; set; }
        public Bombo Bombos { get; set; }
        public int CurtidoId { get; set; }
        public Curtido Curtido { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }

    }
}
