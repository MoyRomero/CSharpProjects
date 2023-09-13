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
    public class ReservasRealizadasController : Controller
    {
        // GET: ReservasRealizadas
        public ActionResult Index()
        {
            Usuario DataUsuario = (Usuario)Session["Usuario"];

            int IDUsuario = DataUsuario.IIDUSUARIO;

            List<CRESERVA> ListaReservas = new List<CRESERVA>();
            using(var BD = new BDPasajeEntities())
            {

                ListaReservas = (from dv in BD.DETALLEVENTA
                                 join v in BD.VENTA
                                 on dv.IIDVENTA equals v.IIDVENTA
                                 join vi in BD.Viaje
                                 on dv.IIDVIAJE equals vi.IIDVIAJE
                                 join u in BD.Usuario
                                 on v.IIDUSUARIO equals u.IIDUSUARIO
                                 join c in BD.Cliente
                                 on u.IID equals c.IIDCLIENTE
                                 join ld in BD.Lugar
                                 on vi.IIDLUGARDESTINO equals ld.IIDLUGAR
                                 join lo in BD.Lugar
                                 on vi.IIDLUGARORIGEN equals lo.IIDLUGAR
                                 join b in BD.Bus 
                                 on dv.IIDBUS equals b.IIDBUS
                                 where v.IIDUSUARIO == IDUsuario
                                 select new CRESERVA
                                 {
                                     NombrePersona = c.NOMBRE +" "+c.APPATERNO,
                                     LugarOrigen = lo.NOMBRE,
                                     LugarDestino = ld.NOMBRE,
                                     AsientosReservados = dv.ASIENTOSRESERVADOS,
                                     FechaViaje = (DateTime) vi.FECHAVIAJE,
                                     FechaCompra = (DateTime) v.FECHAVENTA,
                                     Total = (decimal) v.TOTAL,
                                     PlacaBus = b.PLACA

                                 }).ToList();
                //A NOMBRE DE - TOTAL ASIENTOS - ORIGEN - DESTINO - FECHA V - FECHA DE COMPRA - TOTAL - BUS

            }
            return View(ListaReservas);
        }
    }
}