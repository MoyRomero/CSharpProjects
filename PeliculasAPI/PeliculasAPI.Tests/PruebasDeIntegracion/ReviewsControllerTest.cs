using Newtonsoft.Json;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasDeIntegracion
{
    [TestClass]
    public class ReviewsControllerTest:BasePruebas
    {
        private static readonly string url = "/api/peliculas/1/reviews";

        [TestMethod]
        public async Task RetornaPelicula404NotFound()
        {
            var nombreD = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreD);
            var mapper = ConfigurarAutoMapper();
            var factory = ConstruirWebApplicationFactory(nombreD, false);
            var controller = new ReviewController(context, mapper);

            var cliente = factory.CreateClient();

            var respuesta = await cliente.GetAsync(url);

            Assert.AreEqual(404, (int)respuesta.StatusCode);
        }

        [TestMethod]
        public async Task ListadoVacioDeReviewsDePeliculaExistente()
        {
            var nombreD = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreD);
            var mapper = ConfigurarAutoMapper();
            var factory = ConstruirWebApplicationFactory(nombreD, false);
            var controller = new ReviewController(context, mapper);

            CrearPelicula(nombreD);

            var cliente = factory.CreateClient();

            var respuesta = await cliente.GetAsync(url);            

            var reviews = JsonConvert
                .DeserializeObject<List<ReviewDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(0, reviews.Count);
        }

        protected async void CrearPelicula(string nombreBD)
        {
            var context = ConstruirContext(nombreBD);
            context.Add(new Pelicula() { Titulo = "The Fast and The Furious" });
            await context.SaveChangesAsync();
        }
    }
}
