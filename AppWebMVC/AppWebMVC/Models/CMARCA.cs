using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebMVC
{
    public class CMARCA
    {
        [Display(Name = "ID")]
        public int IDMarca {get; set;}
        [Display(Name = "NOMBRE")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud máxima de \"NOMBRE\" es: 100")]
        public string NOMBRE { get; set;}
        [Display(Name = "DESCRIPCIÓN")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima de la \"DESCRIPCIÓN\" es: 200")]
        public string DescripMarca { get; set;}
        public bool BHABILITADO { get; set;}        
        public string MensajeError { get; set;}
    }
}