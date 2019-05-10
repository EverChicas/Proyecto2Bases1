using System;
using System.Globalization;
using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class AgregandoDescuentoAProductoController : Controller
    {
        // GET: AgregandoDescuentoAProducto
        public ActionResult vAgregandoDescuento()
        {
            return View();
        }

        public ActionResult agregandoDescuentoAProducto(string nombre, string fecha_ini, string fecha_fin, int porcentaje)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            DateTime local = DateTime.Now;

            fecha_ini += " " + local.Hour.ToString()+":"+local.Minute.ToString()+":"+local.Second.ToString();
            fecha_fin += " " + local.Hour.ToString() + ":" + local.Minute.ToString() + ":" + local.Second.ToString();
            var url = "http://localhost:61291/api/AgregarDescuentoAProducto?";
            string action = string.Format("nombre={0}&fecha_ini={1}&fecha_fin={2}&porcentaje={3}", nombre, fecha_ini, fecha_fin, porcentaje);
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
            return RedirectToAction("vAgregandoDescuento", "AgregandoDescuentoAProducto");
        }





    }
}