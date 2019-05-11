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
    public class ProductosConDescuentoController : Controller
    {
        // GET: ProductosConDescuento
        public ActionResult vProductosConDescuento()
        {
            return View();
        }

        public ActionResult mostrandoProductos()
        {
            IEnumerable<Descuento> listado = Lista();
            Session["LISTADO_PRODUCTOS_CON_DESCUENTO"] = listado;
            return RedirectToAction("vProductosConDescuento", "ProductosConDescuento");
        }

        public IEnumerable<Descuento> Lista()
        {
            var url = "http://localhost:61291/api/ProductosConDescuento";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Descuento> lista = new List<Descuento>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Descuento>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }
    }
}