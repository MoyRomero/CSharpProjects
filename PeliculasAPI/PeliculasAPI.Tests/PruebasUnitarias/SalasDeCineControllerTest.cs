using NetTopologySuite;
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
    public class SalasDeCineControllerTest:BasePruebas
    {
        [TestMethod]
        public async Task CinesCercanosPrueba()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var mapper = ConfigurarAutoMapper();            

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            using(var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var salasDeCine = new List<SalaDeCine>() 
                {                
                    new SalaDeCine()
                    {
                        Nombre = "Cinépolis Pie de la Cuesta Acapulco",
                        Ubicacion = 
                        geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-99.91548934232755, 16.858490375918656))
                    },
                    new SalaDeCine()
                    {
                        Nombre = "Cinépolis Galerías Acapulco",
                        Ubicacion = 
                        geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-99.88151589595894, 16.862065350693676))
                    },
                    new SalaDeCine()
                    {
                        Nombre = "Cinépolis VIP Galerías Diana Acapulco",
                        Ubicacion = 
                        geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-99.87383535797504,16.8603617703274))
                    }
                };
                context.AddRange(salasDeCine);
                await context.SaveChangesAsync();
            }

            var filtro 
                = new SalaDeCineCercanoFiltroDTO()
                {
                    DistanciaEnKms = 7,
                    Latitud = 16.876037655389357,
                    Longitud = -99.90757447622175
                };

            using(var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var controller = new SalasDeCineController(context, mapper);

                var respuesta = await controller.Cercanos(filtro);
                var resultado = respuesta.Value;

                Assert.IsNotNull(resultado);
                Assert.AreEqual(3, resultado.Count);
            }
        }
    }
}
