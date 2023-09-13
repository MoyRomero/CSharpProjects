using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppCurso6.Models
{
    [Table("Periodos")]
    public class Periodo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Bhabilitado { get; set; }
    }
}