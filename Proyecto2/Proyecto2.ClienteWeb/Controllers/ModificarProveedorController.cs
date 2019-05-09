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
    public class ModificarProveedorController : Controller
    {
        // GET: ModificarProveedor
        [HttpGet]
        public ActionResult vModificandoProveedor(int proveedor)
        {
            var url = "http://localhost:61291/api/Proveedor?";
            string action = string.Format("proveedor={0}", proveedor);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Proveedor> lista = new List<Proveedor>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Proveedor>>(responsecontent.ToString());
                lista = listado;
                return View(lista.ElementAt(0));
            }
            return View(new Proveedor());
        }

        public ActionResult vModificarProveedor()
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
                return View(lista);
            }
            return View(new List<Proveedor>());
        }

        [HttpGet]
        public IEnumerable<Proveedor> getProveedor(int proveedor)
        {
            var url = "http://localhost:61291/api/Proveedor?";
            string action = string.Format("proveedor={0}", proveedor);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + action);
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
        public ActionResult modificandoProveedor(int proveedor, string nombre, string direccion, string correo, string telefono)
        {
            var url = "http://localhost:61291/api/Proveedor?";
            string action = string.Format("proveedor={0}&nombre={1}&direccion={2}&correo={3}&telefono={4}",proveedor, nombre, direccion, correo, telefono);
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
            return RedirectToAction("vModificarProveedor", "ModificarProveedor");
        }

    }
}