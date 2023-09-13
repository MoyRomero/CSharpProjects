using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class TIPOHABITACION_BL
    {
        public List<CTIPOHABITACION> Get()
        {
            TIPOHABITACION_DAL TipoHabitacionDal = new TIPOHABITACION_DAL();
            return TipoHabitacionDal.Get();
        }
        
        public List<CTIPOHABITACION> SensitiveGet(string texto)
        {
            TIPOHABITACION_DAL TipoHabitacionDal = new TIPOHABITACION_DAL();
            return TipoHabitacionDal.SensitiveGet(texto);
        }
    }
}
