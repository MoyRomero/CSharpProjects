using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class ReviewControllerTest:BasePruebas
    {
        [TestMethod]
        public async Task ReviewYaCreado404()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            var mapper = ConfigurarAutoMapper();

            CrearPeliculas(nombreBD);

            var peliculaId = contexto.Peliculas.First().Id;

            var review = new Review()
            {
                Comientario = "Buena película",
                PeliculaId = peliculaId,
                UsuarioId = usuarioPorDefectoId,
                Puntuacion = 5
            };

            contexto.Add(review);
            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreBD);
            var controller = new ReviewController(contexto2, mapper);
            controller.ControllerContext = ConstruirControllerContext();

            var reviewDTO = new ReviewCreacionDTO()
            {
                Comentario = "Buena película.",
                Puntuacion = 5
            };

            var respuesta = await controller.Post(peliculaId, reviewDTO);
            var resultado = respuesta as IStatusCodeActionResult;

            Assert.AreEqual(400, resultado.StatusCode.Value);
        }
        [TestMethod]
        public async Task PosteandoReview()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            var mapper = ConfigurarAutoMapper();

            CrearPeliculas(nombreBD);

            var peliculaId = contexto.Peliculas.First().Id;

            var contexto2 = ConstruirContext(nombreBD);
            var controller = new ReviewController(contexto2, mapper);
            controller.ControllerContext = ConstruirControllerContext();

            var reviewDTO = new ReviewCreacionDTO()
            {
                Comentario = "Buena película.",
                 Puntuacion = 5
            };

            var respuesta = await controller.Post(peliculaId, reviewDTO);
            var resultado = respuesta as NoContentResult;

            Assert.AreEqual(204, resultado.StatusCode);
        }

        public async void CrearPeliculas(string nombreBD)
        {
            var contexto = ConstruirContext(nombreBD);
            contexto.Peliculas.Add(new Pelicula() { Titulo = "The Fast and The Furious"});
            await contexto.SaveChangesAsync();
        }
    }
}
