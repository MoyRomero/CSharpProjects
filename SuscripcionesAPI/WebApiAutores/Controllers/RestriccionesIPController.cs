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
    [Route("api/restriccionesip")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RestriccionesIPController:CustomBaseController
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public RestriccionesIPController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CrearRestriccionesIPDTO iPDTO) 
        {
            var llaveBD = await context.LlavesAPI.FirstOrDefaultAsync(x => x.Id == iPDTO.LlaveId);
            if (llaveBD == null) return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if (llaveBD.UsuarioId != usuarioId) return Forbid();

            var restriccionIp = new RestriccionIp()
            {
                LlaveId = llaveBD.Id,
                IP = iPDTO.IP
            };

            context.Add(restriccionIp);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ActualizarRestriccionIPDTO iPDTO)
        {
            var restriccionIpBD = await context.RestriccionesIp.Include(x=>x.Llave).FirstOrDefaultAsync(x => x.Id == id);
            if (restriccionIpBD == null) 
                return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if(usuarioId != restriccionIpBD.Llave.UsuarioId) 
                return Forbid();

            restriccionIpBD.IP = iPDTO.IP;

            await context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var restriccionIpBD = await context.RestriccionesIp.Include(x => x.Llave).FirstOrDefaultAsync(x => x.Id == id);
            if (restriccionIpBD == null)
                return NotFound();

            var usuarioId = ObtenerUsuarioId();

            if (usuarioId != restriccionIpBD.Llave.UsuarioId)
                return Forbid();

            context.Remove(restriccionIpBD);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}




