using AppWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    [Access]
    public class BusController : Controller
    {
        // GET: Bus
        List<SelectListItem> SucursalList;
        List<SelectListItem> ModeloList;
        List<SelectListItem> MarcaList;
        List<SelectListItem> TipoBuslList;
        CBUS Valores;

        private bool FiltradoBuses(CBUS oBus)
        {
            bool Placa = true;
            bool IDSucursal = true;
            bool IDModelo = true;

            if(Valores.Placa != null) Placa = oBus.Placa.Contains(Valores.Placa);

            if(Valores.IDSucursal > 0) IDSucursal = oBus.IDSucursal.ToString().Contains(Valores.IDSucursal.ToString()); 

            if(Valores.IDModelo > 0) IDModelo = oBus.IDModelo.ToString().Contains(Valores.IDModelo.ToString());

            return (Placa && IDSucursal && IDModelo);
        }

        private void DropDownRefill()
        {
            using(var BD = new BDPasajeEntities())
            {
                SucursalList = (from s in BD.Sucursal
                                where s.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Value = s.IIDSUCURSAL.ToString(),
                                    Text = s.NOMBRE,
                                }).ToList();
                SucursalList.Insert(0, new SelectListItem {Text ="SIN SELECCIONAR", Value ="" });

                ModeloList = (from m in BD.Modelo
                              where m.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Value = m.IIDMODELO.ToString(),
                                  Text = m.NOMBRE,
                              }).ToList();
                ModeloList.Insert(0, new SelectListItem {Text ="SIN SELECCIONAR", Value ="" });

                MarcaList = (from m in BD.Marca
                              where m.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Value = m.IIDMARCA.ToString(),
                                  Text = m.NOMBRE,
                              }).ToList();
                MarcaList.Insert(0, new SelectListItem {Text ="SIN SELECCIONAR", Value =""});

                TipoBuslList = (from m in BD.TipoBus
                                where m.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Value = m.IIDTIPOBUS.ToString(),
                                    Text = m.NOMBRE,
                                }).ToList();
                TipoBuslList.Insert(0, new SelectListItem {Text ="SIN SELECCIONAR", Value =""});

            }
        }

        public ActionResult Index(CBUS oBus)
        {
            Valores = oBus;

            DropDownRefill();

            ViewBag.listaSucursal = SucursalList;
            ViewBag.listaModelo = ModeloList;

            List<CBUS> lista = null;
            List<CBUS> ListaFiltrado = new List<CBUS>();
            using (var BD = new BDPasajeEntities())
            {
                lista = (from bus in BD.Bus
                         join suc in BD.Sucursal
                         on bus.IIDSUCURSAL equals suc.IIDSUCURSAL
                         join tb in BD.TipoBus
                         on bus.IIDTIPOBUS equals tb.IIDTIPOBUS
                         join mod in BD.Modelo
                         on bus.IIDMODELO equals mod.IIDMODELO
                         join marca in BD.Marca
                         on bus.IIDMARCA equals marca.IIDMARCA
                         where bus.BHABILITADO == 1
                         select new CBUS
                         {
                             IDBus = bus.IIDBUS,
                             IDModelo = (int)bus.IIDMODELO,
                             IDSucursal = (int)bus.IIDSUCURSAL,
                             Sucursal = suc.NOMBRE,
                             TipoBus = tb.NOMBRE,
                             Placa = bus.PLACA,
                             FechaCompra = (DateTime)bus.FECHACOMPRA,
                             Modelo = mod.NOMBRE,
                             NumeroFilas = (int)bus.NUMEROFILAS,
                             NumeroColumnas = (int)bus.NUMEROCOLUMNAS,
                             Marca = marca.NOMBRE
                         }).ToList();

                if (oBus.Placa == null && oBus.IDModelo == 0 && oBus.IDSucursal == 0)
                {
                    ListaFiltrado = lista;
                }
                else
                {
                    //if(oBus.Placa != null)
                    //{
                    //    ListaFiltrado = lista.Where(x => x.Placa.Contains(oBus.Placa)).ToList();
                    //}

                    //if(oBus.IDModelo != 0)
                    //{
                    //    //ListaFiltrado = lista.Where(s => s.IDModelo.ToString().Contains(oBus.IDModelo.ToString())).ToList();
                    //    ListaFiltrado = (from b in lista where b.IDModelo.ToString().Contains(oBus.IDModelo.ToString()) 
                    //                     select b).ToList();                        
                    //}

                    //if (oBus.IDSucursal != 0)
                    //{
                    //    //ListaFiltrado = lista.Where(x => x.IDSucursal.ToString().Contains(oBus.IDSucursal.ToString())).ToList();
                    //    ListaFiltrado = (from b in lista where b.IDSucursal.ToString().Contains(oBus.IDSucursal.ToString())
                    //                     select b).ToList();
                    //}

                    Predicate<CBUS> Pre = new Predicate<CBUS>(FiltradoBuses);

                    ListaFiltrado = lista.FindAll(Pre);
                }
            }
            return View(ListaFiltrado);
        }

        public ActionResult Agregar()
        {
            DropDownRefill();

            ViewBag.listaSucursal = SucursalList;
            ViewBag.listaBus = ModeloList;
            ViewBag.listaMarca = MarcaList;
            ViewBag.listaModelo = TipoBuslList;

            return View();
        }

        public ActionResult Editar(int id)
        {
            DropDownRefill();

            ViewBag.listaSucursal = SucursalList;
            ViewBag.listaBus = ModeloList;
            ViewBag.listaMarca = MarcaList;
            ViewBag.listaModelo = TipoBuslList;

            CBUS bus = new CBUS();
            using(var BD = new BDPasajeEntities())
            {
                Bus BUS = (from b in BD.Bus where b.IIDBUS.Equals(id) select b).First();

                bus.IDBus = BUS.IIDBUS;
                bus.IDSucursal = (int)BUS.IIDSUCURSAL;
                bus.IDTipoBus = (int)BUS.IIDTIPOBUS;
                bus.Placa = BUS.PLACA;
                bus.FechaCompra = (DateTime)BUS.FECHACOMPRA;
                bus.IDMarca = (int)BUS.IIDMARCA;
                bus.IDModelo = (int)BUS.IIDMODELO;
                bus.NumeroFilas = (int)BUS.NUMEROFILAS;
                bus.NumeroColumnas = (int)BUS.NUMEROCOLUMNAS;
                bus.Descripcion = (string)BUS.DESCRIPCION;
                bus.Observacion = (string)BUS.OBSERVACION;
            }

            return View(bus);
        }

        public ActionResult Eliminar(int idElemento)
        {
            using (var BD = new BDPasajeEntities())
            {
                Bus bus = (from b in BD.Bus where b.IIDBUS.Equals(idElemento) select b).First();

                bus.BHABILITADO = 0;

                BD.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Agregar(CBUS info)
        {
            int PlacaRepetida = 0;

            using(var BD = new BDPasajeEntities())
            {
                PlacaRepetida = (from p in BD.Bus where p.PLACA.Equals(info.Placa) select p).Count();
            }
            
            if(!ModelState.IsValid || PlacaRepetida > 0)
            {
                if (PlacaRepetida > 0) info.MensajeErrorPlaca = $"Ya existe un Bus con la placa: {info.Placa}, registrado en la base de datos.";

                DropDownRefill();

                ViewBag.listaSucursal = SucursalList;
                ViewBag.listaBus = ModeloList;
                ViewBag.listaMarca = MarcaList;
                ViewBag.listaModelo = TipoBuslList;

                return View(info);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Bus bus = new Bus();

                    bus.IIDSUCURSAL = info.IDSucursal;
                    bus.IIDTIPOBUS = info.IDTipoBus;
                    bus.PLACA = info.Placa;
                    bus.FECHACOMPRA = info.FechaCompra;
                    bus.IIDMARCA = info.IDMarca;
                    bus.IIDMODELO = info.IDModelo;
                    bus.NUMEROFILAS = info.NumeroFilas;
                    bus.NUMEROCOLUMNAS = info.NumeroColumnas;
                    bus.BHABILITADO = 1;

                    BD.Bus.Add(bus);
                    BD.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CBUS info)
        {
            if (!ModelState.IsValid)
            {
                DropDownRefill();

                ViewBag.listaSucursal = SucursalList;
                ViewBag.listaBus = ModeloList;
                ViewBag.listaMarca = MarcaList;
                ViewBag.listaModelo = TipoBuslList;

                return View(info);
            }
            else
            {
                int ID = info.IDBus;
                using(var BD = new BDPasajeEntities())
                {
                    Bus bus = (from b in BD.Bus where b.IIDBUS.Equals(ID) select b).First();

                    bus.IIDSUCURSAL = info.IDSucursal;
                    bus.IIDTIPOBUS = info.IDTipoBus;
                    bus.PLACA = info.Placa;
                    bus.FECHACOMPRA = info.FechaCompra;
                    bus.IIDMARCA = info.IDMarca;
                    bus.IIDMODELO = info.IDModelo;
                    bus.NUMEROFILAS = info.NumeroFilas;
                    bus.NUMEROCOLUMNAS = info.NumeroColumnas;

                    BD.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }        
    }
}