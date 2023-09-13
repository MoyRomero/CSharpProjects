using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class MARCA_BL
    {
        public List<CMARCA> Get()
        {
            MARCA_DAL ListaMarcas = new MARCA_DAL();
            
            return ListaMarcas.Get();
        }
    }
}
