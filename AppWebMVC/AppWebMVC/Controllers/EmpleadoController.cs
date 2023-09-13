using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AppWebMVC.Models;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    [Access]
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        List<SelectListItem> Lista_s;
        List<SelectListItem> Lista_c;
        List<SelectListItem> Lista_TU;

        private void ListaS()
        {
            using(var BD = new BDPasajeEntities())
            {
                Lista_s = (from s in BD.Sexo
                           where s.BHABILITADO == 1
                           select new SelectListItem
                           {
                               Value = s.IIDSEXO.ToString(),
                               Text = s.NOMBRE
                           }).ToList();

                Lista_c = (from c in BD.TipoContrato
                           where c.BHABILITADO == 1
                           select new SelectListItem
                           {
                               Value = c.IIDTIPOCONTRATO.ToString(),
                               Text = c.NOMBRE
                           }).ToList();

                Lista_TU = (from tu in BD.TipoUsuario
                            where tu.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Value = tu.IIDTIPOUSUARIO.ToString(),
                                Text = tu.NOMBRE
                            }).ToList();
                Lista_TU.Insert(0, new SelectListItem { Text = "SELECCIONA TIPO USUARIO", Value = "" });
                Lista_TU.Insert(1, new SelectListItem { Text = "QUITAR FILTRO", Value = "" });
            }            
        }

        public ActionResult Index(CEMPLEADO oEmp)
        {
            ListaS();
            ViewBag.Lista_tu = Lista_TU;

            List<CEMPLEADO> list = null;

            using(var BD = new BDPasajeEntities())
            {
                if (oEmp.IDTipoDeUsuario == 0) {

                    list = (from emp in BD.Empleado
                            join s in BD.Sexo
                            on emp.IIDSEXO equals s.IIDSEXO
                            join tc in BD.TipoContrato
                            on emp.IIDTIPOCONTRATO equals tc.IIDTIPOCONTRATO
                            join tu in BD.TipoUsuario
                            on emp.IIDTIPOUSUARIO equals tu.IIDTIPOUSUARIO
                            where emp.BHABILITADO == 1
                            select new CEMPLEADO
                            {
                                IDEmpleado = emp.IIDEMPLEADO,
                                NOMBRE = emp.NOMBRE,
                                APPaterno = emp.APPATERNO,
                                APMaterno = emp.APMATERNO,
                                FechaContrato = (DateTime)emp.FECHACONTRATO,
                                Sueldo = (decimal)emp.SUELDO,
                                TipoDeUsuario = tu.NOMBRE,
                                TipoContrato = tc.NOMBRE,
                                Sexo = s.NOMBRE
                            }).ToList();
                }
                else
                {
                    list = (from emp in BD.Empleado
                            join s in BD.Sexo
                            on emp.IIDSEXO equals s.IIDSEXO
                            join tc in BD.TipoContrato
                            on emp.IIDTIPOCONTRATO equals tc.IIDTIPOCONTRATO
                            join tu in BD.TipoUsuario
                            on emp.IIDTIPOUSUARIO equals tu.IIDTIPOUSUARIO
                            where emp.BHABILITADO == 1 &&
                            emp.IIDTIPOUSUARIO == oEmp.IDTipoDeUsuario
                            select new CEMPLEADO
                            {
                                IDEmpleado = emp.IIDEMPLEADO,
                                NOMBRE = emp.NOMBRE,
                                APPaterno = emp.APPATERNO,
                                APMaterno = emp.APMATERNO,
                                FechaContrato = (DateTime)emp.FECHACONTRATO,
                                Sueldo = (decimal)emp.SUELDO,
                                TipoDeUsuario = tu.NOMBRE,
                                TipoContrato = tc.NOMBRE,
                                Sexo = s.NOMBRE
                            }).ToList();
                }
            }

            return View(list);
        }

        public ActionResult Agregar()
        {
            ListaS();

            ViewBag.Lista_s = Lista_s;
            ViewBag.Lista_c = Lista_c;

            return View();
        }

        public ActionResult Editar(int id)
        {
            ListaS();

            ViewBag.Lista_s = Lista_s;
            ViewBag.Lista_c = Lista_c;

            CEMPLEADO emp = new CEMPLEADO();

            using(var BD = new BDPasajeEntities())
            {
                Empleado EMP = (from e in BD.Empleado where e.IIDEMPLEADO == id select e).First();

                emp.IDEmpleado = (int)EMP.IIDEMPLEADO;
                emp.NOMBRE = EMP.NOMBRE;
                emp.APPaterno = EMP.APPATERNO;
                emp.APMaterno = EMP.APMATERNO;
                emp.IDSexo = (int)EMP.IIDSEXO;
                emp.FechaContrato = (DateTime)EMP.FECHACONTRATO;
                emp.IDTipoContrato = (int)EMP.IIDTIPOCONTRATO;
                emp.Sueldo = (decimal)EMP.SUELDO;

            }

            return View(emp);
        }

        public ActionResult Eliminar(int idElemento)
        {
            using (var BD = new BDPasajeEntities())
            {
                Empleado X = (from x in BD.Empleado where x.IIDEMPLEADO.Equals(idElemento) select x).First();

                X.BHABILITADO = 0;

                BD.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Agregar(CEMPLEADO info)
        {
            if (!ModelState.IsValid)
            {
                ListaS();

                ViewBag.Lista_s = Lista_s;
                ViewBag.Lista_c = Lista_c;

                return View(info);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Empleado empleado = new Empleado();

                    empleado.NOMBRE = info.NOMBRE;
                    empleado.APPATERNO = info.APPaterno;
                    empleado.APMATERNO = info.APMaterno;
                    empleado.IIDSEXO = info.IDSexo;
                    empleado.FECHACONTRATO = info.FechaContrato;
                    empleado.IIDTIPOCONTRATO = info.IDTipoContrato;
                    empleado.SUELDO = info.Sueldo;
                    empleado.BHABILITADO = 1;

                    BD.Empleado.Add(empleado);
                    BD.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CEMPLEADO info)
        {
            if(!ModelState.IsValid)
            {
                ListaS();

                ViewBag.Lista_s = Lista_s;
                ViewBag.Lista_c = Lista_c;

                return View(info);
            }
            else
            {
                int ID = info.IDEmpleado;

                using(var BD = new BDPasajeEntities())
                {
                    Empleado emp = (from e in BD.Empleado where e.IIDEMPLEADO.Equals(ID) select e).First();

                    emp.NOMBRE = info.NOMBRE;
                    emp.APPATERNO = info.APPaterno;
                    emp.APMATERNO = info.APMaterno;
                    emp.IIDSEXO = info.IDSexo;
                    emp.FECHACONTRATO = info.FechaContrato;
                    emp.IIDTIPOCONTRATO = info.IDTipoContrato;
                    emp.SUELDO = info.Sueldo;

                    BD.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}