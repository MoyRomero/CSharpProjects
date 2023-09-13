﻿using Microsoft.AspNetCore.Identity;

namespace WebApiAutores.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; } //Se cambió del tipo IdentityUser --> Usuario
    }
}
