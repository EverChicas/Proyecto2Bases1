using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class LogGeneralController : Controller
    {


        // GET: LogGeneral
        public ActionResult vLogGeneral()
        {
            return View(getLogGeneral());
        }

        [HttpGet]
        public IEnumerable<Log> getLogGeneral()
        {
            var url = "http://localhost:61291/api/LogMovimientos";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            List<Log> lista = new List<Log>();
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Log>>(responsecontent.ToString());
                lista = listado;
            }
            return lista;
        }

        public ActionResult vMostrandoReporteLogG()
        {
            return View();
        }
        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("vMostrandoReporteLogG") { FileName = Server.MapPath("Log_Report.pdf") }; ;
        }


    }
}