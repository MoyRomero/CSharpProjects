using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC
{
    public class CROLPAGINA
    {
        [Display(Name = "ID RolPágina")]
        public int IDRolPagina { get; set; }


        [Display(Name = "Rol")]
        public string Rol { get; set; }
        [Required]
        public int IDRol { get; set; }


        [Display(Name = "Página")]
        public string Pagina { get; set; }
        [Required]
        public int IDPagina { get; set; }


        public int BHABILITADO { get; set; }


    }
}