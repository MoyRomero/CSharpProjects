using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class GenerosControllerTest : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosGeneros()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            contexto.Generos.Add(new Genero() { Nombre = "Genero 1"});
            contexto.Generos.Add(new Genero() { Nombre = "Genero 2"});
            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);

            //Ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var respuesta = await controller.Get();


            //Verificacion
            var generos = respuesta.Value;
            Assert.AreEqual(2, generos.Count);
        }

        [TestMethod]
        public async Task ObtenerUnGeneroPorIdNoExistente()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var contexto2 = ConstruirContext(nombreDB);

            //Ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var respuesta = await controller.Get(id: 20);

            //Verificacion
            var generoObtenido = respuesta.Result as StatusCodeResult;

            Assert.AreEqual(404, generoObtenido.StatusCode);
        }

        [TestMethod]
        public async Task ObtenerUnGeneroPorId()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            contexto.Generos.Add(new Genero() { Id = 3, Nombre = "Genero 1" });
            contexto.Generos.Add(new Genero() { Id = 20 , Nombre = "Genero 2" });
            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);

            //Ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var respuesta = await controller.Get(id:20);

            //Verificacion
            var generoObtenido = respuesta.Value;

            Assert.AreEqual("Genero 2", generoObtenido.Nombre);
        }

        [TestMethod]
        public async Task CrearUnGeneroPost()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var generoNuevo = new GeneroCreacionDTO() { Nombre = "Genero nuevo" };
            var contexto2 = ConstruirContext(nombreDB);

            //Ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var respuesta = await controller.Post(generoNuevo);

            var busquedaGenero = await contexto2.Generos.AnyAsync(x=>x.Nombre == generoNuevo.Nombre);

            //Verificacion
            Assert.IsTrue(busquedaGenero);
        }

        [TestMethod]
        public async Task EditarUnGeneroPut()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            contexto.Generos.Add(new Genero() { Nombre = "Genero nuevo" });
            await contexto.SaveChangesAsync();

            var generoParaEditar = new GeneroCreacionDTO() { Nombre = "Genero Editado" };

            var contexto2 = ConstruirContext(nombreDB);

            var controller = new GenerosController(contexto2, mapper);

            //Ejecucion
            await controller.Put(1, generoParaEditar);

            var busquedaGenero = await contexto2.Generos.AnyAsync(x => x.Nombre == generoParaEditar.Nombre);

            //Verificacion
            Assert.IsTrue(busquedaGenero);
        }

        [TestMethod]
        public async Task EliminarUnGeneroDelete()
        {            
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            contexto.Generos.Add(new Genero() { Nombre = "Genero para borrar" });
            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);            

            var controller = new GenerosController(contexto2, mapper);

         
            var busquedaGenero = await contexto2.Generos.AnyAsync(x => x.Nombre == "Genero para borrar");
           
            Assert.IsTrue(busquedaGenero);

            await controller.Delete(1);

            var contexto3 = ConstruirContext(nombreDB);

            var busquedaGenero2 = await contexto3.Generos.AnyAsync(x => x.Nombre == "Genero para borrar");

            Assert.IsFalse(busquedaGenero2);
        }
    }
}
