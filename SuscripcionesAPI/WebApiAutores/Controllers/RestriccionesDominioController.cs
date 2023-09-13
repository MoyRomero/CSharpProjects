using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/restriccionesdominio")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RestriccionesDominioController : CustomBaseController
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public RestriccionesDominioController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CrearRestriccionesDominioDTO restriccionDomDTO)
        {
            var llaveBD = await context.LlavesAPI.FirstOrDefaultAsync(x => x.Id == restriccionDomDTO.LlaveId);

            if (llaveBD == null) return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if (llaveBD.UsuarioId != usuarioId) return Forbid();

            var restriccionDominio = new RestriccionDominio()
            {
                LlaveId = restriccionDomDTO.LlaveId,
                Dominio = restriccionDomDTO.Dominio
            };

            context.Add(restriccionDominio);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ActualizarRestriccionDominioDTO actualizarDomDTO)
        {
            var restriccionDominioBD = await context.RestriccionesDominio
                .Include(x=>x.Llave)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(restriccionDominioBD  == null) return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if (restriccionDominioBD.Llave.UsuarioId != usuarioId) return Forbid();

            restriccionDominioBD.Dominio = actualizarDomDTO.Dominio;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var restriccionDominioBD = await context.RestriccionesDominio.Include(x=>x.Llave).FirstOrDefaultAsync(x=>x.Id == id);
            
            if (restriccionDominioBD == null) return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if (restriccionDominioBD.Llave.UsuarioId != usuarioId) return Forbid();

            context.Remove(restriccionDominioBD);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}







