using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppCurso6.DTOs;
using WebAppCurso6.Models;

namespace WebAppCurso6.Controllers
{    
    public class AlumnoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AlumnoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public async Task<JsonResult> Get()
        {
            var alumnosBD = await context.Alumnos
                .Where(x => x.Bhabilitado == true).ToListAsync();

            try
            {
                if(alumnosBD == null) 
                    return Json("No se encontraron alumnos", JsonRequestBehavior.AllowGet);

                var alumnosDTO = mapper.Map<List<AlumnosDTO>>(alumnosBD);

                return Json(alumnosDTO, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("Error en la compilación del endpoint Get (select): " + ex.Message);
            }
        }

        //[HttpGet]
        public async Task<JsonResult> GetId(int id)
        {
            var alumnoBD = await context.Alumnos
                .Where(x => x.Bhabilitado == true && x.Id == id).FirstOrDefaultAsync();

            if (alumnoBD == null) 
                return Json($"No se pudo encontrar al alumno con el id: {id}", 
                    JsonRequestBehavior.AllowGet);

            var alumnoDTO = mapper.Map<AlumnosDTO>(alumnoBD);

            return Json(alumnoDTO, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public async Task<ActionResult> Post(AlumnoCreacionDTO alumnoDTO, HttpPostedFileBase Foto)
        {
            string [] respuestas = {"", 
                "Existen campos obligatorios sin rellenar.", 
                "Se ha agregado al alumno, de forma correcta" };

            if (!ModelState.IsValid || Foto == null)
            {
               respuestas[0] = ModelStateValidation(respuestas[0], Foto);

               return Json(respuestas);
            }

            var existe = await context.Alumnos
                .Where(x=>x.Nombre == alumnoDTO.Nombre
                && x.ApPaterno == alumnoDTO.ApPaterno 
                && x.ApMaterno == alumnoDTO.ApMaterno)
                .AnyAsync();

            if (existe) return
                 Json("El alumno con el nombre " + 
                 alumnoDTO.Nombre + " " 
                 + alumnoDTO.ApPaterno + " " 
                 + alumnoDTO.ApMaterno + 
                 " ya se encuentra registrado en la base de datos");

            var alumnoNuevo = mapper.Map<Alumnos>(alumnoDTO);

            alumnoNuevo.FotoBytes = FotoBytes(Foto);
            alumnoNuevo.Bhabilitado = true;

            context.Alumnos.Add(alumnoNuevo);
            await context.SaveChangesAsync();

            return Json(respuestas);
        }

        //[HttpPut]
        public async Task<ActionResult> Put(int id, AlumnoCreacionDTO alumnoDTO, HttpPostedFileBase Foto)
        {
            string[] respuestas = {"",
                "Existen campos obligatorios sin rellenar.",
                "Se ha actualizado al alumno, de forma correcta" };

            if (!ModelState.IsValid || Foto == null)
            {
                respuestas[0] = ModelStateValidation(respuestas[0], Foto);

                return Json(respuestas);
            }

            try
            {
                var alumnoBD = await context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);

                if (alumnoBD == null) return Json(respuestas);

                mapper.Map(alumnoDTO, alumnoBD);

                alumnoBD.FotoBytes = FotoBytes(Foto);

                await context.SaveChangesAsync();

                return Json(respuestas);
            }
            catch (Exception ex)
            {
                respuestas[0] = ex.Message.ToString();
                return Json(respuestas);
            }
        }

        //[HttpDelete]
        public async Task<ActionResult> Delete(AlumnosDTO alumnosDTO)
        {
            int id = alumnosDTO.Id;
            var alumnoBD = await context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                if (alumnoBD == null)
                    return Json($"No se encontró el alumno con el ID: {id}");

                alumnoBD.Bhabilitado = false;
                await context.SaveChangesAsync();

                return Json("Se eliminó el alumno, de forma correcta");
            }
            catch(Exception ex)
            {

                return Json("Error en la compilación del endpoint Delete: " + ex.Message);
            }
        }

        private string ModelStateValidation(string respuesta, HttpPostedFileBase Foto)
        {
            var ConsultaErrores = (from estado in ModelState.Values
                                   from errores in estado.Errors
                                   select errores.ErrorMessage).ToList();

            respuesta += "<ul class=\"UlErrores\">";

            if (Foto == null)
            {
                respuesta += $"<li class=\"LiError\"> No se ha cargado una foto. </li>";
            }

            foreach (var error in ConsultaErrores)
                respuesta += $"<li class=\"LiError\"> {error} </li>";

            respuesta += "</ul>";

            return respuesta;
        }

        private byte[] FotoBytes(HttpPostedFileBase Foto)
        {
            byte[] FotoBD;

            BinaryReader Lector = new BinaryReader(Foto.InputStream);
            FotoBD = Lector.ReadBytes((int)Foto.ContentLength);

            return FotoBD;
        }
    }
}