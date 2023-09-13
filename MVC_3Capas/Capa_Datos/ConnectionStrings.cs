using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Capa_Datos
{
    public class ConnectionStrings
    {
        public string CadenaConexionLenovo { get; set; }

        public ConnectionStrings()
        {
          CadenaConexionLenovo = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}
