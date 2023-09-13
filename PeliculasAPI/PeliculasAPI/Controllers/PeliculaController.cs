using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Migrations;
using PeliculasAPI.Servicios;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculaController : CustomBaseController
    {
        private readonly AplicationDbContext BD;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "peliculas";

        public PeliculaController(AplicationDbContext bd, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
            :base(bd, mapper)
        {
            this.BD = bd;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<PeliculasIndexDTO>> Get(string titulo)
        {
            int top = 5;
            DateTime hoy = DateTime.Now;

            var proximosEstrenos =
                await BD.Peliculas
                .Where(x => x.FechaEstreno > hoy)
                .OrderBy(x => x.FechaEstreno)
                .Take(top)
                .ToListAsync();

            var enCines = 
                await BD.Peliculas
                .Where(x=>x.EnCines == true)
                .Take(top)
                .ToListAsync();

            var resultado = new PeliculasIndexDTO();
            resultado.ProximosEstrenos = mapper.Map<List<PeliculaDTO>>(proximosEstrenos);
            resultado.EnCines = mapper.Map<List<PeliculaDTO>>(enCines);

            return resultado;
        }

        [HttpGet("{id:int}", Name ="obtenerPelicula")]
        public async Task<ActionResult<PeliculaDetallesDTO>> Get(int id)
        {
            var pelicula = await BD.Peliculas
                .Include(x=>x.PeliculasGeneros).ThenInclude(x=>x.Genero)
                .Include(x=>x.PeliculasActores).ThenInclude(x=>x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(pelicula == null) return NotFound();

            pelicula.PeliculasActores = pelicula.PeliculasActores.OrderBy(x => x.Orden).ToList();

            return mapper.Map<PeliculaDetallesDTO>(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var repetido = await BD.Peliculas.AnyAsync(x => x.Titulo == peliculaCreacionDTO.Titulo);

            if (repetido)
                return BadRequest($"La película {peliculaCreacionDTO.Titulo}, ya se encuentra registrada en la base de datos.");

            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (peliculaCreacionDTO.Poster != null)
            {
                using (var MS = new MemoryStream())
                {
                    await peliculaCreacionDTO.Poster.CopyToAsync(MS);
                    var contenido = MS.ToArray();
                    var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);

                    pelicula.Poster =
                        await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor, peliculaCreacionDTO.Poster.ContentType);
                }
            }

            OrdenamientoActores(pelicula);

            BD.Add(pelicula);
            await BD.SaveChangesAsync();

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            return new CreatedAtRouteResult("obtenerPelicula",new {id = pelicula.Id}, peliculaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var peliculaBD = 
                await BD.Peliculas
                .Include(x=>x.PeliculasActores)
                .Include(x=>x.PeliculasGeneros).FirstOrDefaultAsync(x => x.Id == id);
            if (peliculaBD == null) return BadRequest($"No existe una película con el id: {id}.");

            peliculaBD = mapper.Map(peliculaCreacionDTO, peliculaBD);

            if (peliculaCreacionDTO.Poster != null)
            {
                using (var MS = new MemoryStream())
                {
                    await peliculaCreacionDTO.Poster.CopyToAsync(MS);
                    var contenido = MS.ToArray();
                    var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);

                    peliculaBD.Poster =
                        await almacenadorArchivos
                        .EditarArchivo(contenido, extension, contenedor, peliculaBD.Poster, peliculaCreacionDTO.Poster.ContentType);
                }
            }

            OrdenamientoActores(peliculaBD);

            await BD.SaveChangesAsync();

            var peliculaDTO = mapper.Map<PeliculaDTO>(peliculaBD);

            return new CreatedAtRouteResult("obtenerPelicula", new { id = peliculaBD.Id }, peliculaDTO);
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar([FromQuery] FiltroPeliculasDTO filtroPeliculasDTO)
        {
            var peliculasQueryable = BD.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(filtroPeliculasDTO.Titulo))
                peliculasQueryable = peliculasQueryable.Where(x => x.Titulo.Contains(filtroPeliculasDTO.Titulo));

            if (filtroPeliculasDTO.EnCines)
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCines);

            if (filtroPeliculasDTO.ProximosEstrenos)
                peliculasQueryable = peliculasQueryable.Where(x=>x.FechaEstreno > DateTime.Today);

            if (filtroPeliculasDTO.GeneroId > 0)
                peliculasQueryable = 
                    peliculasQueryable
                    .Where(x => x.PeliculasGeneros.Select(x=>x.GeneroId)
                    .Contains(filtroPeliculasDTO.GeneroId));

            await HttpContext.
                InsertarParametrosPaginacionEnCabecera(peliculasQueryable, 
                filtroPeliculasDTO.CantidadRegistrosPagina, 
                filtroPeliculasDTO.Pagina);

            var peliculas = await peliculasQueryable.Paginar(filtroPeliculasDTO.Paginacion).ToListAsync();

            return mapper.Map<List<PeliculaDTO>>(peliculas);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PeliculaPatchDTO> patchDocument)
        {
            return await Patch<Pelicula, PeliculaPatchDTO>(id, patchDocument);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Pelicula>(id);
        }

        private Pelicula OrdenamientoActores(Pelicula pelicula)
        {
            if (pelicula.PeliculasActores == null) return pelicula;

            for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                pelicula.PeliculasActores[i].Orden = i;

            return pelicula;
        }
    }
}
