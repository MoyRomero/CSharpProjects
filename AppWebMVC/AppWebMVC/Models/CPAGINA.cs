using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    
namespace AppWebMVC.Models
{   
    public class CPAGINA
    {
        [Display(Name = "ID PÁGINA")]
        public int IDPagina { get; set; }

        [Display(Name = "MENSAJE")]
        [Required]
        public string Mensaje { get; set; }

        [Display(Name = "ACCIÓN")]
        [Required]
        public string Accion { get; set; }

        [Display(Name = "CONTROLADOR")]
        [Required]
        public string Controlador { get; set; }
        public int BHABILITADO { get; set; }
    }
}