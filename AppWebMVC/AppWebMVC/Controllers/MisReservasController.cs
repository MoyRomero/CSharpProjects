using AppWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static OfficeOpenXml.ExcelErrorValue;
using AppWebMVC.Filters;
using System.Transactions;

namespace AppWebMVC.Controllers
{
    [Access]
    public class MisReservasController : Controller
    {
        // GET: MisReservas
        public ActionResult Index()
        {
            var PasajesID = ControllerContext.HttpContext.Request.Cookies["PasajesID"];
            var PasajesInformacion = ControllerContext.HttpContext.Request.Cookies["PasajesInformacion"];

            List<CRESERVA> ReservasLista = new List<CRESERVA>();

            if(PasajesID != null && PasajesInformacion != null)
            {
                //string ValoresID = System.Web.HttpUtility.UrlDecode(PasajesID.Value, System.Text.Encoding.UTF8);
                //string ValoresInformacion = System.Web.HttpUtility.UrlDecode(PasajesInformacion.Value, System.Text.Encoding.UTF8);

                string ValoresID = PasajesID.Value;
                string ValoresInformacion = PasajesInformacion.Value;

                string[] ValoresIDSeparados = ValoresID.Split('{');
                string[] ValoresInfoSeparada = ValoresInformacion.Split('{');

                string[] InfoDividida;

                if(ValoresIDSeparados[0] != "")
                {
                    for(int i = 0; i < ValoresIDSeparados.Count(); i++)
                    {
                        InfoDividida = ValoresInfoSeparada[i].Split('*');

                        CRESERVA re = new CRESERVA();
                        re.IDViaje = int.Parse(ValoresIDSeparados[i]);
                        re.AsientosReservados = int.Parse(InfoDividida[0]);
                        re.LugarOrigen = InfoDividida[1].ToString();
                        re.LugarDestino = InfoDividida[2].ToString();
                        re.FechaViaje = DateTime.Parse(InfoDividida[3]);
                        re.Precio = decimal.Parse(InfoDividida[4]);
                        re.SubTotal = re.Precio * re.AsientosReservados;
                        re.IDBus = int.Parse(InfoDividida[5]);
                        ReservasLista.Add(re);
                    }
                }
            }

            return View(ReservasLista);
        }        

        public string EnviarABD(string Total)
        {
            string Respuesta = "";

            var PasajesID = ControllerContext.HttpContext.Request.Cookies["PasajesID"];
            var PasajesInformacion = ControllerContext.HttpContext.Request.Cookies["PasajesInformacion"];

            string ValoresID = PasajesID.Value;
            string ValoresInformacion = PasajesInformacion.Value;

            if(ValoresID != null && PasajesInformacion != null)
            {
                string[] ValoresIDSeparados = ValoresID.Split('{');
                string[] ValoresInfoSeparada = ValoresInformacion.Split('{');
                string[] ValoresInfoDividida;

                using (var Transaccion = new TransactionScope())
                {                     
                    Usuario usuarioData = (Usuario)Session["Usuario"];
                    int IDUsuario = usuarioData.IIDUSUARIO;

                    VENTA VentaData = new VENTA();                    

                    using (var BD = new BDPasajeEntities())
                    {
                        VentaData.IIDUSUARIO = IDUsuario;
                        VentaData.TOTAL = decimal.Parse(Total);
                        VentaData.FECHAVENTA = DateTime.Now;
                        VentaData.BHABILITADO = 1;

                        BD.VENTA.Add(VentaData);
                        BD.SaveChanges();

                        int IDVenta = VentaData.IIDVENTA;

                        for(int i = 0; i < ValoresInfoSeparada.Count(); i++)
                        {
                            ValoresInfoDividida = ValoresInfoSeparada[i].Split('*');

                            DETALLEVENTA DVData = new DETALLEVENTA();

                            DVData.IIDVENTA = IDVenta;
                            DVData.IIDVIAJE = int.Parse(ValoresIDSeparados[i]);
                            DVData.IIDBUS = int.Parse(ValoresInfoDividida[5]);
                            DVData.PRECIO = int.Parse(ValoresInfoDividida[4]);
                            DVData.ASIENTOSRESERVADOS = int.Parse(ValoresInfoDividida[0]);
                            DVData.BHABILITADO = 1;

                            BD.DETALLEVENTA.Add(DVData);
                            BD.SaveChanges();

                            var BusquedaViaje = (from v in BD.Viaje
                                                 where v.IIDVIAJE == DVData.IIDVIAJE
                                                 select v).First();

                            BusquedaViaje.NUMEROASIENTOSDISPONIBLES -= int.Parse(ValoresInfoDividida[0]);

                            BD.SaveChanges();
                        }

                        BD.SaveChanges();
                        Transaccion.Complete();

                        HttpCookie CookieID = new HttpCookie("PasajesID", "");
                        HttpCookie CookieInformacion = new HttpCookie("PasajesInformacion", "");

                        ControllerContext.HttpContext.Response.SetCookie(CookieID);
                        ControllerContext.HttpContext.Response.SetCookie(CookieInformacion);
                    }
                    Respuesta = "1";
                };
            }

            return Respuesta;
        }
    }
}