using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeliculasAPI.DTOs
{
    [NotMapped]
    public class ActorCreacionDTO
    {
        [Required]
        [MaxLength(120, ErrorMessage = "No se permiten más de {1} caractéres para el campo: {0}")]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [PesoArchivoValidacion(PesoMaximoMB: 4)]
        [FormatoValidacion(grupoTipoArchivo:GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
