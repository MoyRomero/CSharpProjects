using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Models;
using AppWebMVC.Filters;



namespace AppWebMVC.Controllers
{
    [Access]
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index( CCLIENTES oClie)
        {
            LlenarSelectSexo();

            ViewBag.lista = ListaSe;

            List<CCLIENTES> ListaClientes = new List<CCLIENTES>();
            
            using(var BD = new BDPasajeEntities())
            {
                if(oClie.IDSexo == 0)
                {
                ListaClientes = (from c in BD.Cliente
                                 join s in BD.Sexo                                
                                 on c.IIDSEXO equals s.IIDSEXO
                                 join u in BD.Usuario
                                 on c.TIPOUSUARIO equals u.TIPOUSUARIO
                                 join tu in BD.TipoUsuario
                                 on u.IIDUSUARIO equals tu.IIDTIPOUSUARIO
                                 where c.BHABILITADO == 1
                                 orderby c.IIDCLIENTE
                                select new CCLIENTES
                                {
                                    IDCliente = c.IIDCLIENTE,
                                    NOMBRE = c.NOMBRE,
                                    Appaterno = c.APPATERNO,
                                    Apmaterno = c.APMATERNO,
                                    Sexo = s.NOMBRE,
                                    TelefonoFijo = c.TELEFONOFIJO,
                                    TelefonoCel = c.TELEFONOCELULAR,
                                    BCUSUARIO = c.bTieneUsuario,
                                    TipoUsuario = c.bTieneUsuario == null ? "SIN USUARIO": tu.NOMBRE
                                }).ToList();

                }
                else
                {
                    ListaClientes = (from c in BD.Cliente
                                     join s in BD.Sexo
                                     on c.IIDSEXO equals s.IIDSEXO
                                     join u in BD.Usuario
                                     on c.TIPOUSUARIO equals u.TIPOUSUARIO
                                     join tu in BD.TipoUsuario
                                     on u.IIDUSUARIO equals tu.IIDTIPOUSUARIO
                                     where c.BHABILITADO == 1 &&
                                     c.IIDSEXO == oClie.IDSexo 
                                     orderby c.IIDCLIENTE
                                     select new CCLIENTES
                                     {
                                         IDCliente = c.IIDCLIENTE,
                                         NOMBRE = c.NOMBRE,
                                         Appaterno = c.APPATERNO,
                                         Apmaterno = c.APMATERNO,
                                         Sexo = s.NOMBRE,
                                         TelefonoFijo = c.TELEFONOFIJO,
                                         TelefonoCel = c.TELEFONOCELULAR,
                                         BCUSUARIO = c.bTieneUsuario,
                                         TipoUsuario = c.bTieneUsuario == null ? "SIN USUARIO" : tu.NOMBRE
                                     }).ToList();
                }
            }

            return View(ListaClientes);
        }

        List<SelectListItem> ListaSe;
        private void LlenarSelectSexo()
        {
            using(var BD = new BDPasajeEntities())
            {
                ListaSe = (from s in BD.Sexo
                           where s.BHABILITADO == 1
                          select new SelectListItem
                          {
                              Text = s.NOMBRE,
                              Value = s.IIDSEXO.ToString()                              
                          }).ToList();
                ListaSe.Insert(0, new SelectListItem { Text = "SELECCIONA SEXO", Value = "" });
                ListaSe.Insert(1, new SelectListItem { Text = "QUITAR FILTRO", Value = "" });
            }
        }
        public ActionResult Agregar()
        {
            LlenarSelectSexo();

            ViewBag.lista = ListaSe;

            return View();
        }

