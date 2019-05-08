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
    public class NuevoProveedorController : Controller
    {
        // GET: NuevoProveedor
        public ActionResult vNuevoProveedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregandoNuevoProveedor(string nombre, string direccion, string correo, string telefono)
        {
            var url = "http://localhost:61291/api/Proveedor?";
            string action = string.Format("nombre={0}&direccion={1}&correo={2}&telefono={3}", nombre, direccion, correo, telefono);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var agregado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (agregado)
                {
                    return RedirectToAction("vInicioAdministrador", "Administrador");
                }
            }
            return RedirectToAction("vNuevoUsuario", "NuevoUsuario");
        }


    }
}