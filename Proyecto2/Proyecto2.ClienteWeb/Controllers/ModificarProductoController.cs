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
    public class ModificarProductoController : Controller
    {
        // GET: ModificarProducto
        public ActionResult vModificarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult modificandoProducto(string nombre, double precio, int unidades_disponibles)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/ModificarProducto?";
            string action = string.Format("nombre={0}&precio={1}&unidades_disponibles={2}", nombre, precio, unidades_disponibles);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
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
            return RedirectToAction("vModificarProducto", "ModificarProducto");
        }
    }
}