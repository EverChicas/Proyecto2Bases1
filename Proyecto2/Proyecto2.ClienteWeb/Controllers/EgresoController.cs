using Newtonsoft.Json;
using Proyecto2.ClienteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2.ClienteWeb.Controllers
{
    public class EgresoController : Controller
    {
        // GET: Egreso
        public ActionResult vEgreso()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var request = cliente.GetAsync("api/ListaPagos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Tipo_Pago>>(resultString);

                return View(listado);
            }

            return View(new List<Caja>());
        }

        public ActionResult IngresarEgreso(int TipoPago,string NoRecibo,double MontoPagar)
        {
            Usuario usuario = Session["USUARIO"] as Usuario;
            Caja cajaAbierta = Session["CAJA"] as Caja;

            if(MontoPagar < cajaAbierta.Monto)
            {
                cajaAbierta.Monto = cajaAbierta.Monto - MontoPagar;
                Session["CAJA"] = cajaAbierta;

                Egreso egreso = new Egreso();
                egreso.Monto = MontoPagar;
                egreso.NoRecibo = NoRecibo;
                egreso.TipoPago = TipoPago;
                egreso.Usuario = usuario.Id_Usuario;
                egreso.Caja = cajaAbierta.caja;

                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:61291/");
                var response = cliente.PostAsync("api/PagoServicio",egreso, new JsonMediaTypeFormatter()).Result;

                if (response.IsSuccessStatusCode)
                {
                    switch (usuario.Rol_Usuario)
                    {
                        case 1:
                            return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
                        case 2:
                            return RedirectToAction("vInicioVendedor", "Vendedor", usuario.Id_Usuario);
                        default:
                            return RedirectToAction("vEgreso", "Egreso");
                    }
                }
                else
                {
                    return RedirectToAction("vEgreso", "Egreso");
                }
            }
            else
            {
                return RedirectToAction("vEgreso", "Egreso");
            }
        }

    }
}