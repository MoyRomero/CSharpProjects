﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/SalasDeCine")]
    public class SalasDeCineController:CustomBaseController
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public SalasDeCineController(AplicationDbContext context, IMapper mapper)
            :base( context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalaDeCineDTO>>> Get()
        {
            return await Get<SalaDeCine, SalaDeCineDTO>();
        }

        [HttpGet("{id:int}", Name ="obtenerSalaDeCine")]
        public async Task<ActionResult<SalaDeCineDTO>>Get(int id)
        {
            return await Get<SalaDeCine,SalaDeCineDTO>(id);
        }

        [HttpGet("Cercanos")]
        public async Task<ActionResult<List<SalaDeCineCercanoDTO>>> Cercanos(
            [FromQuery] SalaDeCineCercanoFiltroDTO filtro)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var ubicacionUsuario = geometryFactory.
                CreatePoint(new NetTopologySuite.Geometries.Coordinate(filtro.Longitud, filtro.Latitud));

            var salasDeCine = await context.SalasDeCine
                              .OrderBy(x=>x.Ubicacion.Distance(ubicacionUsuario))
                              .Where(x=>x.Ubicacion.IsWithinDistance(ubicacionUsuario,filtro.DistanciaEnKms * 1000))
                              .Select(x=> new SalaDeCineCercanoDTO 
                                              {
                                                Id = x.Id,
                                                Nombre = x.Nombre,
                                                Latitud = x.Ubicacion.Y,
                                                Longitud = x.Ubicacion.X,
                                                DistanciaEnMetros = Math.Round(x.Ubicacion.Distance(ubicacionUsuario))
                                                }).ToListAsync();
            
            return salasDeCine;
        }

        [HttpPost]
        public async Task<ActionResult>Post([FromBody] SalaDeCineCreacionDTO salaDeCineCreacionDTO)
        {
            return await Post<SalaDeCineCreacionDTO, SalaDeCine,SalaDeCineDTO>(salaDeCineCreacionDTO, "obtenerSalaDeCine");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult>Put(int id, [FromBody] SalaDeCineCreacionDTO salaDeCineCreacionDTO)
        {
            return await Put<SalaDeCineCreacionDTO,SalaDeCine>(id, salaDeCineCreacionDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<SalaDeCine>(id);    
        }
    }
}
