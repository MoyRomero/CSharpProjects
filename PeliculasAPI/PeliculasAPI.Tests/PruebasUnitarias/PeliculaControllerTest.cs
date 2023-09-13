using Microsoft.AspNetCore.Http;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class PeliculaControllerTest : BasePruebas
    {
        [TestMethod]
        public async Task FiltroPrueba()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var pelicula
                = new PeliculaCreacionDTO()
                {
                    Titulo = "The Fast and the Furious"
                };

            var filtroPelicula 
                = new FiltroPeliculasDTO()
                {
                    CantidadRegistrosPagina = 1,
                    Titulo = "John Wick"
                };

            var controller = new PeliculaController(contexto, mapper, null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            controller.Post(pelicula);

            var respuesta = await controller.Filtrar(filtroPelicula);
            var resultado = respuesta.Value;

            Assert.AreEqual(0,resultado.Count);
        }
    }
}
