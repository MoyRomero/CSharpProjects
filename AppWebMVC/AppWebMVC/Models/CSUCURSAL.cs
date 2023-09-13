using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebMVC
{
    public class CSUCURSAL
    {
        [Display(Name = "ID SUCURSAL")]
        public int IDSucursal { get; set; }

        [Display(Name = "NOMBRE")]
        [StringLength(100,ErrorMessage = "No se permiten más de 100 caractéres para el campo: NOMBRE.")]
        [Required]
        public string NOMBRE { get; set; }

        [Display(Name = "DIRECCIÓN")]
        [StringLength(200,ErrorMessage = "No se permiten más de 200 caractéres para el campo: DIRECCIÓN.")]
        [Required]
        public string DireccSucursal { get; set; }

        [Display(Name = "TELÉFONO")]
        [StringLength(10,ErrorMessage = "No se permiten más de 10 caractéres para el campo: TELÉFONO.")]
        [Required]
        public string TelSucursal { get; set; }

        [Display(Name = "EMAIL")]
        [StringLength(100,ErrorMessage = "No se permiten más de 100 caractéres para el campo: EMAIL.")]
        [Required]
        [EmailAddress(ErrorMessage = "Por favor, ingresa un Email válido.")]
        public string EmailSucursal { get; set; }

        [Display(Name = "FECHA DE APERTURA")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime FechaApertura { get; set; }

        public string MensajeErrorNombre { get; set; }
        public string MensajeErrorEmail { get; set; }
        public int BHABILITADO { get; set; }
    }
}