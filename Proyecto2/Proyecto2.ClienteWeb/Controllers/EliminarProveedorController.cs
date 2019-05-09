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
    public class EliminarProveedorController : Controller
    {
        // GET: EliminarProveedor
        public ActionResult vEliminarProveedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult eliminandoProveedor(int proveedor)
        {
            var url = "http://localhost:61291/api/Proveedor?";
            string action = string.Format("proveedor={0}", proveedor);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var eliminado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (!eliminado)
                {
                    return RedirectToAction("vInicioAdministrador", "Administrador");
                }
            }
            return RedirectToAction("vEliminarProveedor", "EliminarProveedor");
        }

    }
}