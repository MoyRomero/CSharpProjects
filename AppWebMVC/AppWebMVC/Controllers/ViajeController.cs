using AppWebMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Filters;

namespace AppWebMVC.Controllers
{
    [Access]
    public class ViajeController : Controller
    {
        List<SelectListItem> LiLugarOrigen;
        List<SelectListItem> LiLugarDestino;
        List<SelectListItem> LiIDBus;

        // GET: Viaje
        public ActionResult Index()
        {
            RefillSelect();
            ViewBag.LilugOrig = LiLugarOrigen;
            ViewBag.LilugDest = LiLugarDestino;
            ViewBag.LiIdBus = LiIDBus;

            List<CVIAJE> lista = new List<CVIAJE>();

            using(var BD = new BDPasajeEntities())
            {
                lista = (from v in BD.Viaje
                         join lugarO in BD.Lugar
                         on v.IIDLUGARORIGEN equals lugarO.IIDLUGAR
                         join lugarD in BD.Lugar
                         on v.IIDLUGARDESTINO equals lugarD.IIDLUGAR
                         join bus in BD.Bus
                         on v.IIDBUS equals bus.IIDBUS
                         where v.BHABILITADO == 1
                         select new CVIAJE
                         {
                             IDViaje = v.IIDVIAJE,
                             LugarOrigen = lugarO.NOMBRE,
                             LugarDestino = lugarD.NOMBRE,
                             IDBus = bus.IIDBUS,
                             Precio = (decimal)v.PRECIO,
                             FechaViaje = (DateTime)v.FECHAVIAJE,
                             NumAsientosDisponibles = (int)v.NUMEROASIENTOSDISPONIBLES
                         }).ToList();
            }

            return View(lista);
        }
        private void RefillSelect()
        {
            using(var BD = new BDPasajeEntities())
            {
                LiLugarOrigen = (from lo in BD.Lugar
                                 where lo.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Value = lo.IIDLUGAR.ToString(),
                                     Text = lo.NOMBRE
                                 }).ToList();
                LiLugarOrigen.Insert(0, new SelectListItem { Text="SELECCIONAR LUGAR", Value="" });

                LiLugarDestino = (from lo in BD.Lugar
                                 where lo.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Value = lo.IIDLUGAR.ToString(),
                                     Text = lo.NOMBRE
                                 }).ToList();
                LiLugarDestino.Insert(0, new SelectListItem { Text = "SELECCIONAR LUGAR", Value = "" });

