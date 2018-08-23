using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Pelambre
    {
        public int PelambreId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de ingreso al Pelambre ")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime Fecha { get; set; }
        [Display(Name ="Observaciones de Pelambre")]
        public string Observaciones { get; set; }
        //relaciones
        public int Bodega1Id { get; set; }
        public Bodega1 Bodega1 { get; set; }
        public int BomboId { get; set; }
        public Bombo Bombo { get; set; }
        public int FormulaId { get; set; }
        public Formula Formula { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
        public bool Activo { get; set; }
        public string Codigo { get; set; }
        public int TotalPieles { get; set; }
        public int Peso { get; set; }
        public string CodigoLote { get; set; }
        public string codigopelambre { get; set; }

    }
}
