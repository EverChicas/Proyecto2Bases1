using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using Proyecto2.ClienteWeb.Models;
namespace Proyecto2.ClienteWeb.Controllers
{
    public class CerrarSesionController : Controller
    {
        public ActionResult vFinalizado()
        {
            if(Session["CAJA"] != null)
            {
                Usuario usuario = Session["USUARIO"] as Usuario;
                Caja cajaAbierta = Session["CAJA"] as Caja;

                Cerrar_Caja enviar = new Cerrar_Caja();
                enviar.Caja = cajaAbierta.caja;
                enviar.Usuario = usuario.Id_Usuario;
                enviar.MontoNumero = cajaAbierta.Monto;
                enviar.MontoLetras = "";
                enviar.Observacion = "";

                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:61291/");
                var response = cliente.PostAsync("api/CerrarCaja", enviar, new JsonMediaTypeFormatter()).Result;

            }
            
            Session["USUARIO"] = null;
            Session["CAJA"] = null;
            Session["LISTA_CLIENTES"] = null;
            Session["LISTA_PRODUCTOS"] = null;
            Session["DETALLE"] = null;
            return RedirectToAction("vInicio", "Home");
        }
    }
}