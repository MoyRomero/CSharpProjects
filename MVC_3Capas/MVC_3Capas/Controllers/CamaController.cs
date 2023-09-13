using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_3Capas.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            CAMA_BL ListaCamas = new CAMA_BL();
            
            return Json(ListaCamas.Get(),JsonRequestBehavior.AllowGet);
        }
    }
}