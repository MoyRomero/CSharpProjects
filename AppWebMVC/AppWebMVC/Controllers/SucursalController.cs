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
    public class SucursalController : Controller
    {
        // GET: Sucursal

        public ActionResult Index(CSUCURSAL oSuc)
        {
            List<CSUCURSAL> ListaSucursal = new List<CSUCURSAL>();

            using (var BD = new BDPasajeEntities())
            {
                if(oSuc.NOMBRE == null)
                {
                    ListaSucursal = (from S in BD.Sucursal
                                     where S.BHABILITADO == 1
                                     select new CSUCURSAL
                                     {
                                         IDSucursal = S.IIDSUCURSAL,
                                         NOMBRE = S.NOMBRE,
                                         DireccSucursal = S.DIRECCION,
                                         TelSucursal = S.TELEFONO,
                                         EmailSucursal = S.EMAIL,
                                         FechaApertura = (DateTime)S.FECHAAPERTURA,
                                         BHABILITADO = (int)S.BHABILITADO
                                     }).ToList();
                }
                else
                {
                     ListaSucursal = (from S in BD.Sucursal
                                     where S.BHABILITADO == 1 &&
                                     S.NOMBRE.Contains(oSuc.NOMBRE)
                                     select new CSUCURSAL
                                     {
                                         IDSucursal = S.IIDSUCURSAL,
                                         NOMBRE = S.NOMBRE,
                                         DireccSucursal = S.DIRECCION,
                                         TelSucursal = S.TELEFONO,
                                         EmailSucursal = S.EMAIL,
                                         FechaApertura = (DateTime)S.FECHAAPERTURA,
                                         BHABILITADO = (int)S.BHABILITADO
                                     }).ToList();
                }
            }
            return View(ListaSucursal);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            CSUCURSAL suc = new CSUCURSAL();

            using(var BD = new BDPasajeEntities())
            {
                Sucursal Suc = (from s in BD.Sucursal where s.IIDSUCURSAL == id select s).First();

                suc.IDSucursal = Suc.IIDSUCURSAL;
                suc.NOMBRE = Suc.NOMBRE;
                suc.DireccSucursal = Suc.DIRECCION;
                suc.TelSucursal = Suc.TELEFONO;
                suc.EmailSucursal = Suc.EMAIL;
                suc.FechaApertura = (DateTime)Suc.FECHAAPERTURA;                

            }
            return View(suc);
        }

        public ActionResult Eliminar(int idElemento)
        {
            using (var BD = new BDPasajeEntities())
            {
                Sucursal X = (from x in BD.Sucursal where x.IIDSUCURSAL.Equals(idElemento) select x).First();

                X.BHABILITADO = 0;

                BD.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Agregar(CSUCURSAL informacion)
        {
            int regRepetido = 0;
            int emRepetido = 0;
            using(var BD = new BDPasajeEntities())
            {
                regRepetido = (from s in BD.Sucursal where s.NOMBRE.Equals(informacion.NOMBRE) select s).Count();
                emRepetido = (from s in BD.Sucursal where s.EMAIL.Equals(informacion.EmailSucursal) select s).Count();
            }

            if(!ModelState.IsValid || regRepetido > 0 || emRepetido > 0)
            {
                if (regRepetido > 0) informacion.MensajeErrorNombre = $"El nombre de la sucursal: {informacion.NOMBRE}, ya existe en la base de datos.";
                if (emRepetido > 0) informacion.MensajeErrorEmail = $"El email que intentas ingresar, ya está en uso por otra sucursal.";
                
                return View(informacion);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Sucursal suc = new Sucursal();

                    suc.NOMBRE = informacion.NOMBRE;
                    suc.DIRECCION = informacion.DireccSucursal;
                    suc.TELEFONO = informacion.TelSucursal;
                    suc.EMAIL = informacion.EmailSucursal;
                    suc.FECHAAPERTURA = informacion.FechaApertura;
                    suc.BHABILITADO = 1;

                    BD.Sucursal.Add(suc);
                    BD.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CSUCURSAL info)
        {
            int regRepetido = 0;
            int emRepetido = 0;
            int ID = info.IDSucursal;

            using (var BD = new BDPasajeEntities())
            {
                regRepetido = (from s in BD.Sucursal where s.NOMBRE.Equals(info.NOMBRE) && !s.IIDSUCURSAL.Equals(ID) select s).Count();
                emRepetido = (from s in BD.Sucursal where s.EMAIL.Equals(info.EmailSucursal) && !s.IIDSUCURSAL.Equals(ID) select s).Count();
            }

            if (!ModelState.IsValid || regRepetido > 0 || emRepetido > 0)
            {
                if (regRepetido > 0) info.MensajeErrorNombre = $"El nombre de la sucursal: {info.NOMBRE}, ya existe en la base de datos.";
                if (emRepetido > 0) info.MensajeErrorEmail = $"El email que intentas ingresar, ya está en uso por otra sucursal.";

                return View(info);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Sucursal suc = (from s in BD.Sucursal where s.IIDSUCURSAL.Equals(ID) select s).First();

                    suc.NOMBRE = info.NOMBRE;
                    suc.DIRECCION = info.DireccSucursal;
                    suc.TELEFONO = info.TelSucursal;
                    suc.EMAIL = info.EmailSucursal;
                    suc.FECHAAPERTURA = (DateTime)info.FechaApertura;

                    BD.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
    }
}