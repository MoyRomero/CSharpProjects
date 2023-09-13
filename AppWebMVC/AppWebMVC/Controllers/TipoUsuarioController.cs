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
    public class TipoUsuarioController : Controller
    {
        CTIPOUSUARIO valores;
        private bool BuscarTipoUsuario(CTIPOUSUARIO oTU)
        {
            bool IDTipoUsuario = true;
            bool Nombre = true;
            bool Descripcion = true;

            if(valores.IDTipoUsuario > 0) IDTipoUsuario = oTU.IDTipoUsuario.ToString().Contains(valores.IDTipoUsuario.ToString());
            
            if(valores.NOMBRE != null) Nombre = oTU.NOMBRE.Contains(valores.NOMBRE);

            if (valores.Descripcion != null) Descripcion = oTU.Descripcion.Contains(valores.Descripcion);

            return (IDTipoUsuario && Nombre && Descripcion);
        }
        // GET: TipoUsuario
        public ActionResult Index(CTIPOUSUARIO oTU)
        {
            valores = oTU;
            List<CTIPOUSUARIO> Lista = null;
            List<CTIPOUSUARIO> ListaFiltrado = null;
            using (var BD = new BDPasajeEntities())
            {               
                    Lista = (from tu in BD.TipoUsuario where tu.BHABILITADO == 1
                             select new CTIPOUSUARIO
                             {
                                 IDTipoUsuario = tu.IIDTIPOUSUARIO,
                                 NOMBRE = tu.NOMBRE,
                                 Descripcion = tu.DESCRIPCION,
                                 BHABILITADO = 1
                             }).ToList();

                if (oTU.IDTipoUsuario == 0 && oTU.NOMBRE == null && oTU.Descripcion == null)
                {
                    ListaFiltrado = Lista;
                }
                else
                {
                    Predicate<CTIPOUSUARIO> Pre = new Predicate<CTIPOUSUARIO>(BuscarTipoUsuario);
                    ListaFiltrado =  Lista.FindAll(Pre);
                }
            }
            return View(ListaFiltrado);
        }
    }
}