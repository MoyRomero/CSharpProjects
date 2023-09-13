using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Actor : IId
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "No se permiten más de {1} caractéres para el campo: {0}")]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public List<PeliculasActores> PeliculasActores { get; set; }
    }
}
