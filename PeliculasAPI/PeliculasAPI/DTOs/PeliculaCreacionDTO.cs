using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Utilidades;
using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class PeliculaCreacionDTO
    {
        [Required]
        [StringLength(200, ErrorMessage = "El campo {1} no puede contener más de {0} caractéres.")]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

        [PesoArchivoValidacion(PesoMaximoMB:10)]
        [FormatoValidacion(grupoTipoArchivo:GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIDs { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List<ActorPeliculasCreacionDTO> Actores { get; set; }
    }
}
