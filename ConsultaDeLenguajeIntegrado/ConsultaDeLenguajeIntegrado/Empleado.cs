using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDeLenguajeIntegrado
{
    internal class Empleado
    {

        public int idEmpleado { get; set; }
        public int idModalidad { get; set; }
        public string nombre { get; set; }
        
    }

    class Empleadoas : Empleado {
        
        public int idSexo { get; set; }

    }
}
