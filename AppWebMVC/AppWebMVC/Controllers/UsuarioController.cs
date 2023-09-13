using AppWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using System.Transactions;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using AppWebMVC.Filters;


namespace AppWebMVC.Controllers
{
    [Access]
    public class UsuarioController : Controller
    {
        List<SelectListItem> ListaRol = null;
        List<SelectListItem> ListaTU = null;       
        List<SelectListItem> ListaPersonas = new List<SelectListItem>();

        // GET: Usuario
        public void RefillList()
        {
            using (var BD = new BDPasajeEntities())
            {
                ListaRol = (from lr in BD.Rol
                            where lr.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Value = lr.IIDROL.ToString(),
                                Text = lr.NOMBRE
                            }).ToList();
                ListaRol.Insert(0, new SelectListItem { Text = "SELECCIONA ROL", Value = "" });


                ListaTU = (from TUR in BD.TIPOUSUARIOREGISTRO
                           select new SelectListItem
                           {
                               Value = TUR.TIPOUSUARIO,
                               Text = TUR.NOMBRE
                           }).ToList();
                ListaTU.Insert(0, new SelectListItem { Text = "SELECCIONA TIPO USUARIO", Value = "" });


                List<SelectListItem> ListaID_E = (from e in BD.Empleado
                                     where e.BHABILITADO == 1 
                                     && e.bTieneUsuario != 1
                                     select new SelectListItem
                                     {
                                         Value = e.IIDEMPLEADO.ToString(),
                                         Text = e.NOMBRE + " " + e.APPATERNO + " " + e.APMATERNO + "(E)"
                                     }).ToList();

                List<SelectListItem> ListaID_C = (from c in BD.Cliente
                                     where c.BHABILITADO == 1
                                     & c.bTieneUsuario != 1
                                     select new SelectListItem
                                     {
                                         Value = c.IIDCLIENTE.ToString(),
                                         Text = c.NOMBRE + " " + c.APPATERNO + " " + c.APMATERNO + "(C)"
                                     }).ToList();

                ListaPersonas.Insert(0, new SelectListItem { Text = "SELECCIONA PERSONA", Value = "" });
                ListaPersonas.AddRange(ListaID_E);
                ListaPersonas.AddRange(ListaID_C);
            }
        }
        public ActionResult Index() { 
            RefillList();
            ViewBag.ListaRol = ListaRol;
            ViewBag.ListaTU  = ListaTU;
            ViewBag.Listapersonas = ListaPersonas;

            List<CUSUARIO> ListaUsuarios = new List<CUSUARIO>();            

            using(var BD = new BDPasajeEntities())
            {
                List<CUSUARIO> ListaEmpleados = (from u in BD.Usuario
                                                 join e in BD.Empleado
                                                 on u.IID equals e.IIDEMPLEADO
                                                 join r in BD.Rol
                                                 on u.IIDROL equals r.IIDROL
                                                 where e.BHABILITADO == 1
                                                 && u.bhabilitado == 1
                                                 && e.bTieneUsuario == 1
                                                 && e.TIPOUSUARIO == "E"
                                                 select new CUSUARIO
                                                 {
                                                     IDUsuario = u.IIDUSUARIO,
                                                     NombreUsuario = u.NOMBREUSUARIO,
                                                     TipoUsuario = u.TIPOUSUARIO,
                                                     NombrePersona = e.NOMBRE+ " " + e.APPATERNO + "  " + e.APMATERNO,
                                                     NombreRol = r.NOMBRE
                                                 }).ToList();

                List<CUSUARIO> ListaClientes = (from u in BD.Usuario
                                                join c in BD.Cliente
                                                on u.IID equals c.IIDCLIENTE
                                                join r in BD.Rol
                                                on u.IIDROL equals r.IIDROL
                                                where c.BHABILITADO == 1
                                                && u.bhabilitado == 1
                                                && c.bTieneUsuario == 1
                                                && c.TIPOUSUARIO == "C"
                                                select new CUSUARIO
                                                {
                                                    IDUsuario = u.IIDUSUARIO,
                                                    NombreUsuario = u.NOMBREUSUARIO,
                                                    TipoUsuario = u.TIPOUSUARIO,
                                                    NombrePersona = c.NOMBRE+ " " + c.APPATERNO + "  " + c.APMATERNO,
                                                    NombreRol = r.NOMBRE
                                                }).ToList();

                ListaUsuarios.AddRange(ListaEmpleados);
                ListaUsuarios.AddRange(ListaClientes);
            }

            return View(ListaUsuarios);
        }
        public ActionResult Filtro(string NombrePersona)
        {
            List<CUSUARIO> ListaUsuarios = new List<CUSUARIO>();
            List<CUSUARIO> ListaClientes = new List<CUSUARIO>();
            List<CUSUARIO> ListaEmpleados = new List<CUSUARIO>();

            using (var BD = new BDPasajeEntities())
            {
                if (NombrePersona == null)
                {
                    ListaEmpleados = (from u in BD.Usuario
                                      join e in BD.Empleado
                                      on u.IID equals e.IIDEMPLEADO
                                      join r in BD.Rol
                                      on u.IIDROL equals r.IIDROL
                                      where e.BHABILITADO == 1
                                      && u.bhabilitado == 1
                                      && e.bTieneUsuario == 1
                                      && e.TIPOUSUARIO == "E"
                                      select new CUSUARIO
                                      {
                                          IDUsuario = u.IIDUSUARIO,
                                          NombreUsuario = u.NOMBREUSUARIO,
                                          TipoUsuario = u.TIPOUSUARIO,
                                          NombrePersona = e.NOMBRE + " " + e.APPATERNO + "  " + e.APMATERNO,
                                          NombreRol = r.NOMBRE
                                      }).ToList();

                    ListaClientes = (from u in BD.Usuario
                                     join c in BD.Cliente
                                     on u.IID equals c.IIDCLIENTE
                                     join r in BD.Rol
                                     on u.IIDROL equals r.IIDROL
                                     where c.BHABILITADO == 1
                                     && u.bhabilitado == 1
                                     && c.bTieneUsuario == 1
                                     && c.TIPOUSUARIO == "C"
                                     select new CUSUARIO
                                     {
                                         IDUsuario = u.IIDUSUARIO,
                                         NombreUsuario = u.NOMBREUSUARIO,
                                         TipoUsuario = u.TIPOUSUARIO,
                                         NombrePersona = c.NOMBRE + " " + c.APPATERNO + "  " + c.APMATERNO,
                                         NombreRol = r.NOMBRE
                                     }).ToList();
                }

                else
                {
                    ListaEmpleados = (from u in BD.Usuario
                                      join e in BD.Empleado
                                      on u.IID equals e.IIDEMPLEADO
                                      join r in BD.Rol
                                      on u.IIDROL equals r.IIDROL
                                      where e.BHABILITADO == 1
                                      && u.bhabilitado == 1
                                      && e.bTieneUsuario == 1
                                      && e.TIPOUSUARIO == "E" &&
                                      (e.NOMBRE.Contains(NombrePersona)
                                      || e.APPATERNO.Contains(NombrePersona)
                                      || e.APMATERNO.Contains(NombrePersona))
                                      select new CUSUARIO
                                      {
                                          IDUsuario = u.IIDUSUARIO,
                                          NombreUsuario = u.NOMBREUSUARIO,
                                          TipoUsuario = u.TIPOUSUARIO,
                                          NombrePersona = e.NOMBRE + " " + e.APPATERNO + "  " + e.APMATERNO,
                                          NombreRol = r.NOMBRE
                                      }).ToList();

                    ListaClientes = (from u in BD.Usuario
                                     join c in BD.Cliente
                                     on u.IID equals c.IIDCLIENTE
                                     join r in BD.Rol
                                     on u.IIDROL equals r.IIDROL
                                     where c.BHABILITADO == 1
                                     && u.bhabilitado == 1
                                     && c.bTieneUsuario == 1
                                     && c.TIPOUSUARIO == "C" &&
                                     (c.NOMBRE.Contains(NombrePersona)
                                     || c.APPATERNO.Contains(NombrePersona)
                                     || c.APMATERNO.Contains(NombrePersona))
                                     select new CUSUARIO
                                     {
                                         IDUsuario = u.IIDUSUARIO,
                                         NombreUsuario = u.NOMBREUSUARIO,
                                         TipoUsuario = u.TIPOUSUARIO,
                                         NombrePersona = c.NOMBRE + " " + c.APPATERNO + "  " + c.APMATERNO,
                                         NombreRol = r.NOMBRE
                                     }).ToList();
                }

                ListaUsuarios.AddRange(ListaEmpleados);
                ListaUsuarios.AddRange(ListaClientes);
            }
            return PartialView("_TablaUsuarios", ListaUsuarios);
        }
        public ActionResult Editar(int IDPersona)
        {
            using(var BD = new BDPasajeEntities())
            {

            }
            return PartialView("_TablaUsuarios");
        }
        public string CCIF(string SEn)
        {
            SHA256Managed Sha = new SHA256Managed();
            byte[] byteSEn = Encoding.Default.GetBytes(SEn);
            byte[] byteSEnCif = Sha.ComputeHash(byteSEn);
            string SEnC = BitConverter.ToString(byteSEnCif).Replace("-","");

            return SEnC;
        }
        public string Guardar(CUSUARIO oUs, int Confirmacion, string TipoUsuarioPersona)
        {  
            string respuesta = "";

            if (!ModelState.IsValid)
            {
                var consulta = (from es in ModelState.Values
                                from er in es.Errors
                                select er.ErrorMessage).ToList();

                respuesta += "<ul class=\"FormularioUl\">";

                foreach (var er in consulta) respuesta += "<li class=\"FormularioLi\">" + er + "</li>";

                respuesta += "</ul>";

                return respuesta;
            }
            try
            {
                using (var BD = new BDPasajeEntities())
                {
                    int Repetido = 0;

                    using(var Transaction = new TransactionScope())
                    {
                        if (Confirmacion == -1)
                        {
                            Repetido = (from r in BD.Usuario
                                        where r.NOMBREUSUARIO == oUs.NombreUsuario
                                        select r).Count();

                            if(Repetido > 0)
                            {
                                respuesta = $"<ul class=\"FormularioUl\"> <li class=\"FormularioLi\">Ya existe un el nombre de usuario: {oUs.NombreUsuario} registrado en la base de datos.</li> </ul>";

                                return respuesta;
                            }

                            string letraTipoUsuario = 
                                TipoUsuarioPersona.Substring(TipoUsuarioPersona.Length - 2, 1);

                            Usuario u = new Usuario();

                            u.NOMBREUSUARIO = oUs.NombreUsuario;
                            u.CONTRA = CCIF(oUs.Contrasena);
                            u.TIPOUSUARIO = oUs.TipoUsuario;
                            u.IID = oUs.ID;
                            u.IIDROL = oUs.IDRol;
                            u.bhabilitado = 1;

                            BD.Usuario.Add(u);

                            respuesta = BD.SaveChanges().ToString();

                            if (letraTipoUsuario == "E")
                            {
                                var consulta = (from e in BD.Empleado
                                                where e.IIDEMPLEADO == oUs.ID
                                                select e).ToList();

                                foreach (var c in consulta) c.bTieneUsuario = 1;

                                respuesta = BD.SaveChanges().ToString();
                            }

                            if (letraTipoUsuario == "C")
                            {
                                var consulta = (from e in BD.Cliente
                                                where e.IIDCLIENTE == oUs.ID
                                                select e).ToList();

                                foreach (var c in consulta) c.bTieneUsuario = 1;

                                respuesta = BD.SaveChanges().ToString();
                            }
                            
                            if (respuesta == "0") respuesta = "";

                            Transaction.Complete();                        
                        }
                        else
                        {
                            Usuario u = (from r in BD.Usuario
                                            where r.IIDUSUARIO == Confirmacion
                                            select r).First();

                            u.NOMBREUSUARIO = oUs.NombreUsuario;
                            u.IIDROL = oUs.IDRol;

                            respuesta = BD.SaveChanges().ToString();

                            Transaction.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return respuesta;
        }
        public int Eliminar(int Confirmacion)
        {
            int respuesta = 0;

            using (var BD = new BDPasajeEntities())
            {

                Usuario u = (from us in BD.Usuario
                             where us.IIDUSUARIO == Confirmacion
                             select us).First();

                u.bhabilitado = 0;

                respuesta = BD.SaveChanges();
            }

            return respuesta;
        }
        public JsonResult CapturarDatos(int IDUsuario)
        {
            CUSUARIO u = new CUSUARIO();

            using (var BD = new BDPasajeEntities())
            {
                Usuario U = (from r in BD.Usuario
                           where r.IIDUSUARIO == IDUsuario
                             select r).First();

                u.NombreUsuario = U.NOMBREUSUARIO;
                u.IDRol = (int)U.IIDROL;
            }

            return Json(u, JsonRequestBehavior.AllowGet);
        }
    }
}