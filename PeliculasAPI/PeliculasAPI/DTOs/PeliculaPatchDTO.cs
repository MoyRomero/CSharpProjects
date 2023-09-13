using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class PeliculaPatchDTO
    {
        [Required]
        [StringLength(200, ErrorMessage = "El campo {1} no puede contener más de {0} caractéres.")]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

    }
}
