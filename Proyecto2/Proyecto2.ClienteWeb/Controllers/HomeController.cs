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
    public class HomeController : Controller
    {
        public ActionResult vInicio()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Autorizar(int user,string pass)
        {
            HttpClient cliente = new HttpClient();
            var url = new Uri("http://localhost:61291/api/Login?");
            string action = string.Format("user={0}&pass={1}",user,pass);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "user=" + user.ToString() + "&pass=" + pass);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var resultString = response.Content.ReadAsStringAsync().Result;
                var usuario = JsonConvert.DeserializeObject<Usuario>(resultString);

                if(usuario != null)
                {
                    return View(usuario);
                }
            }

            return View(new Usuario());
        }

    }
}