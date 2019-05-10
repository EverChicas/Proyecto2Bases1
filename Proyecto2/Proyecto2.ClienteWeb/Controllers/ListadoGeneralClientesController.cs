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
    public class ListadoGeneralClientesController : Controller
    {
        // GET: ListadoGeneralClientes
        public ActionResult vListadoGeneralClientes()
        {
            return View();
        }

        public ActionResult mostrandoClientes()
        {
            IEnumerable<Cliente> listado = Lista();
            Session["LISTADO_GENERAL_CLIENTES"] = listado;
            return RedirectToAction("vListadoGeneralClientes", "ListadoGeneralClientes");
        }

        public IEnumerable<Cliente> Lista()
        {
            var url = "http://localhost:61291/api/ListadoGeneralClientes";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Cliente> lista = new List<Cliente>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Cliente>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }
    }
}