                LiIDBus = (from lo in BD.Bus
                                 where lo.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Value = lo.IIDBUS.ToString(),
                                     Text = lo.PLACA
                                 }).ToList();
                LiIDBus.Insert(0, new SelectListItem { Text = "SELECCIONAR BUS (PLACA)", Value = "" });

            }
        }
        public ActionResult Agregar()
        {
            RefillSelect();

            ViewBag.LilugOrig = LiLugarOrigen;
            ViewBag.LilugDest = LiLugarDestino;
            ViewBag.LiIdBus = LiIDBus;

            return View();
        }
        //public ActionResult Eliminar(int idElemento)
        //{
        //    using (var BD = new BDPasajeEntities())
        //    {
        //        Viaje X = (from x in BD.Viaje where x.IIDVIAJE.Equals(idElemento) select x).First();

        //        X.BHABILITADO = 0;

        //        BD.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Agregar(CVIAJE info) 
        {
            if(!ModelState.IsValid)
            {
                RefillSelect();

                ViewBag.LilugOrig = LiLugarOrigen;
                ViewBag.LilugDest = LiLugarDestino;
                ViewBag.LiIdBus = LiIDBus;

                return View(info);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    int? asientosDisponibles = 0;

                    var consultaAsientos = from b in BD.Bus
                                           where b.BHABILITADO == 1 &&
                                           b.IIDBUS.Equals(info.IDBus)
                                           select b;

                    foreach(var c in consultaAsientos)
                    {
                        asientosDisponibles = c.NUMEROFILAS * c.NUMEROCOLUMNAS;
                    }

                    Viaje v = new Viaje();

                    v.IIDLUGARORIGEN = info.IDLugarOrigen;
                    v.IIDLUGARDESTINO = info.IDLugarDestino;
                    v.PRECIO = info.Precio;
                    v.FECHAVIAJE = info.FechaViaje;
                    v.IIDBUS = info.IDBus;
                    v.NUMEROASIENTOSDISPONIBLES = asientosDisponibles;
                    v.BHABILITADO = 1;

                    BD.Viaje.Add(v);
                    BD.SaveChanges();
                }
            }
                return RedirectToAction("Index");
        }
        public ActionResult Filtro(CVIAJE oVi, int? IDLugarOrigenParam)
        {
            List<CVIAJE> lista = null;
            try
            {           
                using(var BD = new BDPasajeEntities())
            {
                if (IDLugarOrigenParam == null)
                {
                    lista = (from v in BD.Viaje
                             join lugarO in BD.Lugar
                             on v.IIDLUGARORIGEN equals lugarO.IIDLUGAR
                             join lugarD in BD.Lugar
                             on v.IIDLUGARDESTINO equals lugarD.IIDLUGAR
                             join bus in BD.Bus
                             on v.IIDBUS equals bus.IIDBUS
                             where v.BHABILITADO == 1
                             select new CVIAJE
                             {
                                 IDViaje = v.IIDVIAJE,
                                 LugarOrigen = lugarO.NOMBRE,
                                 LugarDestino = lugarD.NOMBRE,
                                 IDBus = bus.IIDBUS,
                                 Precio = (decimal)v.PRECIO,
                                 FechaViaje = (DateTime)v.FECHAVIAJE,
                                 NumAsientosDisponibles = (int)v.NUMEROASIENTOSDISPONIBLES
                             }).ToList();
                }
                else
                {
                    lista = (from v in BD.Viaje
                             join lugarO in BD.Lugar
                             on v.IIDLUGARORIGEN equals lugarO.IIDLUGAR
                             join lugarD in BD.Lugar
                             on v.IIDLUGARDESTINO equals lugarD.IIDLUGAR
                             join bus in BD.Bus
                             on v.IIDBUS equals bus.IIDBUS
                             where v.BHABILITADO == 1
                             && v.IIDLUGARORIGEN == IDLugarOrigenParam
                             select new CVIAJE
                             {
                                 IDViaje = v.IIDVIAJE,
                                 LugarOrigen = lugarO.NOMBRE,
                                 LugarDestino = lugarD.NOMBRE,
                                 IDBus = bus.IIDBUS,
                                 Precio = (decimal)v.PRECIO,
                                 FechaViaje = (DateTime)v.FECHAVIAJE,
                                 NumAsientosDisponibles = (int)v.NUMEROASIENTOSDISPONIBLES
                             }).ToList();
                }                
            }
            }
            catch(Exception ex)
            {
                return PartialView(ex);
            }

            return PartialView("_TablaViajes",lista);
        }
        public string Guardar(CVIAJE oVi, HttpPostedFileBase Foto, int Puente)
        {
            string Respuesta = "";

            try
            {
                if (!ModelState.IsValid || (Foto == null && Puente == -1))
                {
                    var consulta = (from es in ModelState.Values
                                    from er in es.Errors
                                    select er.ErrorMessage).ToList();

                    if (Foto == null && Puente == -1)
                    {
                        oVi.errorFoto =
                             "<ul class=\"FormularioUl\">" +
                             "<li  class=\"FormularioLi\" >Se debe cargar una foto antes de proceder a agregar.</li>" +
                             "</ul>";
                        Respuesta += oVi.errorFoto;
                    }

                    Respuesta += "<ul class=\"FormularioUl\">";

                    foreach (var er in consulta) Respuesta += "<li class=\"FormularioLi\">" + er + "</li>";

                    Respuesta += "</ul>";

                    return Respuesta;
                }
                else
                {
                    byte[] FotoBD = null;

                    if(Foto != null)
                    {
                        BinaryReader Lector = new BinaryReader(Foto.InputStream);
                        FotoBD = Lector.ReadBytes((int)Foto.ContentLength);
                    }

                    using (var BD = new BDPasajeEntities())
                    {
                        if(Puente == -1)
                        {
                            Viaje viaje = new Viaje();

                            viaje.IIDLUGARORIGEN = oVi.IDLugarOrigen;
                            viaje.IIDLUGARDESTINO = oVi.IDLugarDestino;
                            viaje.PRECIO = oVi.Precio;
                            viaje.FECHAVIAJE = oVi.FechaViaje;
                            viaje.IIDBUS = oVi.IDBus;
                            viaje.NUMEROASIENTOSDISPONIBLES = oVi.NumAsientosDisponibles;
                            viaje.FOTO = FotoBD;
                            viaje.nombrefoto = oVi.nombreFoto;
                            viaje.BHABILITADO = 1;

                            BD.Viaje.Add(viaje);
                            Respuesta = BD.SaveChanges().ToString();
                            if (Respuesta == "0") Respuesta = "";
                        }
                        else
                        {
                            Viaje viaje = (from v in BD.Viaje 
                                        where v.IIDVIAJE == Puente 
                                        select v).First();

                            viaje.IIDLUGARORIGEN = oVi.IDLugarOrigen;
                            viaje.IIDLUGARDESTINO = oVi.IDLugarDestino;
                            viaje.PRECIO = oVi.Precio;
                            viaje.FECHAVIAJE = oVi.FechaViaje;
                            viaje.IIDBUS = oVi.IDBus;
                            viaje.NUMEROASIENTOSDISPONIBLES = oVi.NumAsientosDisponibles;
                            if(Foto != null) viaje.FOTO = FotoBD;
                            viaje.nombrefoto = oVi.nombreFoto;

                            Respuesta = BD.SaveChanges().ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"{ex}";
            }

            return Respuesta;
        }
        public string Eliminar(int Puente)
        {          
            string Respuesta = "";

            using(var BD = new BDPasajeEntities())
            {
                if(Puente > 0)
                {
                    Viaje v = (from vi in BD.Viaje
                               where vi.IIDVIAJE == Puente
                               select vi).First();

                    v.BHABILITADO = 0;
                    Respuesta = BD.SaveChanges().ToString();
                    if (Respuesta == "0") Respuesta = "";
                }
            }
            return Respuesta;
        }
        public JsonResult CapturarDatos(int Puente)
        {
            CVIAJE oVi = new CVIAJE();

            using (var BD = new BDPasajeEntities())
            {    
                Viaje vi = (from v in BD.Viaje
                            where v.IIDVIAJE == Puente
                            select v).First();

                oVi.IDLugarOrigen = (int)vi.IIDLUGARORIGEN;
                oVi.IDLugarDestino = (int)vi.IIDLUGARDESTINO;
                oVi.Precio = (decimal)vi.PRECIO;
                oVi.FechaViajeCadena = ((DateTime)vi.FECHAVIAJE).ToString("yyy-MM-ddTHH:mm");
                oVi.IDBus = (int)vi.IIDBUS;
                oVi.NumAsientosDisponibles = (int)vi.NUMEROASIENTOSDISPONIBLES;
                oVi.nombreFoto = vi.nombrefoto;
                oVi.Extension = Path.GetExtension(vi.nombrefoto);
                oVi.CadenaFotoRecuperada = Convert.ToBase64String(vi.FOTO);


            }
            return Json(oVi,JsonRequestBehavior.AllowGet);
        }
    }
}