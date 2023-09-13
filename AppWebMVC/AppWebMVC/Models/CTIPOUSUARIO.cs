using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebMVC
{
    public class CTIPOUSUARIO
    {
        [Display(Name = "ID TIPO USUARIO")]
        public int IDTipoUsuario { get; set; }

        [Display(Name = "NOMBRE")]
        [Required]
        [StringLength(150, ErrorMessage = " 0 es el máximo de caractéres para este campo.")]
        public string NOMBRE { get; set; }

        [Display(Name = "DESCRIPCIÓN")]
        [Required]
        [StringLength(150, ErrorMessage = " 0 es el máximo de caractéres para este campo.")]
        public string Descripcion { get; set; }

        public string LimpiarBorrar { get; set; }

        public int BHABILITADO { get; set; }

    }
}