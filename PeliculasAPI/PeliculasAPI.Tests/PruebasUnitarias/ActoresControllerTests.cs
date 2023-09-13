using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class ActoresControllerTests : BasePruebas
    {

        [TestMethod]
        public async Task GetPaginado()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            contexto.Actores.Add(new Actor() { Nombre = "Paul Walker" });
            contexto.Actores.Add(new Actor() { Nombre = "Vin Diesel" });
            contexto.Actores.Add(new Actor() { Nombre = "Keanu Reeves" });
            contexto.Actores.Add(new Actor() { Nombre = "Norman Reedus" });

            await contexto.SaveChangesAsync();  

            //ejecucion
            var contexto2 = ConstruirContext(nombreDB);
            var controller = new ActoresController(contexto2, mapper, almacenadorArchivos:null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var pagina1 = await controller.Get(new PaginacionDTO() { Pagina = 1, RecordsPorPagina = 3 });
            var totalRegistrosEnPagina = pagina1.Value;

            //Verificacion
            Assert.AreEqual(3, totalRegistrosEnPagina.Count);
        }

        [TestMethod]
        public async Task CrearActorSinFoto()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();
            string nombreActor = "Paul Walker";

            //Creacion del mock para el uso de IAlmacenadorArchivos
            var mock = new Mock<IAlmacenadorArchivos>();
            mock.Setup(x => x.GuardarArchivo(null, null, null, null)).Returns(Task.FromResult("url_img"));

            //rellenado de parametros (IAlmacenadorArchivos) mediante un mock.
            var controller = new ActoresController(contexto, mapper, mock.Object);

            var respuesta = await controller.Post(new ActorCreacionDTO() { Nombre = nombreActor });
            var resultado = respuesta as CreatedAtRouteResult;

            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);
            var existe = await contexto2.Actores.AnyAsync(x=>x.Nombre == "Paul Walker");

            Assert.IsTrue(existe); //Comprueba si existe el actor creado, en la base de datos
            Assert.AreEqual(201, resultado.StatusCode);//comprueba si la respuesta es 201 Created
            Assert.AreEqual(0, mock.Invocations.Count);//comprueba si las invocaciones del mock, son 0
        }

        [TestMethod]
        public async Task CrearActorConFoto()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();
            string nombreActor = "Paul Walker";


            var content = Encoding.UTF8.GetBytes("Imagen de prueba");
            var archivo = new FormFile(new MemoryStream(content), 0, content.Length, "Data", "imagen.jpg");
            archivo.Headers = new HeaderDictionary();

            var actor = new ActorCreacionDTO(){
                Nombre = nombreActor,
                FechaNacimiento = DateTime.Now,
                Foto = archivo
            };

            //Creacion del mock para el uso de IAlmacenadorArchivos
            var mock = new Mock<IAlmacenadorArchivos>();
            mock.Setup(x => x.GuardarArchivo(content,".jpg","actores",archivo.ContentType))
                .Returns(Task.FromResult("url_img"));

            //rellenado de parametros (IAlmacenadorArchivos) mediante un mock.
            var controller = new ActoresController(contexto, mapper, mock.Object);

            var respuesta = await controller.Post(actor);

            var resultado = respuesta as CreatedAtRouteResult;

            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);
            var existe = await contexto2.Actores.ToListAsync();

            Assert.AreEqual(201, resultado.StatusCode);//comprueba si la respuesta es 201 Created
            Assert.IsTrue(existe.Count == 1); //Comprueba si existe el actor creado, en la base de datos
            Assert.AreEqual(1, mock.Invocations.Count);//comprueba si las invocaciones del mock, son 0
            Assert.AreEqual("url_img", existe[0].Foto);            
        }

        [TestMethod]
        public async Task PatchRetorna404()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var controller = new ActoresController(contexto, mapper, null);
            var patchDocument = new JsonPatchDocument<ActorPatchDTO>();

            var respuesta = await controller.Patch(1, patchDocument);
            var resultado = respuesta as StatusCodeResult;

            Assert.AreEqual(404,resultado.StatusCode);
        }

        [TestMethod]
        public async Task PatchActor()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();
            string nombreActor = "Paul Walker";
            string nombrePatch = "Paul William Walker IV";

            contexto.Actores.Add(new Actor() { Nombre = nombreActor });
            await contexto.SaveChangesAsync();

            var ActorDB = await contexto.Actores.FirstOrDefaultAsync(x=>x.Id == 1);

            Assert.AreEqual(nombreActor, ActorDB.Nombre);

            var contexto2 = ConstruirContext(nombreDB);
            var controller = new ActoresController(contexto, mapper, null);

            var objectValidator = new Mock<IObjectModelValidator>();//validacion necesaria para realizar el patch
            objectValidator
                .Setup(x => x.Validate(
                    It.IsAny<ActionContext>(),
                    It.IsAny<ValidationStateDictionary>(),
                    It.IsAny<string>(),
                    It.IsAny<object>()));

            controller.ObjectValidator = objectValidator.Object;//aplicacion de la validacion

            var patchDocument = new JsonPatchDocument<ActorPatchDTO>();
            patchDocument.Operations.Add(new Operation<ActorPatchDTO>("replace","/nombre",null, nombrePatch));

            var respuesta = await controller.Patch(1, patchDocument);
            var resultado = respuesta as StatusCodeResult;

            var ActoresDB = await contexto2.Actores.ToListAsync();
            
            Assert.AreEqual(204, resultado.StatusCode);            
            Assert.AreEqual(nombrePatch, ActoresDB[0].Nombre);
        }
    }
}
