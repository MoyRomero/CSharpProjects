using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using PeliculasAPI.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests
{
    public class BasePruebas
    {
        public string usuarioPorDefectoId = "d2e6236b-d008-4065-b5cb-ee516faf5859";
        public string usuarioPorDefectoEmail = "ejemplo@hotmail.com";

        protected AplicationDbContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<AplicationDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var dbContext = new AplicationDbContext(opciones);

            return dbContext;
        }

        protected IMapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(options => {               
                options.AddProfile(new AutoMapperProfiles());
            });

            return config.CreateMapper();
        }

        protected ControllerContext ConstruirControllerContext()
        {
            var usuario = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,usuarioPorDefectoEmail),
                new Claim(ClaimTypes.Email,usuarioPorDefectoEmail),
                new Claim(ClaimTypes.NameIdentifier,usuarioPorDefectoId)
            }));

            return new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = usuario
                }
            };
        }

        protected WebApplicationFactory<Startup> ConstruirWebApplicationFactory(string nombreBD, bool ignorarSeguridad = true)
        {
            var factory = new WebApplicationFactory<Startup>();

            factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var descriptorDBContext = services.SingleOrDefault(d=>
                            d.ServiceType == typeof(DbContextOptions<AplicationDbContext>));
                    
                    if(descriptorDBContext != null) services.Remove(descriptorDBContext);

                    services.AddDbContext<AplicationDbContext>(options=>
                        options.UseInMemoryDatabase(nombreBD));

                    if (ignorarSeguridad)
                    {
                        services.AddSingleton<IAuthorizationHandler,AllowAnonymousHandler>();

                        services.AddControllers(options=>options.Filters.Add(new UsuarioFalsoFiltro()));
                    }
                });
            });
            return factory;
        }
    }
}
