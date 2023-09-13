using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using System.Security.Claims;

namespace PeliculasAPI
{
    public class AplicationDbContext: IdentityDbContext
    {
        public AplicationDbContext( DbContextOptions options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PeliculasActores>().HasKey(x => new { x.ActorId, x.PeliculaId });
            modelBuilder.Entity<PeliculasGeneros>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculasSalasDeCine>().HasKey(x => new { x.PeliculaId, x.SalaDeCineId});
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var rolAdminId = "5efebc3e-7ecb-487d-bc59-2a2b72a7095e";
            var usuarioAdminId = "ad59c5be-4cfb-4302-8cc2-9f416a7e61e2";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            var userName = "moyromero.1695@gmail.com";

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                UserName = userName,
                NormalizedUserName = userName,
                Email = userName,
                NormalizedEmail = userName,
                PasswordHash = passwordHasher.HashPassword(null, "Aa12345!")
            };

            //modelBuilder.Entity<IdentityUser>().HasData(usuarioAdmin);
            //modelBuilder.Entity<IdentityRole>().HasData(rolAdmin);
            //modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            //{
            //    Id = 1,
            //    ClaimType = ClaimTypes.Role,
            //    UserId = usuarioAdminId,
            //    ClaimValue = "Admin"
            //});
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasGeneros> PeliculasGeneros { get;set; }
        public DbSet<PeliculasActores> PeliculasActores { get;set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
