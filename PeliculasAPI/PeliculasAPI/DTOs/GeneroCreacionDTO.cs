using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "El campo Nombre, es requerido.")]
        [StringLength(maximumLength: 40, ErrorMessage = "El campo {0} no puede contener más de {1} caractéres.")]
        public string Nombre { get; set; }
    }
}
