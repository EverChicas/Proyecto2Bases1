using Proyecto2.ClienteWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/Rol_Usuario").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Rol_Usuario>>(resultString);

                return View(listado);


            }

            return View(new List<Rol_Usuario>());
            
        }
    }
}