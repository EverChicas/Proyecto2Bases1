using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult vNuevoCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarNuevoCliente(int dpi,string nombre,int nit,string telefono,string correo)
        {
            Usuario usuario = Session["USUARIO"] as Usuario;

            Cliente enviar = new Cliente();
            enviar.DPI = dpi;
            enviar.Nombre = nombre;
            enviar.NIT = nit;
            enviar.Telefono = telefono;
            enviar.Correo = correo;

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var response = cliente.PostAsync("api/NuevoCliente", enviar, new JsonMediaTypeFormatter()).Result;

            if (response.IsSuccessStatusCode)
            {
                switch (usuario.Rol_Usuario)
                {
                    case 1:
                        return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
                    case 2:
                        return RedirectToAction("vInicioVendedor", "Vendedor", usuario.Id_Usuario);
                    default:
                        return RedirectToAction("vInicio", "Home");
                }
            }
            else
            {
                return RedirectToAction("vCliente", "Cliente", usuario.Id_Usuario);
            }
        }

        [HttpGet]
        public ActionResult vHistorialCliente()
        {
            HttpClient tmpCliente = new HttpClient();
            tmpCliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = tmpCliente.GetAsync("api/Clientes").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Cliente>>(resultString);

                Session["LISTA_CLIENTES"] = listado;
            }
            return View("vHistorialCliente");
        }

        [HttpPost]
        public ActionResult historialCliente(int cliente)
        {
            var url = "http://localhost:61291/api/HistorialCliente?";
            string action = string.Format("cliente={0}", cliente);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultString = response.Content.ReadAsStringAsync().Result;
                List<Factura> tmp = JsonConvert.DeserializeObject<List<Factura>>(resultString);
                Session["LISTA_COMPRAS_CLIENTE"] = tmp;
            }

            return View("vHistorialCliente");
        }
        

    }


}