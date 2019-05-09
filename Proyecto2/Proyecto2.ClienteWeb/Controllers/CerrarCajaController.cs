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
    public class CerrarCajaController : Controller
    {
        // GET: CerrarCaja
        public ActionResult vCerrarCaja()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CerrarCajaAbierta(string MontoLetras, string Observacion)
        {
            Usuario usuario = Session["USUARIO"] as Usuario;
            Caja cajaAbierta = Session["CAJA"] as Caja;

            Cerrar_Caja enviar = new Cerrar_Caja();
            enviar.Caja = cajaAbierta.caja;
            enviar.Usuario = usuario.Id_Usuario;
            enviar.MontoNumero = cajaAbierta.Monto;
            enviar.MontoLetras = MontoLetras;
            enviar.Observacion = Observacion;

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:61291/");
            var response = cliente.PostAsync("api/CerrarCaja", enviar, new JsonMediaTypeFormatter()).Result;

            if (response.IsSuccessStatusCode)
            {
                Session["CAJA"] = null;
                switch (usuario.Rol_Usuario)
                {
                    case 1:
                        return RedirectToAction("vInicioAdministrador", "Administrador", usuario.Id_Usuario);
                    case 2:
                        return RedirectToAction("vInicioVendedor", "Vendedor", usuario.Id_Usuario);
                    default:
                        return RedirectToAction("vInicio", "Home");
                }
            }
            else
            {
                return RedirectToAction("vAbrirCaja", "AbrirCaja", usuario.Id_Usuario);
            }
        }
    }
}
