using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, opciones => opciones.Ignore());
            CreateMap<ActorPatchDTO, Actor>().ReverseMap();

            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(x => x.Poster, opciones => opciones.Ignore())
                .ForMember(x => x.PeliculasGeneros, opciones => opciones.MapFrom(MapPeliculasGeneros))
                .ForMember(x => x.PeliculasActores, opciones => opciones.MapFrom(MapPeliculasActores));
            CreateMap<PeliculaPatchDTO, Pelicula>().ReverseMap();

            CreateMap<Pelicula, PeliculaDetallesDTO>()
                .ForMember(x => x.Generos, opciones => opciones.MapFrom(MapPeliculasDetallesGeneros))
                .ForMember(x => x.Actores, opciones => opciones.MapFrom(MapPeliculasDetallesActores));

            CreateMap<SalaDeCine, SalaDeCineDTO>()
                .ForMember(x => x.Latitud, x => x.MapFrom(y => y.Ubicacion.Y))
                .ForMember(x => x.Longitud, x => x.MapFrom(y => y.Ubicacion.X));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<SalaDeCineDTO, SalaDeCine>()
                .ForMember(x=>x.Ubicacion, x => x.MapFrom(y => geometryFactory
                .CreatePoint(new NetTopologySuite.Geometries.Coordinate(y.Longitud, y.Latitud))));

            CreateMap<SalaDeCineCreacionDTO, SalaDeCine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y => geometryFactory
                .CreatePoint(new NetTopologySuite.Geometries.Coordinate(y.Longitud, y.Latitud))));

            CreateMap<IdentityUser, UsuarioDTO>();

            CreateMap<Review, ReviewDTO>()
                .ForMember(x=>x.NombreUsuario, x=>x.MapFrom(y=>y.Usuario.UserName));
            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewCreacionDTO, Review>();

        }

        private List<ActorPeliculaDetalleDTO> MapPeliculasDetallesActores(Pelicula pelicula, PeliculaDetallesDTO peliculaDetallesDTO)
        {
            var resultado = new List<ActorPeliculaDetalleDTO>();

            if(pelicula.PeliculasActores == null) return resultado;

            foreach (var actorPelicula in pelicula.PeliculasActores)
                resultado.Add(new ActorPeliculaDetalleDTO()
                {
                    ActorId = actorPelicula.ActorId,
                    Personaje = actorPelicula.Personaje,
                    NombrePersona = actorPelicula.Actor.Nombre
                });

            return resultado;
        }
        private List<GeneroDTO> MapPeliculasDetallesGeneros(Pelicula pelicula, PeliculaDetallesDTO peliculaDetallesDTO)
        {
            var resultado = new List<GeneroDTO>();
            
            if (pelicula.PeliculasGeneros == null) return resultado;

            foreach (var generoPelicula in pelicula.PeliculasGeneros)
                resultado.Add(new GeneroDTO() {
                            Id = generoPelicula.GeneroId, 
                            Nombre = generoPelicula.Genero.Nombre 
                        });
            return resultado;
        }
        private List<PeliculasActores> MapPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasActores>();

            if (peliculaCreacionDTO.Actores == null) return resultado;

            foreach (var actor in peliculaCreacionDTO.Actores)
                resultado.Add(new PeliculasActores() { ActorId = actor.ActorId, Personaje = actor.Personaje });

            return resultado;
        }
        private List<PeliculasGeneros> MapPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasGeneros>();

            if (peliculaCreacionDTO.GenerosIDs == null) return resultado;

            foreach(var generoId in peliculaCreacionDTO.GenerosIDs)
                resultado.Add(new PeliculasGeneros() { GeneroId = generoId });

            return resultado;
        }
    }
}
