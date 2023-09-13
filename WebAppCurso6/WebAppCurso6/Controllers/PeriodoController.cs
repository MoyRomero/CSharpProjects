using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppCurso6.DTOs;

namespace WebAppCurso6.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeriodoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: Periodo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var periodos = await context.Periodos.Where(x=>x.Bhabilitado == true).ToListAsync();

            if(periodos == null)
                return Json("No se encontraron resultados",JsonRequestBehavior.AllowGet);

            var periodosDTO = mapper.Map<List<PeriodoDTO>>(periodos); 

            return Json(periodosDTO,JsonRequestBehavior.AllowGet);
        }
    }
}