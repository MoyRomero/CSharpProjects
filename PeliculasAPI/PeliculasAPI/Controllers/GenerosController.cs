using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : CustomBaseController
    {
        //private readonly AplicationDbContext BD;
        //private readonly IMapper mapper;

        public GenerosController(AplicationDbContext bD, IMapper mapper) : base(bD, mapper)
        {            
           //BD = bD;
           //this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            return await Get<Genero, GeneroDTO>();

            //var genero = await BD.Generos.ToListAsync();
            //return mapper.Map<List<GeneroDTO>>(genero);
        }

        [HttpGet("{id:int}", Name ="obtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            return await Get<Genero, GeneroDTO>(id);

            //var genero = await BD.Generos.FirstOrDefaultAsync(x=>x.Id == id);
            //if(genero == null) 
            //    return NotFound($"No se encontró el genero buscado por el id: {id}");
            //return mapper.Map<GeneroDTO>(genero);;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Post<GeneroCreacionDTO, Genero, GeneroDTO>(generoCreacionDTO, "obtenerGenero");

            //if (await BD.Generos.AnyAsync(x => x.Nombre == generoCreacionDTO.Nombre)) 
            //    return BadRequest($"El género: {generoCreacionDTO.Nombre} ya se existe en la base de datos.");
            //var genero = mapper.Map<Genero>(generoCreacionDTO);
            //BD.Add(genero);
            //await BD.SaveChangesAsync();
            //var generoDTO = mapper.Map<GeneroDTO>(genero);
            //return new CreatedAtRouteResult("obtenerGenero", new {id = generoDTO.Id}, generoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);

            //if (await BD.Generos.FirstOrDefaultAsync(x => x.Id == id) == null) return NotFound($"No existe un género con el id: {id}");
            //var genero = mapper.Map<Genero>(generoCreacionDTO);            
            //genero.Id = id;
            //BD.Entry(genero).State = EntityState.Modified;
            //await BD.SaveChangesAsync();
            //return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Genero>(id);
            //var generoExiste = await BD.Generos.AnyAsync(x => x.Id == id);
            //if (!generoExiste) return NotFound($"No se encontró el genero con el id: {id}");
            //BD.Remove(new Genero() { Id = id});
            //await BD.SaveChangesAsync();
            //return NoContent();
        }
    }
}
