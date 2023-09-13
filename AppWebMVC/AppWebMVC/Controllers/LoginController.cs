using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using AppWebMVC.ClasesAuxiliares;

namespace AppWebMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public string Login(CUSUARIO oUs)
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
                int ExisteUsuario = 0;

                string NombreUsuario = oUs.NombreUsuario;
                string ContraCif = CCIF(oUs.Contrasena);
                try
                {

                    using (var BD = new BDPasajeEntities())
                    {
                        ExisteUsuario = (from r in BD.Usuario 
                                         where r.NOMBREUSUARIO == NombreUsuario
                                         && r.CONTRA == ContraCif
                                         select r).Count();


                        if (ExisteUsuario > 0)
                        {
                            Usuario oUsuario = (from u in BD.Usuario
                                                where u.NOMBREUSUARIO == NombreUsuario
                                                && u.CONTRA == ContraCif
                                                select u).First();

                            Session["Usuario"] = oUsuario;

                            List<CMENU> ListaMenu = (from u in BD.Usuario
                                                     join r in BD.Rol
                                                     on u.IIDROL equals r.IIDROL
                                                     join rp in BD.RolPagina
                                                     on r.IIDROL equals rp.IIDROL
                                                     join p in BD.Pagina
                                                     on rp.IIDPAGINA equals p.IIDPAGINA
                                                     where r.IIDROL == oUsuario.IIDROL
                                                     && rp.IIDROL == oUsuario.IIDROL
                                                     && u.IIDUSUARIO == oUsuario.IIDUSUARIO
                                                     select new CMENU
                                                     {
                                                         NombreAccion = p.ACCION,
                                                         NombreControlador = p.CONTROLADOR,
                                                         Mensaje = p.MENSAJE
                                                     }).ToList();

                            Session["Rol"] = ListaMenu;

                            if(oUsuario.TIPOUSUARIO == "C")
                            {
                                CDATOSLOGIN Datos = (from x in BD.Cliente
                                                     where x.IIDCLIENTE == oUsuario.IID
                                                     select new CDATOSLOGIN
                                                     {
                                                         NombreCompleto = x.NOMBRE + " " + x.APPATERNO + " " + x.APMATERNO,
                                                         CorreoElectronico = x.EMAIL,
                                                         TipoDeUsuario = x.TIPOUSUARIO,
                                                         NombreDeUsuario = oUsuario.NOMBREUSUARIO
                                                     }).First();

                                Session["DataLogin"] = Datos;
                            }
                            else
                            {
                                CDATOSLOGIN Datos = (from x in BD.Empleado
                                                     where x.IIDEMPLEADO == oUsuario.IID
                                                     select new CDATOSLOGIN
                                                     {
                                                         NombreCompleto = x.NOMBRE + " " + x.APPATERNO + " " + x.APMATERNO,
                                                        // CorreoElectronico = x.EMAIL,
                                                         TipoDeUsuario = x.TIPOUSUARIO,
                                                         NombreDeUsuario = oUsuario.NOMBREUSUARIO
                                                     }).First();

                                Session["DataLogin"] = Datos;
                            }                        

                            Respuesta = "Iniciando...";
                        }
                        else
                        {
                            Respuesta = "";                      
                        }
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                    return Respuesta;
                }
            }

            return Respuesta;
        }
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            Session["Rol"] = null;

            return RedirectToAction("Index");
        }
        public string RecuperarContra(string correo, string IDTIPO, string TelefonoCelular)
        {
            string Respuesta = "";

            try
            {

                using(var BD = new BDPasajeEntities())
                {
                    if(IDTIPO == "C")
                    {
                        int Cantidad = 0;
                        int idCliente = 0;

                        Cantidad = (from c in BD.Cliente
                                  where c.EMAIL == correo
                                  && c.TELEFONOCELULAR == TelefonoCelular
                                  select c).Count();

                        if(Cantidad == 0)
                        {
                            Respuesta = $"No existe una cuenta registrada con el correo: {correo}";                        
                        }
                        else
                        {
                            idCliente = (from c in BD.Cliente
                                         where c.EMAIL == correo
                                         && c.TELEFONOCELULAR == TelefonoCelular
                                         select c).First().IIDCLIENTE;

                            int TieneUsuario = (from u in BD.Usuario
                                               where u.IID == idCliente
                                               && u.TIPOUSUARIO == "C"
                                               select u).Count();

                            if(TieneUsuario == 0)
                            {
                                Respuesta = $"La persona registrada con el correo {correo}, no tiene usuario.";
                            }
                            else
                            {
                                Usuario usuario = (from u in BD.Usuario
                                                   where u.IID == idCliente
                                                   && u.TIPOUSUARIO == "C"
                                                   select u).First();
                            
                                Random NumR = new Random();

                                int n1 = NumR.Next(0,9);
                                int n2 = NumR.Next(0,9);
                                int n3 = NumR.Next(0,9);

                                //string NuevaContra = CCIF("12345");

                                string NuevaContra = $"{n1}{n2}{n3}";

                                string Contenido = $"Se ha reestablecido su contraseña. Su nueva contraseña es: {NuevaContra}";

                                usuario.CONTRA = CCIF(NuevaContra);

                                Respuesta = BD.SaveChanges().ToString();

                                Respuesta = CORREO.enviarCorreo(correo, "Restauración de Contraseña", Contenido, "").ToString();                        
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
                return Respuesta;
            }

            return Respuesta;
        }

        public string CCIF(string SEn)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] byteSEn = Encoding.Default.GetBytes(SEn);
            byte[] byteSEnCif = sha.ComputeHash(byteSEn);
            string SEnC = BitConverter.ToString(byteSEnCif).Replace("-", "");

            return SEnC;
        }
    }
}