using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_3Capas.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            MARCA_BL ListaMarcas = new MARCA_BL();

            return Json(ListaMarcas.Get(),JsonRequestBehavior.AllowGet);
        }
    }
}