using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Models;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    [Access]
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            List<CROL> ListaRol = null;

            using(var BD = new BDPasajeEntities())
            {
                ListaRol = (from r in BD.Rol
                            where r.BHABILITADO == 1
                            select new CROL
                            {
                                IDRol = r.IIDROL,
                                NOMBRE = r.NOMBRE,
                                Descripcion = r.DESCRIPCION
                            }).ToList(); 
            }

            return View(ListaRol);
        }
        public ActionResult Filtro(string Nombre) {

            List<CROL> ListaRol = null;

            using (var BD = new BDPasajeEntities())
            {                
                    ListaRol = (from r in BD.Rol
                                where r.BHABILITADO == 1
                                select new CROL
                                {
                                    IDRol = r.IIDROL,
                                    NOMBRE = r.NOMBRE,
                                    Descripcion = r.DESCRIPCION
                                }).ToList();

                if (Nombre != null)
                {
                    ListaRol = (from r in BD.Rol
                                where r.BHABILITADO == 1 &&
                                r.NOMBRE.Contains(Nombre)
                                select new CROL
                                {
                                    IDRol = r.IIDROL,
                                    NOMBRE = r.NOMBRE,
                                    Descripcion = r.DESCRIPCION
                                }).ToList();
                }
            }
            return PartialView("_TablaRol", ListaRol);
        }
        public string Guardar (CROL oRol, int Puente)
        {
            string Respuesta = "";

            if(!ModelState.IsValid)
            {
                var consulta = (from es in ModelState.Values
                                from er in es.Errors
                                select er.ErrorMessage).ToList();
                
                Respuesta += "<ul class=\"FormularioUl\">";

                foreach(var er in consulta) Respuesta += "<li class=\"FormularioLi\">" + er + "</li>";

                Respuesta += "</ul>";

                return Respuesta;
            }
            else
            {
                using (var BD = new BDPasajeEntities())
                {
                    string NombreRol = oRol.NOMBRE;
                    int Repetido = 0;

                    if (Puente == -1)
                    {
                        Repetido = (from r in BD.Rol
                                    where r.NOMBRE == NombreRol
                                    select r).Count();

                        if (Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\"> El Rol: {NombreRol}, ya existe en la base de datos </li> </ul>";

                            return Respuesta;
                        }

                        Rol rol = new Rol();

                        rol.NOMBRE = oRol.NOMBRE;
                        rol.DESCRIPCION = oRol.Descripcion;
                        rol.BHABILITADO = 1;

                        BD.Rol.Add(rol);
                        Respuesta = BD.SaveChanges().ToString();
                        if (Respuesta == "0") Respuesta = "";
                    }
                    else
                    {
                        Repetido = (from r in BD.Rol
                                    where r.NOMBRE == NombreRol &&
                                    r.IIDROL != Puente
                                    select r).Count();

                        if (Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\"> El nombre de Rol: {NombreRol}, ya está asignado a otro Rol.</li> </ul>";

                            return Respuesta;
                        }

                        Rol rol = (from r in BD.Rol
                                   where r.IIDROL == Puente
                                   select r).First();

                        rol.NOMBRE = oRol.NOMBRE;
                        rol.DESCRIPCION = oRol.Descripcion;

                        Respuesta = BD.SaveChanges().ToString();
                    }
                }
            }

            return Respuesta;
        }
        public string Eliminar(CROL oRol)
        {
            int idElemento = oRol.IDRol;
            string respuesta = "";

            using (var BD = new BDPasajeEntities())
            {
                if (idElemento > 0)
                {
                    Rol R = (from r in BD.Rol
                                    where r.IIDROL == idElemento
                                    select r).First();
                    R.BHABILITADO = 0;

                    respuesta = BD.SaveChanges().ToString();
                    if (respuesta == "0") respuesta = "";
                }
            }
            return respuesta;
        }
        public JsonResult CapturarDatos(int Puente)
        {
            CROL ROL = new CROL();
            using (var BD = new BDPasajeEntities())
            {
                Rol rol = (from r in BD.Rol
                           where r.IIDROL == Puente
                           select r).First();

                ROL.IDRol = rol.IIDROL;
                ROL.NOMBRE = rol.NOMBRE;
                ROL.Descripcion = rol.DESCRIPCION;
            }

                return Json(ROL,JsonRequestBehavior.AllowGet);
        }
    }
}