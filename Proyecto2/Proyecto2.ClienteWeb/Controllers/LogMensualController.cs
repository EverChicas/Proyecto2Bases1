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
    public class LogMensualController : Controller
    {
        // GET: LogMensual
        public ActionResult vLogMensual()
        {
            return View();
        }
        public ActionResult mostrandoLogMensual(int mes, int anio)
        {
            IEnumerable<Log> listado = getLogMensual(mes, anio);
            Session["LOG_MENSUAL"] = listado;
            return RedirectToAction("vMostrandoReporteLogM", "LogMensual");
        }

        [HttpGet]
        public IEnumerable<Log> getLogMensual(int mes, int anio)
        {
            var url = "http://localhost:61291/api/LogMovimientos?";
            string action = string.Format("mes={0}&anio={1}", mes, anio);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + action);
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
        public ActionResult vMostrandoReporteLogM()
        {
            return View();
        }
        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("vMostrandoReporteLogM") { FileName = Server.MapPath("Log_Report.pdf") }; ;
        }


    }
}