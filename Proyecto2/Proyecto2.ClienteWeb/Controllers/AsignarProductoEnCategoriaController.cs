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
    public class AsignarProductoEnCategoriaController : Controller
    {
        // GET: AsignarProductoEnCategoria
        public ActionResult vAsignarProductoEnCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult asignandoProductoEnCategoria(string nombre, string tipo_categoria)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/AsignarProductoEnCategoria?";
            string action = string.Format("nombre={0}&tipo_categoria={1}", nombre, tipo_categoria);
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
            return RedirectToAction("vAsignarProductoCategoria", "AsignarProductoEnCategoria");
        }

        public IEnumerable<Tipo_Categoria> listaTipo_categorias(Usuario userLogueado)
        {
            //Session["USUARIO"] = userLogueado;
            HttpClient cliente = new HttpClient();
            List<Tipo_Categoria> lista = new List<Tipo_Categoria>();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Tipo_Categorias").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Tipo_Categoria>>(resultString);
                lista = listado;
            }
            return lista;
        }

        public IEnumerable<Producto> listaProductos(Usuario userLogueado)
        {
            //Session["USUARIO"] = userLogueado;
            HttpClient cliente = new HttpClient();
            List<Producto> lista = new List<Producto>();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Productos").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Producto>>(resultString);
                lista = listado;
            }
            return lista;
        }


    }
}