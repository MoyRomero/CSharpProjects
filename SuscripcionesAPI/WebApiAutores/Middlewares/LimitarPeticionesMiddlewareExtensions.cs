using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Middlewares
{
    public static class LimitarPeticionesMiddlewareExtensions
    {
        public static IApplicationBuilder UseLimitarPeticiones(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LimitarPeticionesMiddleware>();
        }
    }

    public class LimitarPeticionesMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly IConfiguration configuration;
        private readonly ILogger<LimitarPeticionesMiddleware> logger;

        public LimitarPeticionesMiddleware(RequestDelegate siguiente, IConfiguration configuration, 
            ILogger<LimitarPeticionesMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext HttpContext, AplicationDbContext context)
        {
            //Recuperación de la cantidad de límite de peticiones, del appSettings.json (o development).
            var limitarPeticionesConfiguracion = new LimitarPeticionesConfiguracion();
            configuration.GetRequiredSection("limitarPeticiones").Bind(limitarPeticionesConfiguracion);

            //Recupera la recopilación de links de la lista blanca
            //(links a los cuales no se les toma en cuenta para realizar peticiones).
            var ruta = HttpContext.Request.Path.ToString();
            var EsRutaBlanca = limitarPeticionesConfiguracion.ListaBlancaRutas.Any(x=> ruta.Contains(x));

            //Recuperación de la llave del usuario, del header X-Api-key
            var llaveStringValues = HttpContext.Request.Headers["X-Api-key"];

            if (EsRutaBlanca)
            {
                await siguiente(HttpContext);
                return;
            }

            if(llaveStringValues.Count == 0) //Comprobación de si el usuario incluye una llave en el header
            {
                HttpContext.Response.StatusCode = 400;
                await HttpContext.Response.WriteAsync("Debe proveer la llave en la cabecera X-Api-key");
                return;
            }

            if(llaveStringValues.Count > 1)
            {
                HttpContext.Response.StatusCode = 400;
                await HttpContext.Response.WriteAsync("No puede haber más de 1 llave en la cabecera X-Api-key");
                return;
            }

            var llavHeader = llaveStringValues[0];
            var llaveBD = await context.LlavesAPI
                .Include(x=>x.RestriccionesDominio)
                .Include(x=>x.RestriccionesIP)
                .Include(x=>x.Usuario)
                .FirstOrDefaultAsync(x => x.Llave == llavHeader);

            if(llaveBD == null)
            {
                HttpContext.Response.StatusCode = 400;
                await HttpContext.Response.WriteAsync("La llave proporcionada en la cabecera X-Api-key, no existe.");
                return;
            }

            if(llaveBD.Activa == false)
            {
                HttpContext.Response.StatusCode = 400;
                await HttpContext.Response.WriteAsync("La llave proporcionada, se encuentra en estado \"Inactivo\".");
                return;
            }

            if(llaveBD.TipoLlave == TipoLlave.Gratuita)
            {
                var hoy = DateTime.Today;
                var mañana = hoy.AddDays(1);
                var cantidadPeticionesRealizadasHoy = 
                await context.Peticiones.CountAsync(x=>x.LlaveId == llaveBD.Id && x.FechaPeticion >= hoy && x.FechaPeticion < mañana);

                if(cantidadPeticionesRealizadasHoy >= limitarPeticionesConfiguracion.PeticionesPorDiaGratuito)
                {
                    HttpContext.Response.StatusCode = 429; //Too many requests (demasiadas peticiones).
                    await HttpContext.Response
                        .WriteAsync("Ha excedido la cantidad máxima de peticiones: " +
                        $"({limitarPeticionesConfiguracion.PeticionesPorDiaGratuito} peticiones diarias por suscripción gratuita)." +
                        $" Si desea realizar más peticiones, deberá actualizar a suscripcion profesional.");
                    return;
                }
            }
            else if (llaveBD.Usuario.MalaPaga)
            {//Si llegamos hasta aquí, es porque el usuario es un mala paga
                HttpContext.Response.StatusCode = 400;
                await HttpContext.Response.WriteAsync("El usuario es un mala paga");
                return;
            }

            var superaRestricciones = PeticionSuperaAlgunaDeLasRestricciones(llaveBD, HttpContext);

            if (!superaRestricciones)
            {
                HttpContext.Response.StatusCode = 403;
                await HttpContext.Response.WriteAsync("Dominio o IP no válidos para el envío de la petición.");
                return;
            }

            var peticion = new Peticion() { LlaveId = llaveBD.Id, FechaPeticion = DateTime.UtcNow };
            context.Add( peticion );
            await context.SaveChangesAsync();

            await siguiente(HttpContext);
        }

        private bool PeticionSuperaAlgunaDeLasRestricciones(LlaveAPI llaveAPI, HttpContext httpContext) 
        {
            var hayRestricciones = llaveAPI.RestriccionesDominio.Any() || llaveAPI.RestriccionesIP.Any();

            if (!hayRestricciones) return false;

            var peticionSuperaLasRestriccionesDeDominio =
                PeticionSuperaLasRestriccionesDeDominio(llaveAPI.RestriccionesDominio, httpContext);

            var peticionSuperaLasRestriccionesDeIP = 
                PeticionSuperaLasRestriccionesDeIP(llaveAPI.RestriccionesIP, httpContext);

            return peticionSuperaLasRestriccionesDeDominio || peticionSuperaLasRestriccionesDeIP;
        }

        private bool PeticionSuperaLasRestriccionesDeIP(List<RestriccionIp> restricciones, HttpContext httpContext)
        {
            if (restricciones == null || restricciones.Count == 0) return false;

            //Linea para recuperar la IP Actual
            var IP = httpContext.Connection.RemoteIpAddress.ToString();

            if(IP == string.Empty) return false;

            var superaRestriccion = restricciones.Any(x=>x.IP == IP);

            return superaRestriccion;
        }

        private bool PeticionSuperaLasRestriccionesDeDominio(List<RestriccionDominio> restricciones, HttpContext httpContext)
        {
            if(restricciones == null || restricciones.Count == 0) return false;

            var referer = httpContext.Request.Headers["Referer"].ToString();

            logger.LogInformation("EL REFER ES: -------------" + referer + "----------------");

            if (referer == string.Empty) return false;

            Uri myUri = new Uri(referer);
            string host = myUri.Host;

            logger.LogInformation("EL HOST ES: -------------" + host + "----------------");

            var superaRestriccion = restricciones.Any(x => x.Dominio == host);
            
            return superaRestriccion;
        }
    }
}
