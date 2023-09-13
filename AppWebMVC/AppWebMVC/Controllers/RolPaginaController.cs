using AppWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    //[Access]
    public class RolPaginaController : Controller
    {
        List<SelectListItem> ListaRol = null;
        List<SelectListItem> ListaPagina = null;
        // GET: RolPagina
        public void RefillListaRol()
        {
            using(var BD = new BDPasajeEntities())
            {
                ListaRol = (from lr in BD.Rol
                            where lr.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Value = lr.IIDROL.ToString(),
                                Text = lr.NOMBRE,
                            }).ToList();
                ListaRol.Insert(0, new SelectListItem { Text = "SELECCIONA UN ROL", Value = "" });

                ListaPagina = (from p in BD.Pagina
                               where p.BHABILITADO == 1
                               select new SelectListItem
                               {
                                   Value = p.IIDPAGINA.ToString(),
                                   Text = p.MENSAJE
                               }).ToList();
                ListaPagina.Insert(0, new SelectListItem { Text = "SELECCIONA UNA PÁGINA", Value = "" });
            }
        }
        public ActionResult Index()
        {
            RefillListaRol();
            ViewBag.listrol = ListaRol;
            ViewBag.listpagina = ListaPagina;

            List<CROLPAGINA> ListaRP = null;

            using(var BD = new BDPasajeEntities())
            {
                ListaRP = (from rp in BD.RolPagina
                           join r in BD.Rol
                           on rp.IIDROL equals r.IIDROL
                           join p in BD.Pagina
                           on rp.IIDPAGINA equals p.IIDPAGINA
                           where rp.BHABILITADO == 1 
                           select new CROLPAGINA
                           {
                               IDRolPagina = rp.IIDROLPAGINA,
                               Rol = r.NOMBRE,
                               Pagina = p.MENSAJE                               
                           }).ToList();
            }

            return View(ListaRP);
        }
        public ActionResult Filtro(int? IDRol)
        {
            List<CROLPAGINA> ListaRP = null;

            using (var BD = new BDPasajeEntities())
            {
                if (IDRol == null)
                {
                    ListaRP = (from rp in BD.RolPagina
                               join r in BD.Rol
                               on rp.IIDROL equals r.IIDROL
                               join p in BD.Pagina
                               on rp.IIDPAGINA equals p.IIDPAGINA
                               where rp.BHABILITADO == 1
                               select new CROLPAGINA
                               {
                                   IDRolPagina = rp.IIDROLPAGINA,
                                   Rol = r.NOMBRE,
                                   Pagina = p.MENSAJE
                               }).ToList();
                }
                else 
                {                 
                    ListaRP = (from rp in BD.RolPagina
                               join r in BD.Rol
                               on rp.IIDROL equals r.IIDROL
                               join p in BD.Pagina
                               on rp.IIDPAGINA equals p.IIDPAGINA
                               where rp.BHABILITADO == 1 
                               && r.IIDROL == IDRol
                               select new CROLPAGINA
                               {
                                   IDRolPagina = rp.IIDROLPAGINA,
                                   Rol = r.NOMBRE,
                                   Pagina = p.MENSAJE
                               }).ToList();
                }
            }

            return PartialView("_TablaRolPagina",ListaRP);
        }
        public string Guardar(CROLPAGINA oRolPag, int Confirmacion, string Rol, string Pagina)
        {
            string Respuesta = "";

            if (!ModelState.IsValid)
            {
                var consulta = (from es in ModelState.Values
                                from er in es.Errors
                                select er.ErrorMessage).ToList();

                Respuesta += "<ul class=\"FormularioUl\">";

                foreach (var er in consulta) Respuesta += "<li class=\"FormularioLi\">" + er + "</li>";

                Respuesta += "</ul>";

                return Respuesta;
            }
            else
            {
                using (var BD = new BDPasajeEntities())
                {
                    int Repetido = 0;                    

                    if (Confirmacion == -1)
                    {
                        Repetido = (from r in BD.RolPagina
                                    where r.IIDROL == oRolPag.IDRol && r.IIDPAGINA == oRolPag.IDPagina
                                    select r).Count();

                        if (Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\">Ya existe un permiso ( {Rol} / {Pagina} ) en la base de datos.</li> </ul>";

                            return Respuesta;
                        }

                        RolPagina RP = new RolPagina();

                        RP.IIDROL = oRolPag.IDRol;
                        RP.IIDPAGINA = oRolPag.IDPagina;
                        RP.BHABILITADO = 1;

                        BD.RolPagina.Add(RP);
                        Respuesta = BD.SaveChanges().ToString();
                        if (Respuesta == "0") Respuesta = "";
                    
                    }
                    else
                    {
                        Repetido = (from r in BD.RolPagina
                                    where r.IIDROLPAGINA != Confirmacion
                                    && r.IIDROL == oRolPag.IDRol 
                                    && r.IIDPAGINA == oRolPag.IDPagina
                                    select r).Count();

                        if (Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\">Ya existe un permiso ( {Rol} / {Pagina} ) en la base de datos.</li> </ul>";

                            return Respuesta;
                        }

                        RolPagina RP = (from rp in BD.RolPagina
                                        where rp.IIDROLPAGINA == Confirmacion
                                        select rp).First();

                        RP.IIDROL = (int)oRolPag.IDRol;
                        RP.IIDPAGINA = (int)oRolPag.IDPagina;
                        
                        Respuesta = BD.SaveChanges().ToString();
                    }
                };
            }

            return Respuesta;
        }
        public string Eliminar(CROLPAGINA oRP)
        {
            int idElemento = oRP.IDRolPagina;
            string respuesta = "";

            using(var BD = new BDPasajeEntities())
            {
                if(idElemento > 0)
                {
                    RolPagina RP = (from rp in BD.RolPagina
                                    where rp.IIDROLPAGINA == idElemento
                                    select rp).First();
                    RP.BHABILITADO = 0;

                    respuesta = BD.SaveChanges().ToString();
                    if (respuesta == "0") respuesta = "";
                }
            }
            return respuesta;
        }
        public JsonResult CapturarDatos(int Confirmacion)
        {
            CROLPAGINA oRP = new CROLPAGINA();

            using(var BD = new BDPasajeEntities())
            {

                RolPagina RP = (from rp in BD.RolPagina
                                where rp.IIDROLPAGINA == Confirmacion
                                select rp).First();

                oRP.IDRol = (int) RP.IIDROL;
                oRP.IDPagina = (int)RP.IIDPAGINA;
            }

            return Json(oRP,JsonRequestBehavior.AllowGet);
        }
    }
}