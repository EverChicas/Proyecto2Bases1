using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public ActionResult AgregarPago(string NombrePago)
        {
            var url = "http://localhost:61291/api/AgregarTipoPago?";
            string action = string.Format("nombre={0}", NombrePago);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("vInicioAdministrador", "Administrador");
            }
            else
            {
                return RedirectToAction("vAgregarTipoPago","AgregarTipoPago");
            }
            
        }
    }
}