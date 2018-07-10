using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Bodega1
    { //RELACIONES
        public int Bodega1Id { get; set; }
        public int BodegaId { get; set; }
        public Bodega Bodegas { get; set; }
        public int LoteId { get; set; }
        public Lote Lotes { get; set; }
        public int ClasificacionId { get; set; }
        public Clasificacion Clasificaciones { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }
        //FIN RELACIONES

        [Display(Name = "Fecha de pieles a bodega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fechaingreso { get; set; }

        [Display(Name = "Numero de estanteria")]
        [  Required(ErrorMessage ="Campo requerido")]
        public int NumeroEstanteria { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Numero de Pieles")]
        public int NumeroPieles { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Ingrese el peso")]
        public int Peso { get; set; }

        [Display(Name = "Observacion del proceso")]
        public String Observaciones { get; set; }
        public bool activo { get; set; }
        public int TipoPielId { get; set; }
        public TipoPiel TipoPiel { get; set; }

    }
}
