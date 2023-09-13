using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppWebMVC
{
    public class CCLIENTES
    {
        [Display(Name = "ID")] 
        public int IDCliente { get; set; }

        [Display(Name = "NOMBRE")]
        [Required]
        [StringLength(100, ErrorMessage = "El campo: NOMBRE acepta un máximo de 100 caractéres.")]
        public string NOMBRE { get; set; }

        [Display(Name = "A.PATERNO")]
        [Required]
        [StringLength(150, ErrorMessage = "El campo: A.PATERNO acepta un máximo de 150 caractéres.")]
        public string Appaterno { get; set; }

        [Display(Name = "A.MATERNO")]
        [Required]
        [StringLength(150, ErrorMessage = "El campo: A.MATERNO acepta un máximo de 150 caractéres.")]
        public string Apmaterno { get; set; }

        [Display(Name = "EMAIL")]
        [Required]
        [StringLength(200, ErrorMessage = "El campo: EMAIL acepta un máximo de 200 caractéres.")]
        [EmailAddress(ErrorMessage = "Ingresa in Email válido.")]
        public string Email { get; set; }

        [Display(Name = "DIRECCIÓN")]
        [Required]
        [StringLength(200, ErrorMessage = "El campo: DIRECCIÓN acepta un máximo de 200 caractéres.")]
        public string Direccion { get; set; }

        [Display(Name = "SEXO")]
        //[Required]
        //[StringLength(1, ErrorMessage = "El campo: TEL FIJO acepta un máximo de 0 caractéres.")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "IDSEXO")]        
        public int IDSexo { get; set; }

        [Display(Name = "TEL FIJO")]
        [Required]
        [StringLength(10, ErrorMessage = "El campo: TEL FIJO acepta un máximo de 10 caractéres.")]
        public string TelefonoFijo { get; set; }

        [Display(Name = "TEL CELULAR")]
        [Required]
        [StringLength(10, ErrorMessage = "El campo: TEL CELULAR acepta un máximo de 10 caractéres.")]
        public string TelefonoCel { get; set; }

        [Display(Name = "CONTIENE USUARIO")]
        //[Required]
        //[StringLength(100, ErrorMessage = "El campo: acepta un máximo de 0 caractéres.")]
        public int? BCUSUARIO { get; set; }

        public int BHABILITADO { get; set; }

        [Display(Name = "TIPO USUARIO")]
        //[Required]
        //[StringLength(1, ErrorMessage = "El campo: acepta un máximo de 1 caractér.")]
        public string TipoUsuario { get; set; }
        
        public string MensajeErrorNombres { get; set; }
    }
}