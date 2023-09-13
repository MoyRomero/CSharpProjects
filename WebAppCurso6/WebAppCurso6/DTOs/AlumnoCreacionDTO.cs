using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCurso6.DTOs
{
    public class AlumnoCreacionDTO
    {
        [Required]
        [StringLength(120, ErrorMessage ="El campo {0} no puede contener más de {1} caractéres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "El campo {0} no puede contener más de {1} caractéres.")]
        public string ApPaterno { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "El campo {0} no puede contener más de {1} caractéres.")]
        public string ApMaterno { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }


        public string FotoNombre { get; set; }
        public byte[] FotoBytes { get; set; }

        [Required]        
        public int SexoId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo {0} no puede contener más de {1} dígitos.")]
        public string TelefonoPadre { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo {0} no puede contener más de {1} dígitos.")]
        public string TelefonoMadre { get; set; }

        public int NumeroHermanos { get; set; }
    }
}