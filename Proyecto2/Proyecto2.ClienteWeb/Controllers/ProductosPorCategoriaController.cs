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
    public class ProductosPorCategoriaController : Controller
    {
        // GET: ProductosPorCategoria
        public ActionResult vProductosPorCategoria()
        {
            return View();
        }

        public ActionResult mostrandoProductos(string tipo_categoria)
        {
            IEnumerable<Producto> listado = Lista(tipo_categoria);
            Session["PRODUCTOS_POR_CATEGORIA"] = listado;
            return RedirectToAction("vProductosPorCategoria", "ProductosPorCategoria");   
        }

        public IEnumerable<Producto> Lista(string tipo_categoria)
        {
            var url = "http://localhost:61291/api/ProductosPorCategoria?";
            string action = string.Format("tipo_categoria={0}", tipo_categoria);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Producto> lista = new List<Producto>();
            if(response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Producto>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }
    }
}