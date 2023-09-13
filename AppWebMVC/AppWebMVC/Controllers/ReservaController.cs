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
    public class ReservaController : Controller
    {
        List<SelectListItem> ListaFiltro = null;
        // GET: Reserva
        public void ListaFiltroRefill()
        {
            using(var BD = new BDPasajeEntities())
            {
                ListaFiltro = (from li in BD.Lugar
                               where li.BHABILITADO == 1
                               select new SelectListItem
                               {
                                   Value = li.IIDLUGAR.ToString(),
                                   Text = li.NOMBRE
                               }).ToList();
                ListaFiltro.Insert(0, new SelectListItem { Value = "", Text = "SELECCIONA LUGAR DE ORIGEN" });
            }
        }
        public ActionResult Index()
        {
            ListaFiltroRefill();

            var PasajesID = ControllerContext.HttpContext.Request.Cookies["PasajesID"];
            var PasajesInformacion = ControllerContext.HttpContext.Request.Cookies["PasajesInformacion"];

            if (PasajesID != null && PasajesInformacion != null)
            {
                ViewBag.pasajesid = PasajesID.Value.ToString();
                ViewBag.pasajesinfo = PasajesInformacion.Value.ToString();
            }

            ViewBag.ListaFiltroVB = ListaFiltro;

            List<CRESERVA> ListaReservas = null;

            using (var BD = new BDPasajeEntities())
            {
                ListaReservas = (from vi in BD.Viaje
                               join luO in BD.Lugar
                               on vi.IIDLUGARORIGEN equals luO.IIDLUGAR
                               join luD in BD.Lugar
                               on vi.IIDLUGARDESTINO equals luD.IIDLUGAR
                               join b in BD.Bus
                               on vi.IIDBUS equals b.IIDBUS
                               where vi.BHABILITADO == 1
                               select new CRESERVA
                               {
                                   IDViaje = vi.IIDVIAJE,
                                   Precio = (decimal)vi.PRECIO,
                                   PlacaBus = b.PLACA,
                                   DescripcionBus = b.DESCRIPCION,
                                   FechaViaje = (DateTime)vi.FECHAVIAJE,
                                   NombreFoto = vi.nombrefoto,
                                   Foto = vi.FOTO,
                                   IDLugarOrigen = (int)vi.IIDLUGARORIGEN,
                                   IDLugarDestino = (int)vi.IIDLUGARDESTINO,
                                   LugarOrigen = luO.NOMBRE,
                                   LugarDestino = luD.NOMBRE,
                                   AsientosDisponibles = (int)vi.NUMEROASIENTOSDISPONIBLES,
                                   TotalAsientos = (int) b.NUMEROFILAS * (int)b.NUMEROCOLUMNAS,
                                   IDBus = b.IIDBUS

                               }).ToList();
            }

            return View(ListaReservas);
        } 
        public ActionResult Filtro(CRESERVA oVi, int? IDLugarOrigenParam)
        {
            List<CRESERVA> lista = null;
            try
            {
                using (var BD = new BDPasajeEntities())
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
                                    select new CRESERVA
                                    {
                                        IDViaje = v.IIDVIAJE,
                                        LugarOrigen = lugarO.NOMBRE,
                                        LugarDestino = lugarD.NOMBRE,
                                        PlacaBus = bus.PLACA,
                                        Precio = (decimal)v.PRECIO,
                                        FechaViaje = (DateTime)v.FECHAVIAJE,
                                        AsientosDisponibles = (int)v.NUMEROASIENTOSDISPONIBLES
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
                                    select new CRESERVA
                                    {
                                        IDViaje = v.IIDVIAJE,
                                        LugarOrigen = lugarO.NOMBRE,
                                        LugarDestino = lugarD.NOMBRE,
                                        PlacaBus = bus.PLACA,
                                        Precio = (decimal)v.PRECIO,
                                        FechaViaje = (DateTime)v.FECHAVIAJE,
                                        AsientosDisponibles = (int)v.NUMEROASIENTOSDISPONIBLES
                                    }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }

            return PartialView("_TablaViajes", lista);
        }

        public string CrearCookie(string IDviaje, string AsientosReservados,
            string Origen, string Destino, string fecha, string Precio, string IDBus)
        {
            string Respuesta = "";
            try
            {
                var PasajesID = ControllerContext.HttpContext.Request.Cookies["PasajesID"];
                var PasajesInformacion = ControllerContext.HttpContext.Request.Cookies["PasajesInformacion"];

                if (PasajesID != null && PasajesInformacion != null &&
                    PasajesID.Value != "" && PasajesInformacion.Value != "")
                {//Se sobreescriben las cookies

                    string IDCookie = PasajesID.Value + "{" + IDviaje;

                    string InformacionCookie = PasajesInformacion.Value +
                        "{" + AsientosReservados + "*" + Origen + "*" +
                        Destino + "*" + fecha + "*" + Precio + "*" + IDBus;

                    HttpCookie CookieID = new HttpCookie("PasajesID", IDCookie);
                    HttpCookie CookieInformacion = new HttpCookie("PasajesInformacion", InformacionCookie);

                    ControllerContext.HttpContext.Response.SetCookie(CookieID);
                    ControllerContext.HttpContext.Response.SetCookie(CookieInformacion);
                }
                else
                {//Se crean las cookies por primera vez (Se almacena todo en un string, exceptuando el IDViaje)

                    string CadenaInformacion = AsientosReservados + "*" + Origen + "*" +
                        Destino + "*" + fecha + "*" + Precio + "*" + IDBus;

                    HttpCookie CookieID = new HttpCookie("PasajesID", IDviaje);
                    HttpCookie CookieInformacion = new HttpCookie("PasajesInformacion", CadenaInformacion);

                    ControllerContext.HttpContext.Response.SetCookie(CookieID);
                    ControllerContext.HttpContext.Response.SetCookie(CookieInformacion);
                }
                Respuesta = "1";
            }
            catch (Exception ex)
            {
                Respuesta = $"Ocurrió un error: {ex}";
                return Respuesta;
            }

            return Respuesta;
        }

        public string RemoverCookies(string IDviaje)
        {
            string Respuesta = "";

            try
            {
                var PasajesID = ControllerContext.HttpContext.Request.Cookies["PasajesID"];
                var PasajesInformacion = ControllerContext.HttpContext.Request.Cookies["PasajesInformacion"];

                string ValoresID = PasajesID.Value;
                string ValoresInformacion = PasajesInformacion.Value;

                string[] ArrayIDs = ValoresID.Split('{');
                int IndiceID = Array.IndexOf(ArrayIDs, IDviaje);

                string NuevaCadenaIDs;

                if (ValoresID.Contains("{" + IDviaje))
                {
                    NuevaCadenaIDs = ValoresID.Replace("{" + IDviaje, "");
                }
                else if (ValoresID.Contains(IDviaje + "{"))
                {
                    NuevaCadenaIDs = ValoresID.Replace(IDviaje + "{", "");
                }
                else
                {
                    NuevaCadenaIDs = ValoresID.Replace(IDviaje, "");
                }

                List<string> ValoresInfoList = ValoresInformacion.Split('{').ToList();
                ValoresInfoList.RemoveAt(IndiceID);

                string[] NuevoArrayInformacion = ValoresInfoList.ToArray();
                string NuevaCadenaInformacion = String.Join("{", NuevoArrayInformacion);

                HttpCookie CookieID = new HttpCookie("PasajesID", NuevaCadenaIDs);
                HttpCookie CookieInformacion = new HttpCookie("PasajesInformacion", NuevaCadenaInformacion);

                ControllerContext.HttpContext.Response.SetCookie(CookieID);
                ControllerContext.HttpContext.Response.SetCookie(CookieInformacion);

                Respuesta = "1";
            }
            catch (Exception ex)
            {
                Respuesta = ex.ToString();
            }

            return Respuesta;
        }
    }
}