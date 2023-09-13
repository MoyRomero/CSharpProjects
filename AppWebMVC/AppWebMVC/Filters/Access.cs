using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebMVC.Models;

namespace AppWebMVC.Filters
{
    public class Access:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Usuario = HttpContext.Current.Session["Usuario"];
            int Existe = 0;

            List<CMENU> Roles = (List<CMENU>)HttpContext.Current.Session["Rol"];

            string Controlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if(Roles != null)
            {
                Existe = (from r in Roles 
                          where r.NombreControlador == Controlador
                          select r).Count();
            }

            if(Usuario == null || Existe == 0)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }

            base.OnActionExecuting(filterContext); 
        }
    }
}