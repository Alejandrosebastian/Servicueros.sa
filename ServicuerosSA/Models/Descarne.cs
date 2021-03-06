﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ServicuerosSA.Models
{
    public class Descarne
    {
        public int DescarneId { get; set; }
        [Display(Name = "Numero de pieles a Descarnar")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Cantidad { get; set; }
        [Display(Name = "Fecha de ingreso de pieles a Descarnar")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string codigodescarne { get; set; }
        public string CodigoLote { get; set; }
        public string codiunidescarne { get; set; }

        //RELACIONES
        public int PelambreId { get; set; }
        public Pelambre Pelambres { get; set; }
        public int PersonalId { get; set; }
        public Personal personales { get; set; }
       

    }
}
