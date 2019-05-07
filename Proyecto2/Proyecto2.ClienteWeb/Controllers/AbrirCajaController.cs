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
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            
            
            var url = "http://localhost:61291/api/Caja?";
            string action = string.Format("usuario={0}&caja={1}",userLogueado.Id_Usuario,caja);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string action2 = string.Format("caja={0}", caja);
                HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, url + action2);
                HttpResponseMessage response2 = HttpInstance.GetHttpClientInstance().SendAsync(request2).Result;
                if (response2.IsSuccessStatusCode)
                {
                    var resultString = response2.Content.ReadAsStringAsync().Result;
                    Caja tmp = JsonConvert.DeserializeObject<Caja>(resultString);
                    Session["CAJA"] = tmp;
                }
                return RedirectToAction("vInicioAdministrador", "Administrador", userLogueado.Id_Usuario);
            }
            else
            {
                return RedirectToAction("vAbrirCaja", "AbrirCaja", userLogueado.Id_Usuario);
            }

            
        }

    }
}