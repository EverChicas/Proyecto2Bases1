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
    public class CompraProveedorController : Controller
    {
        // GET: Compra
        public ActionResult vCompraProveedor()
        {
            return View();
        }


        //Mostrando lista de Productos
        [HttpGet]
        public IEnumerable<Producto> getProductos()
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
        public IEnumerable<Proveedor> getProveedores()
        {
            var url = "http://localhost:61291/api/Proveedor";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Proveedor> lista = new List<Proveedor>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Proveedor>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }








        [HttpPost]
        //public ActionResult realizarCompra(double precioUnitario, double valorCompra, int cantidad, int noFactura, int proveedor, int producto)
        public ActionResult realizarCompra(double precioUnitario, int cantidad, int noFactura, int proveedor, int producto)
        {
            Usuario user = Session["USUARIO"] as Usuario;
            double valorCompra = precioUnitario * cantidad;
            var url = "http://localhost:61291/api/CompraProveedor?";

            string action = string.Format("precioUnitario={0}&valorCompra={1}&cantidad={2}&noFactura={3}&proveedor={4}&usuario={5}&producto={6}", 
                                            precioUnitario.ToString(), valorCompra.ToString(), cantidad,noFactura,proveedor,user.Id_Usuario,producto);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var agregado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (!agregado)
                {
                    return RedirectToAction("vInicioAdministrador", "Administrador");
                }
            }
            return RedirectToAction("vCompraProveedor", "CompraProveedor");
        }



    }
}