        public ActionResult Editar(int id) 
        {
            LlenarSelectSexo();

            ViewBag.lista = ListaSe;

            CCLIENTES cli = new CCLIENTES();

            using(var BD = new BDPasajeEntities())
            {
                Cliente Cli = (from c in BD.Cliente where c.IIDCLIENTE == id select c).First();

                cli.IDCliente = Cli.IIDCLIENTE;
                cli.NOMBRE = Cli.NOMBRE;
                cli.Appaterno = Cli.APPATERNO;
                cli.Apmaterno = Cli.APMATERNO;
                cli.Email = Cli.EMAIL;
                cli.Direccion = Cli.DIRECCION;
                cli.IDSexo = (int) Cli.IIDSEXO;
                cli.TelefonoFijo = Cli.TELEFONOFIJO;
                cli.TelefonoCel = Cli.TELEFONOCELULAR;
            }

            return View(cli);
        }

        public ActionResult Eliminar(int idElemento)
        {
            using (var BD = new BDPasajeEntities())
            {
                Cliente X = (from x in BD.Cliente where x.IIDCLIENTE.Equals(idElemento) select x).First();

                X.BHABILITADO = 0;

                BD.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Agregar(CCLIENTES info)
        {
            int NombreRepetido = 0;

            using(var BD = new BDPasajeEntities())
            {
                NombreRepetido = (from c in BD.Cliente 
                                  where c.NOMBRE.Equals(info.NOMBRE) &&
                                  c.APPATERNO.Equals(info.Appaterno) &&
                                  c.APMATERNO.Equals(info.Apmaterno)
                                  select c).Count();    
            }


            if(!ModelState.IsValid || NombreRepetido > 0)
            {
                if (NombreRepetido > 0) info.MensajeErrorNombres = $"Ya se ha registrado un cliente con el nombre de: {info.NOMBRE} {info.Appaterno} {info.Apmaterno}.";

                LlenarSelectSexo();
                ViewBag.lista = ListaSe;
                return View(info);
            }
            else
            {
                using(var BD = new BDPasajeEntities())
                {
                    Cliente cli = new Cliente();

                    cli.NOMBRE = info.NOMBRE;
                    cli.APPATERNO = info.Appaterno;
                    cli.APMATERNO = info.Apmaterno;
                    cli.EMAIL = info.Email;
                    cli.DIRECCION = info.Direccion;
                    cli.IIDSEXO = info.IDSexo;
                    cli.TELEFONOFIJO = info.TelefonoFijo;
                    cli.TELEFONOCELULAR = info.TelefonoCel;
                    cli.BHABILITADO = 1;

                    BD.Cliente.Add(cli);

                    BD.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CCLIENTES info)
        {
            int NombreRepetido = 0;
            int ID = info.IDCliente;

            using (var BD = new BDPasajeEntities())
            {
                NombreRepetido = (from c in BD.Cliente
                                  where c.NOMBRE.Equals(info.NOMBRE) &&
                                  c.APPATERNO.Equals(info.Appaterno) &&
                                  c.APMATERNO.Equals(info.Apmaterno) &&
                                  !c.IIDCLIENTE.Equals(ID)
                                  select c).Count();
            }


            if (!ModelState.IsValid || NombreRepetido > 0)
            {
                if (NombreRepetido > 0) info.MensajeErrorNombres = $"Ya se ha registrado un cliente con el nombre de: {info.NOMBRE} {info.Appaterno} {info.Apmaterno}.";

                LlenarSelectSexo();

                ViewBag.lista = ListaSe;

                return View(info);
            }
            else
            {  
                using(var BD = new BDPasajeEntities())
                {
                    Cliente cli = (from c in BD.Cliente where c.IIDCLIENTE.Equals(ID) select c).First();

                    cli.NOMBRE = info.NOMBRE;
                    cli.APPATERNO = info.Appaterno;
                    cli.APMATERNO = info.Apmaterno;
                    cli.IIDSEXO = info.IDSexo;
                    cli.TELEFONOFIJO = info.TelefonoFijo;
                    cli.TELEFONOCELULAR = info.TelefonoCel;
                    cli.EMAIL = info.Email;

                    BD.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}