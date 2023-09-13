using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebAppCurso6.DTOs;
using WebAppCurso6.Models;

namespace WebAppCurso6.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Curso, CursosDTO>();
            
            CreateMap<Periodo, PeriodoDTO>()
                .ForMember(x => x.FechaInicio, op => op.MapFrom(src => ((DateTime)src.FechaInicio).ToShortDateString()))
                .ForMember(x => x.FechaFin, op => op.MapFrom(FormateoFechaFin));

            CreateMap<Alumnos, AlumnosDTO>()
                .ForMember(x => x.FechaNacimiento, op => op.MapFrom(src => ((DateTime)src.FechaNacimiento).ToShortDateString()))
                .ForMember(x => x.bTieneUsuario, op => op.MapFrom(src => src.bTieneUsuario == true ? "Tiene Usuario" : "No tiene usuario"))
                .ForMember(x => x.Extension, op => op.MapFrom(GetFotoExtension))
                .ForMember(x => x.CadenaDeFoto, op => op.MapFrom(GetCadenaDeFoto));
                 

            CreateMap<AlumnoCreacionDTO, Alumnos>();        
        }

        private string GetCadenaDeFoto(Alumnos alumnos, AlumnosDTO alumnosDTO)
        {
            if (alumnos.FotoBytes == null) return "";

            return Convert.ToBase64String(alumnos.FotoBytes);
        }

        private string GetFotoExtension(Alumnos alumnos, AlumnosDTO alumnosDTO)
        {
            if (alumnos.FotoNombre == null) return "";

            return Path.GetExtension(alumnos.FotoNombre);
        }
        

        private string FormateoFechaFin(Periodo periodo, PeriodoDTO periodoDTO)
        {
            return ((DateTime)periodo.FechaFin).ToShortDateString();
        }
    }
}