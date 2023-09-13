using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;
using WebApiAutores.Servicios;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/llavesapi")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LlavesAPIController: CustomBaseController
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ServicioLlaves servicioLlaves;

        public LlavesAPIController(AplicationDbContext context,
            IMapper mapper,
            ServicioLlaves servicioLlaves)
        {
            this.context = context;
            this.mapper = mapper;
            this.servicioLlaves = servicioLlaves;
        }

        [HttpGet]
        public async Task<ActionResult<List<LlaveDTO>>> MisLlaves()
        {
            var usuarioId = ObtenerUsuarioId();
            var llaves = await context.LlavesAPI
                .Include(x=>x.RestriccionesIP)
                .Include(x=>x.RestriccionesDominio)
                .Where(x => x.UsuarioId == usuarioId).ToListAsync();

            return mapper.Map<List<LlaveDTO>>(llaves);
        }

        [HttpPost]
        public async Task<ActionResult> Post(LlaveCreacionDTO llaveCreacionDTO)
        {
            var usuarioId = ObtenerUsuarioId();

            if(llaveCreacionDTO.TipoLlave == Entidades.TipoLlave.Gratuita)
            {
                var tieneLlaveGratuita = await context.LlavesAPI.
                    Where(x => x.UsuarioId == usuarioId &&
                          x.TipoLlave == Entidades.TipoLlave.Gratuita).AnyAsync();

                if (tieneLlaveGratuita)
                    return BadRequest("Usted ya tiene una llave gratuita.");
            }

            await servicioLlaves.CrearLlave(usuarioId,llaveCreacionDTO.TipoLlave);

            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult> Put(LlaveActualizarDTO llaveActualizarDTO)
        {
            var usuarioId = ObtenerUsuarioId();

            var llaveBD = await context.LlavesAPI.Where(x=>x.Id == llaveActualizarDTO.LlaveId).FirstOrDefaultAsync();

            if (llaveBD == null) return NotFound();

            if (llaveBD.UsuarioId != usuarioId) return Forbid();

            if (llaveActualizarDTO.ActualizarLlave)            
                llaveBD.Llave = servicioLlaves.GenerarLlaveString();

            llaveBD.Activa = llaveActualizarDTO.Activa;
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
