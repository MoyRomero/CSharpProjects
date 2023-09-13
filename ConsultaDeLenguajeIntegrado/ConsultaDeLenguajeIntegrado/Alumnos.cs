using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDeLenguajeIntegrado
{
    internal class Alumnos
    {
        public int idAlumno { get; set; }
        public string nombreCompleto {get; set;} 
        public List<int> notas { get; set; }
        public string cursoFavorito { get; set;}

    }
}
