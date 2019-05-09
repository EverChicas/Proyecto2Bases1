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
    public class AbrirCajaController : Controller
    {
        // GET: AbrirCaja
        public ActionResult vAbrirCaja()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Caja").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Caja>>(resultString);

                return View(listado);
            }

            return View(new List<Caja>());
        }

        [HttpPost]
        public ActionResult SeleccionarCajaAbrir(int caja)
        {
            Usuario usuario = Session["USUARIO"] as Usuario;
            
            
            var url = "http://localhost:61291/api/AbrirCaja?";
            string action = string.Format("usuario={0}&caja={1}",usuario.Id_Usuario,caja);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var url2 = "http://localhost:61291/api/Caja?";
                string action2 = string.Format("caja={0}", caja);
                HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, url2 + action2);
                HttpResponseMessage response2 = HttpInstance.GetHttpClientInstance().SendAsync(request2).Result;
                if (response2.IsSuccessStatusCode)
                {
                    var resultString = response2.Content.ReadAsStringAsync().Result;
                    Caja tmp = JsonConvert.DeserializeObject<Caja>(resultString);
                    Session["CAJA"] = tmp;
                }
                switch (usuario.Rol_Usuario)
                {
                    case 1:
                        Session["USUARIO"] = usuario;
                        return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
                    case 2:
                        Session["USUARIO"] = usuario;
                        return RedirectToAction("vInicioVendedor", "Vendedor", usuario.Id_Usuario);
                    default:
                        return RedirectToAction("vInicio", "Home");
                }
            }
            else
            {
                return RedirectToAction("vAbrirCaja", "AbrirCaja", usuario.Id_Usuario);
            }

            
        }

    }
}