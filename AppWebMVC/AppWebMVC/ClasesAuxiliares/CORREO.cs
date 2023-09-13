using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace AppWebMVC.ClasesAuxiliares
{
    public class CORREO
    {
        public static string enviarCorreo(string correoDestino, string Asunto, string Contenido, string Ruta)
        {
            string Respuesta = "";
            try
            {
                //string correo = ConfigurationManager.AppSettings["correo"];
                //string clave = ConfigurationManager.AppSettings["clave"];
                //string servidor = ConfigurationManager.AppSettings["servidor"];
                //string puerto = ConfigurationManager.AppSettings["puerto"];

                string correo = "moypruebaemisor@gmail.com";
                string clave = "xftbxpxqqijbymqm";
                string servidor = "smtp.gmail.com";
                int puerto = 25;

                MailMessage mail = new MailMessage();
                mail.Subject = Asunto;
                mail.IsBodyHtml = true;
                mail.Body = Contenido;
                mail.From = new MailAddress(correo);
                mail.To.Add(new MailAddress(correoDestino));                

                SmtpClient smtp = new SmtpClient();
                smtp.Host = servidor;
                smtp.EnableSsl = true;
                smtp.Port = puerto;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(correo,clave);
                smtp.Send(mail);

                Respuesta = "1";
            }
            catch(Exception ex) 
            {
                Respuesta = $"Error de clase auxiliar CORREO: {ex}";
            }

            return Respuesta;
        }
    }
}