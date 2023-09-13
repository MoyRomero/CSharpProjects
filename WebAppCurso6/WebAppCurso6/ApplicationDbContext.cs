using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppCurso6.Models;

namespace WebAppCurso6
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
    }
}