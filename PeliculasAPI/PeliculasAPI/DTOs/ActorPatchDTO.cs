using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class ActorPatchDTO
    {
        [Required]
        [MaxLength(120, ErrorMessage = "No se permiten más de {1} caractéres para el campo: {0}")]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
