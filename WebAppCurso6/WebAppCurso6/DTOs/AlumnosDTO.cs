using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCurso6.DTOs
{
    public class AlumnosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string FotoNombre { get; set; }
        public string Extension { get; set; }
        public byte[] FotoBytes { get; set; }
        public string CadenaDeFoto { get; set; }
        public string SexoId { get; set; }
        public string TelefonoPadre { get; set; }
        public string TelefonoMadre { get; set; }
        public int NumeroHermanos { get; set; }
        public string bTieneUsuario { get; set; }
    }    
}