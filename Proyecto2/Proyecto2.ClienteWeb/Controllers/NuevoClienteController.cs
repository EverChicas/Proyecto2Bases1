using System;
using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class NuevoClienteController : Controller
    {
        // GET: NuevoCliente
        public ActionResult vNuevoCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult creandoNuevoCliente(int dpi, string nombre, int nit, string telefono, string correo)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/NuevoCliente?";
            string action = string.Format("dpi={0}&nombre={1}&nit={2}&telefono={3}&correo={4}", dpi, nombre, nit, telefono, correo);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var agregado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (agregado)
                {
                    if (userLogueado.Rol_Usuario == 1)
                        return RedirectToAction("vInicioAdministrador", "Administrador");
                    else if (userLogueado.Rol_Usuario == 2)
                        return RedirectToAction("vInicioVendedor", "Vendedor");
                }
            }
            return RedirectToAction("vNuevoCliente", "NuevoCliente");
        }

    }
}