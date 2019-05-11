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
    public class ModificarClienteController : Controller
    {
        // GET: ModificarCliente
        public ActionResult vModificarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult modificacionDeCliente(int dpi, string nombre, int nit, string telefono, string correo)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/ModificarCliente?";
            string action = string.Format("dpi={0}&nombre={1}&nit={2}&telefono={3}&correo={4}", dpi, nombre, nit, telefono, correo);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var modificado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (modificado)
                {
                    if (userLogueado.Rol_Usuario == 1)
                        return RedirectToAction("vInicioAdministrador", "Administrador");
                    else if (userLogueado.Rol_Usuario == 2)
                        return RedirectToAction("vInicioVendedor", "Vendedor");
                }
            }
            return RedirectToAction("vModificarCliente", "ModificarCliente");
        }


        public IEnumerable<Cliente> listaClientes(Usuario userLogueado)
        {
            HttpClient cliente = new HttpClient();
            List<Cliente> lista = new List<Cliente>();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/ListadoGeneralClientes").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Cliente>>(resultString);
                lista = listado;
            }
            return lista;
        }

    }
}