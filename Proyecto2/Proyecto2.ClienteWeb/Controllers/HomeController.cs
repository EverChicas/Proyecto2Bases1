using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult vInicio()
        {
            return View();
        }
        //LOGIN USUARIO
        [HttpPost]
        public ActionResult Autorizar(int user, string password)
        {
            var url = "http://localhost:61291/api/LoginUsuario?";
            string action = string.Format("user={0}&password={1}", user, password);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var usuario = JsonConvert.DeserializeObject<Usuario>(responsecontent.ToString());
                switch (usuario.Rol_Usuario)
                {
                    case 1:
                        Session["USUARIO"] = usuario;
                        return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
                    case 2:
                        Session["USUARIO"] = usuario;
                        return RedirectToAction("vInicioVendedor", "Vendedor", usuario.Id_Usuario);
                }
            }
            return RedirectToAction("vInicio", "Home");
        }


    }
}