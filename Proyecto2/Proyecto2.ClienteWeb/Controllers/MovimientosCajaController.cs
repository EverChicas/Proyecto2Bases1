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
    public class MovimientosCajaController : Controller
    {
        // GET: MovimientosCaja
        public ActionResult vMovimientosCaja()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Movimientos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Movimiento>>(resultString);

                return View(listado);
            }

            return View(new List<Movimiento>());
        }

        [HttpPost]
        public ActionResult MovimientoFecha(string fecha)
        {
            if(!fecha.Equals(""))
            {
                var url = "http://localhost:61291/api/Movimientos?";
                string action = string.Format("fecha={0}", fecha);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
                HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;
                    var listado = JsonConvert.DeserializeObject<List<Movimiento>>(resultString);

                    return View("vMovimientosCaja", listado);
                }
            }

            return View("vMovimientosCaja", new List<Movimiento>());
        }

    }
}