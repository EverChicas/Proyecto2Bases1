using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace Proyecto2.ClienteWeb.Controllers
{
    public class RegresarController : Controller
    {
        // GET: Regresar
        public ActionResult vRegresar()
        {
            Usuario log = Session["USUARIO"] as Usuario;
            if (log.Rol_Usuario == 1)
                return RedirectToAction("vInicioAdministrador", "Administrador");
            return RedirectToAction("vInicioVendedor", "Vendedor");
        }
    }
}