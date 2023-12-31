﻿using WebApiAutores.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAutores.DTOs
{
    [NotMapped]
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }
        public List<AutorDTO> Autores { get; set; }
    }
}
