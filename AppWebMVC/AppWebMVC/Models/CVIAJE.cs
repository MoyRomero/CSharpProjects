using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebMVC
{
    public class CVIAJE
    {
        [Display(Name = "ID")]
        public int IDViaje { get; set; }

        [Display(Name = "LUGAR ORIGEN")]
        public string LugarOrigen { get; set; }
        [Required]
        public int IDLugarOrigen { get; set; }

        [Display(Name = "LUGAR DESTINO")]
        public string LugarDestino { get; set; }
        [Required]
        public int IDLugarDestino { get; set; }

        [Display(Name = "PRECIO")]
        [Required]
        [Range(0, 100000, ErrorMessage ="El valor del precio, no puede superar la cantidad de: 100,000.")]
        public decimal Precio { get; set; }

        [Display(Name = "FECHA VIAJE")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaViaje { get; set; }

        [Display(Name = "BUS")]
        [Required]
        public int IDBus { get; set; }

        [Display(Name = "ASIENTOS DISPONIBLES")]
        [Required]
        public int NumAsientosDisponibles { get; set; }
        public string FechaViajeCadena { get; set; }
        public string Extension { get; set; }
        public string nombreFoto { get; set; }
        public string errorFoto { get; set; }
        public string CadenaFotoRecuperada { get; set; }
        public int BHabilitado { get; set; }
    }
}