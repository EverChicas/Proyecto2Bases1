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
    public class DetallesPorProductoController : Controller
    {
        // GET: DetallesPorProducto
        public ActionResult vDetallesPorProducto()
        {
            return View();
        }

        public ActionResult mostrandoProductos(string nombre)
        {
            IEnumerable<Producto> listado = Lista(nombre);
            Session["DETALLES_POR_PRODUCTO"] = listado;
            return RedirectToAction("vDetallesPorProducto", "DetallesPorProducto");
        }

        public IEnumerable<Producto> Lista(string nombre)
        {
            var url = "http://localhost:61291/api/DetallesPorProducto?";
            string action = string.Format("nombre={0}", nombre);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
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