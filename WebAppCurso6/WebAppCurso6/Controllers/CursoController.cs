using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppCurso6.DTOs;
using WebAppCurso6.Models;

namespace WebAppCurso6.Controllers
{
    public class CursoController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public CursoController(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: Curso
        public ActionResult Index()
        {
            ViewBag.mensaje = MensajeDeBienvenida();
            return View();
        }
        public string MensajeDeBienvenida()
        {
            return "Bienvenido a la Web App del Curso 6";
        }
        public string Saludo(string nombre)
        {
            return $"Hola ¿qué tal, {nombre}?";
        }

        [HttpGet]
        public async Task<JsonResult> ListaCursos()
        {
            var cursosDB = await context.Cursos.ToListAsync();
            
            var cursosDTO = mapper.Map<List<CursosDTO>>(cursosDB);

            return Json(cursosDTO, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> BuscarCursoPorNombre(string Nombre)
        {
            var cursoBD = 
                await context.Cursos.Where(x => x.Nombre == Nombre).FirstOrDefaultAsync();
            
            if(cursoBD == null) 
                return Json($"No se encontró el curso {Nombre}", JsonRequestBehavior.AllowGet);

            var cursoDTO = mapper.Map<CursosDTO>(cursoBD);

            return Json(cursoDTO, JsonRequestBehavior.AllowGet);
        }
    }
}