using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_3Capas.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            TIPOHABITACION_BL ListaTipoHabitacionBL = new TIPOHABITACION_BL();

            List<CTIPOHABITACION> ListaTipoHabitacion = ListaTipoHabitacionBL.Get();

            return Json(ListaTipoHabitacion,JsonRequestBehavior.AllowGet);
        }

        public JsonResult SensitiveGet(string texto)
        {
            TIPOHABITACION_BL ListaTipoHabitacionBL = new TIPOHABITACION_BL();
            List<CTIPOHABITACION> ListaTipoHabitacion = ListaTipoHabitacionBL.SensitiveGet(texto);

            return Json(ListaTipoHabitacion, JsonRequestBehavior.AllowGet);
        }
    }
}