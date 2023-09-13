using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC
{
    public class CROL
    {
        [Display(Name="ID ROL")]
        public int IDRol { get; set; }
        [Display(Name="NOMBRE")]
        [Required]
        [StringLength(100,ErrorMessage="Se superó el límite de carctéres. Límite: 0.")]
        public string  NOMBRE { get; set; }
        [Display(Name="DESCRIPCIÓN")]
        [Required]
        [StringLength(100,ErrorMessage="Se superó el límite de carctéres. Límite: 0.")]
        public string Descripcion { get; set; }
        public int BHABILITADO { get; set; }
        public string MensajeError { get; set; }
    }
}