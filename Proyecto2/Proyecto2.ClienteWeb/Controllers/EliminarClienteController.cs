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
    public class EliminarClienteController : Controller
    {
        // GET: EliminarCliente
        public ActionResult vEliminarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult eliminandoCliente(int dpi)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/EliminarCliente?";
            string action = string.Format("dpi={0}", dpi);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var eliminado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if(eliminado)
                {
                    if (userLogueado.Rol_Usuario == 1)
                        return RedirectToAction("vInicioAdministrador", "Administrador");
                    else
                        return RedirectToAction("vInicioVendedor", "Vendedor");
                }
            }
            return RedirectToAction("vEliminarCliente", "EliminarCliente");
        }
    }
}