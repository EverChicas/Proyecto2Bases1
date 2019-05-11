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
    public class LogPorFechaController : Controller
    {
        // GET: LogPorFecha
        public ActionResult vLogPorFecha()
        {
            return View();
        }
        public ActionResult mostrandoLogPorFecha(DateTime fecha)
        {
            IEnumerable<Log> listado = getLogPorFecha(fecha);
            Session["LOG_FECHA"] = listado;
            return RedirectToAction("vLogPorFecha", "LogPorFecha");
        }

        [HttpGet]
        public IEnumerable<Log> getLogPorFecha(DateTime fecha)
        {
            string fecha_ = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            var url = "http://localhost:61291/api/LogMovimientos?";
            string action = string.Format("fecha={0}", fecha_);
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
        public ActionResult vMostrandoReporteLogF()
        {
            return View();
        }
        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("vMostrandoReporteLogF") { FileName = Server.MapPath("Log_Report.pdf") }; ;
        }




    }
}