using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CAMA_BL
    {
        public List<CCAMA> Get()
        {
            CAMA_DAL ListaCamas = new CAMA_DAL();

            return ListaCamas.Get();
        }
    }
}
