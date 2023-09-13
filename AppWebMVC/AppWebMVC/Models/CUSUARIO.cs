using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC.Models
{
    public class CUSUARIO
    {

        [Display(Name ="IDr")]        
        public int IDUsuario { get; set; }

        [Display(Name = "NOMBRE DE USUARIO")]
        [Required]
        [StringLength(100, ErrorMessage = "Se sobre pasó el límite de caractéres admitidos. Límite: 100.")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Se sobre pasó el límite de caractéres admitidos. Límite: 100.")]
        public string Contrasena { get; set; }

        [Display(Name = "TIPO USUARIO")]
        public string TipoUsuario { get; set; }

        [Required]
        public int ID { get; set; }

        [Required]
        public int IDRol { get; set; }

        public int BHABILITADO { get; set; }

        [Display(Name = "NOMBRE")]
        public string NombrePersona { get; set; }

        [Display(Name = "ROL")]
        public string NombreRol { get; set;}

    }
}