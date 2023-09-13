using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Servicios;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController: CustomBaseController
    {
        private readonly AplicationDbContext BD;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "actores";

        public ActoresController(AplicationDbContext bd, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
            :base(bd, mapper)
        {
            this.BD = bd;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            return await Get<Actor,ActorDTO>(paginacionDTO);
        }

        [HttpGet("{id:int}", Name ="obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id, [FromBody] ActorDTO actorDTO)
        {
            return await Get <Actor,ActorDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            if(await BD.Actores.AnyAsync(x=>x.Nombre ==  actorCreacionDTO.Nombre))
                return BadRequest($"Ya existe un actor con el nombre {actorCreacionDTO.Nombre}, registrado en la base de datos"); 

            var actor = mapper.Map<Actor>(actorCreacionDTO);

            //Envío de foto hacia AzureStorage
            if (actorCreacionDTO.Foto != null)
            {
                using (var MS = new MemoryStream())
                {

                    await actorCreacionDTO.Foto.CopyToAsync(MS);
                    var contenido = MS.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    
                    actor.Foto = 
                        await almacenadorArchivos.GuardarArchivo(
                            contenido, extension, contenedor, actorCreacionDTO.Foto.ContentType);
                }
            }

            BD.Actores.Add(actor);

            await BD.SaveChangesAsync();

            var actorDTO = mapper.Map<ActorDTO>(actor);
            
            return new CreatedAtRouteResult("obtenerActor",new {id = actorDTO.Id}, actorDTO);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreacionDTO actorCreacionDTO)
        { 
            var actorDB = BD.Actores.FirstOrDefault(x=>x.Id == id);
            
            if (actorDB == null) return NotFound($"No existe el actor con el id: {id}");

            actorDB = mapper.Map(actorCreacionDTO, actorDB);

            //Envío de foto hacia AzureStorage
            if (actorCreacionDTO.Foto != null)
            {
                using (var MS = new MemoryStream())
                {

                    await actorCreacionDTO.Foto.CopyToAsync(MS);
                    var contenido = MS.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);

                    actorDB.Foto =
                        await almacenadorArchivos.EditarArchivo(
                            contenido, extension, contenedor,actorDB.Foto, actorCreacionDTO.Foto.ContentType);
                }
            }

            await BD.SaveChangesAsync();    

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ActorPatchDTO> patchDocument)
        {
            return await Patch<Actor,ActorPatchDTO>(id, patchDocument);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Actor>(id);
        }
    }
}
