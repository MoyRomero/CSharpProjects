using AutoMapper;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using WebAppCurso6.Utilidades;
using WebAppCurso6.Models;

namespace WebAppCurso6
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configurar Autofac
            var builder = new ContainerBuilder();

            // Registrar los controladores de MVC
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Registrar los tipos de servicios que deseas inyectar
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // Configurar AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
            });
            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();

            // Construir el contenedor Autofac
            var container = builder.Build();

            // Configurar Autofac como el contenedor de dependencias para MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Registrar las áreas y rutas
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}