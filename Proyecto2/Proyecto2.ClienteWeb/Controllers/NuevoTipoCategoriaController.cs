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
    public class NuevoTipoCategoriaController : Controller
    {
        // GET: NuevoTipoCategoria
        public ActionResult vNuevoTipoCategoria()
        {
            return View();
        }

        //--
        [HttpPost]
        public ActionResult creandoNuevoTipoCategoria(string nombre)
        {
            Usuario userLogueado = Session["USUARIO"] as Usuario;
            var url = "http://localhost:61291/api/NuevoTipoCategoria?";
            string action = string.Format("nombre={0}", nombre);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var agregado = JsonConvert.DeserializeObject<Boolean>(responsecontent.ToString());
                if (agregado)
                {
                    if(userLogueado.Rol_Usuario == 1)
                        return RedirectToAction("vInicioAdministrador", "Administrador");
                    else if(userLogueado.Rol_Usuario == 2)
                        return RedirectToAction("vInicioVendedor", "Vendedor");
                }
            }
            return RedirectToAction("vNuevoTipoCategoria", "NuevoTipoCategoria");
        }

    }
}