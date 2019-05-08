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
    public class InventarioGeneralController : Controller
    {
        // GET: InventarioGeneral
        public ActionResult vInventarioGeneral()
        {
            return View();
        }

        public ActionResult mostrandoProductos()
        {
            IEnumerable<Producto> listado = Lista();
            Session["INVENTARIO_GENERAL"] = listado;
            return RedirectToAction("vInventarioGeneral", "InventarioGeneral");
        }


        public IEnumerable<Producto> Lista()
        {
            var url = "http://localhost:61291/api/InventarioGeneral";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Producto> lista = new List<Producto>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Producto>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }
    }
}