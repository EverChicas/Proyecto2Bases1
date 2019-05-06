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
    public class NuevoUsuarioController : Controller
    {
        // GET: NuevoUsuario
        public ActionResult vNuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregandoNuevoUsuario(string nombre, string direccion, string telefono, string correo, int usuario, string password, string rol_usuario)
        {
            var url = "http://localhost:61291/api/NuevoUsuario?";
            string action = string.Format("nombre={0}&direccion={1}&telefono={2}&correo={3}&usuario={4}&password={5}&rol_usuario={6}", nombre, direccion, telefono, correo, usuario, password, rol_usuario);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var agregado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (agregado)
                {
                    return RedirectToAction("vInicioAdministrador", "Administrador");
                }
            }
            return RedirectToAction("vNuevoUsuario", "NuevoUsuario");
        }

        public IEnumerable<Rol_Usuario> listaRoles()
        {
            HttpClient cliente = new HttpClient();
            List<Rol_Usuario> lista = new List<Rol_Usuario>();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Rol_Usuario").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Rol_Usuario>>(resultString);
                lista = listado;
            }
            return lista;
        }
    }
}