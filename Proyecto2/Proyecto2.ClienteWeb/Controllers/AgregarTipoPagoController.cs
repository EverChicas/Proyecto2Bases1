using Proyecto2.ClienteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class AgregarTipoPagoController : Controller
    {
        // GET: AgregarTipoPago
        public ActionResult vAgregarTipoPago()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgrgarPago(string nombre)
        {
            Usuario usuario = Session["USUARIO"] as Usuario;

            return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
        }

    }
}