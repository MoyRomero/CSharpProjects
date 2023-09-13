using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class GenerosControllerTest:BasePruebas
    {
        private static readonly string url = "/api/generos";

        [TestMethod]
        public async Task ObtenerTodosLosGenerosListadoVacio()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert
                .DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());
            
            Assert.AreEqual(0, generos.Count);
        }

        [TestMethod]
        public async Task ObtenerTodosLosGeneros()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);
            var contexto = ConstruirContext(nombreBD);

            contexto.Add(new Genero() { Nombre = "Genero 1" });
            contexto.Add(new Genero() { Nombre = "Genero 2" });
            contexto.Add(new Genero() { Nombre = "Genero 3" });
            contexto.Add(new Genero() { Nombre = "Genero 4" });
            await contexto.SaveChangesAsync();

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert
                .DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(4, generos.Count);
        }

        [TestMethod]
        public async Task BorrarUltimoGenero()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);
            var contexto = ConstruirContext(nombreBD);

            contexto.Add(new Genero() { Nombre = "Genero 1" });
            contexto.Add(new Genero() { Nombre = "Genero 2" });
            contexto.Add(new Genero() { Nombre = "Genero 3" });
            contexto.Add(new Genero() { Nombre = "Genero 4" });
            await contexto.SaveChangesAsync();

            var cliente = factory.CreateClient();

            var respuestaDelete = await cliente.DeleteAsync(url + "/" + 4);

            var respuesta = await cliente.GetAsync(url);

            var resultadoDelete = respuestaDelete.StatusCode;

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert
                .DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(3, generos.Count);
        }

        [TestMethod]
        public async Task Retorna401Unauthorized()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD, ignorarSeguridad:false);
            var contexto = ConstruirContext(nombreBD);

            var cliente = factory.CreateClient();

            var respuestaDelete = await cliente.DeleteAsync(url + "/" + 4);

            Assert.AreEqual("Unauthorized",respuestaDelete.ReasonPhrase);
        }
    }
}
