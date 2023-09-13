using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Servicios;
using System.Net.Security;
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI
{
    public class Startup
    {
        public Startup( IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>();
            services.AddHttpContextAccessor();
            
            services.AddControllers(opciones => opciones.Filters.Add(typeof(FiltroDeExcepcion))).AddNewtonsoftJson();
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"),
            sqlServerOptions => sqlServerOptions.UseNetTopologySuite()));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero
                });

            services.AddScoped<PeliculaExisteAttribute>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
