using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC
{
    public class CEMPLEADO
    {
        [Display(Name = "ID")]
        public int IDEmpleado { get; set; }

        [Display(Name = "NOMBRE")]
        [Required]
        [StringLength(100,ErrorMessage ="Máximo de caractéres: 100.")]
        public string NOMBRE { get; set; }

        [Display(Name = "A.PATERNO")]
        [Required]
        [StringLength(200, ErrorMessage = "Máximo de caractéres: 200.")]
        public string APPaterno { get; set; }

        [Display(Name = "A.MATERNO")]
        [Required]
        [StringLength(200, ErrorMessage = "Máximo de caractéres: 200.")]
        public string APMaterno { get; set; }

        [Display(Name = "FECHA-CONTRATO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaContrato { get; set; }

        [Display(Name = "SUELDO")]
        [Required]
        public decimal Sueldo { get; set; }

        [Display(Name = "T.CONTRATO")]
        public string TipoContrato { get; set; }
        [Required]
        public int IDTipoContrato { get; set; }

        [Display(Name = "T.USUARIO")]
        public string TipoDeUsuario { get; set; }
        [Display(Name = "IDT.USUARIO")]
        public int IDTipoDeUsuario { get; set; }

        [Display(Name = "SEXO")]
        public string Sexo { get; set; }
        [Required]
        public int IDSexo { get; set; }

        public int BHabilitado { get; set; }

    }
}