using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class AplicationDbContext : IdentityDbContext<Usuario>
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorLibro>().HasKey(x => new { x.AutorId, x.LibroId });

            modelBuilder.Entity<Factura>().Property(x=>x.Monto).HasColumnType("decimal(18,2)");
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }  
        public DbSet<AutorLibro> AutoresLibros { get; set; }
        public DbSet<LlaveAPI> LlavesAPI { get; set; }
        public DbSet<Peticion> Peticiones { get; set;}
        public DbSet<RestriccionDominio> RestriccionesDominio { get; set; }
        public DbSet<RestriccionIp> RestriccionesIp { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaEmitida> FacturasEmitidas { get; set; }

    }
}
