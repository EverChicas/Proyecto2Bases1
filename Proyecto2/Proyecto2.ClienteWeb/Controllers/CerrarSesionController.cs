using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto2.ClienteWeb.Models;
namespace Proyecto2.ClienteWeb.Controllers
{
    public class CerrarSesionController : Controller
    {
        public ActionResult vFinalizado()
        {
            Usuario usuario = Session["USUARIO"] as Usuario;
            Session["USUARIO"] = null;
            return RedirectToAction("vInicio", "Home");
        }
    }
}