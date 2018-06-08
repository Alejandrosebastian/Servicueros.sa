using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Bodega
    {
        public int BodegaId { get; set; }

        [Display(Name = "Bodega")]
        [Required(ErrorMessage = "Campo requerido")]
        public string NombreBodega { get; set; }

        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Ubicacion { get; set; }

        [Display(Name = "Cantidad de pieles")]
        [Required(ErrorMessage = "Campo requerido")]
         public int CantidadAlmacenamiento { get; set; }

        [Display(Name = "Numero de estanteria")]
        [Required(ErrorMessage = "Campo requerido")]
        public int NumeroEstantes { get; set; }

        //Relaciones
        public int TipoBodegaId { get; set; }
        public TipoBodega TiposBodega { get; set; }
        


    }
}
