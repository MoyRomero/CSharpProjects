using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Models;
using AppWebMVC.Filters;



namespace AppWebMVC.Controllers
{
    [Access]
    public class PaginaController : Controller
    {
        // GET: Pagina
        public ActionResult Index()
        {
            List<CPAGINA> ListaPag = null;

            using(var BD = new BDPasajeEntities())
            {
                ListaPag = (from p in BD.Pagina
                            where p.BHABILITADO == 1
                            select new CPAGINA
                            {
                                IDPagina = p.IIDPAGINA,
                                Mensaje = p.MENSAJE,
                                Accion = p.ACCION,
                                Controlador = p.CONTROLADOR

                            }).ToList();
            }

            return View(ListaPag);
        }
        public ActionResult Filtro(string MensajeFiltro)
        {
            List<CPAGINA> ListaPag = new List<CPAGINA>();

            using (var BD = new BDPasajeEntities())
            {
                if (MensajeFiltro == null)
                {               
                    ListaPag = (from p in BD.Pagina
                                where p.BHABILITADO == 1
                                select new CPAGINA
                                {
                                    IDPagina = p.IIDPAGINA,
                                    Mensaje = p.MENSAJE,
                                    Accion = p.ACCION,
                                    Controlador = p.CONTROLADOR

                                }).ToList();
                }
                else
                {
                    ListaPag = (from p in BD.Pagina
                                where p.BHABILITADO == 1
                                && p.MENSAJE.Contains(MensajeFiltro)
                                select new CPAGINA
                                {
                                    IDPagina = p.IIDPAGINA,
                                    Mensaje = p.MENSAJE,
                                    Accion = p.ACCION,
                                    Controlador = p.CONTROLADOR

                                }).ToList();
                }
            }
            return PartialView("_TablaPaginas",ListaPag);
        }
        public string Guardar(CPAGINA oPag, int Confirmar)
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

                    if (Confirmar == -1)
                    {
                        Repetido = (from r in BD.Pagina 
                                    where r.MENSAJE == oPag.Mensaje
                                    select r).Count();
                        if(Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\"> El Mensaje: {oPag.Mensaje}, ya se encuentra asignado a una Página.</li> </ul>";

                            return Respuesta;                        
                        }

                        Pagina Pag = new Pagina();

                        Pag.MENSAJE = oPag.Mensaje;
                        Pag.ACCION = oPag.Accion;
                        Pag.CONTROLADOR = oPag.Controlador;
                        Pag.BHABILITADO = 1;

                        BD.Pagina.Add(Pag);
                        Respuesta = BD.SaveChanges().ToString();
                        if (Respuesta == "0") Respuesta = "";

                    }
                    else
                    {
                        Repetido = (from r in BD.Pagina
                                    where r.MENSAJE == oPag.Mensaje
                                    && r.IIDPAGINA != Confirmar
                                    select r).Count();
                        if (Repetido > 0)
                        {
                            Respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\"> El Mensaje: {oPag.Mensaje}, ya se encuentra asignado a una Página.</li> </ul>";

                            return Respuesta;
                        }

                        Pagina Pag = (from p in BD.Pagina
                                        where p.IIDPAGINA == Confirmar
                                        select p).First();                        

                            Pag.MENSAJE = oPag.Mensaje;
                            Pag.ACCION = oPag.Accion;
                            Pag.CONTROLADOR = oPag.Controlador;

                        Respuesta = BD.SaveChanges().ToString();
                    }                    
                }
            }

            return Respuesta;
        }
        public string Eliminar(CPAGINA oP)
        {
            int idElemento = oP.IDPagina;
            string respuesta = "";

            using (var BD = new BDPasajeEntities())
            {
                if (idElemento > 0)
                {
                    Pagina RP = (from rp in BD.Pagina
                                    where rp.IIDPAGINA == idElemento
                                    select rp).First();
                    RP.BHABILITADO = 0;

                    respuesta = BD.SaveChanges().ToString();
                    if (respuesta == "0") respuesta = "";
                }
            }
            return respuesta;
        }
        public JsonResult CapturarDatos(int Confirmar)
        {
            CPAGINA PAG = new CPAGINA();

            using (var BD = new BDPasajeEntities())
            {
                Pagina Pag = (from p in BD.Pagina
                              where p.IIDPAGINA == Confirmar
                              select p).First();

                PAG.Mensaje = Pag.MENSAJE;
                PAG.Accion = Pag.ACCION;
                PAG.Controlador = Pag.CONTROLADOR;
            }
                return Json(PAG, JsonRequestBehavior.AllowGet);
        }
    }
}