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
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult vRealizarVenta()
        {
            List<DetalleCompra> detalle = Session["DETALLE"] as List<DetalleCompra>;
            if(detalle == null)
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:61291/");
                var request = cliente.GetAsync("api/Productos").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var listado = JsonConvert.DeserializeObject<List<Producto>>(resultString);

                    Session["LISTA_PRODUCTOS"] = listado;
                    Session["DETALLE"] = null;

                }
            }
            return View();
        }

        public ActionResult agregarProducto(int producto,int cantidad)
        {
            List<DetalleCompra> detalle = Session["DETALLE"] as List<DetalleCompra>;
            List<Producto> productos = Session["LISTA_PRODUCTOS"] as List<Producto>;
            if(detalle == null)
            {
                detalle = new List<DetalleCompra>();
            }

            foreach(Producto item in productos)
            {
                if(item.producto == producto)
                {
                    DetalleCompra nuevo = new DetalleCompra();
                    nuevo.producto = item;
                    nuevo.cantidad = cantidad;
                    detalle.Add(nuevo);
                }
            }

            Session["DETALLE"] = detalle;
            Session["LISTA_PRODUCTOS"] = productos;

            return RedirectToAction("vRealizarVenta", "Venta");
        }

        public ActionResult vVender()
        {
            List<DetalleCompra> detalle = Session["DETALLE"] as List<DetalleCompra>;
            if (detalle != null)
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:61291/");
                var request = cliente.GetAsync("api/Clientes").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var listado = JsonConvert.DeserializeObject<List<Cliente>>(resultString);
                    
                    Session["LISTA_CLIENTES"] = listado;
                }
            }
            return View("vVender");
        }
        
        public ActionResult realizarFactura(int cliente)
        {
            List<Cliente> lista = Session["LISTA_CLIENTES"] as List<Cliente>;
            Cliente tmp = null;
            foreach(Cliente item in lista)
            {
                if(item.DPI == cliente)
                {
                    tmp = item;
                }
            }

            if(tmp != null)
            {
                Usuario usuario = Session["USUARIO"] as Usuario;
                Caja cajaAbierta = Session["CAJA"] as Caja;
                List<DetalleCompra> tmpDetalleCompra = Session["DETALLE"] as List<DetalleCompra>;
                
                Factura enviar = new Factura();
                enviar.FechaHora = System.DateTime.Now;
                enviar.Cliente = tmp.DPI;
                enviar.NIT = tmp.NIT;
                enviar.Total = CalcularTotal(tmpDetalleCompra);
                enviar.IVA_Venta = CalcularIVA(enviar.Total);

                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://localhost:61291/");
                var response = clienteHttp.PostAsync("api/NuevaFactura", enviar, new JsonMediaTypeFormatter()).Result;
                

                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;
                    var factura = JsonConvert.DeserializeObject<Factura>(resultString);

                    List<Detalle> detalle = ListaDetalles(tmpDetalleCompra,factura.factura,tmp.DPI);
                    
                    HttpClient detalles = new HttpClient();
                    detalles.BaseAddress = new Uri("http://localhost:61291/");
                    var responseDetalles = detalles.PostAsync("api/NuevosDetallesFactura", detalle, new JsonMediaTypeFormatter()).Result;

                    Venta nueva = new Venta();
                    nueva.venta = 0;
                    nueva.NIT = tmp.NIT;
                    nueva.NombreCliente = tmp.Nombre;
                    nueva.MontoPagado = CalcularTotal(tmpDetalleCompra);
                    nueva.IVA = CalcularIVA(nueva.MontoPagado);
                    nueva.Usuario = usuario.Id_Usuario;
                    nueva.Caja = cajaAbierta.caja;
                    nueva.Factura = factura.factura;

                    VentaFactura detalleVenta = new VentaFactura();
                    detalleVenta.venta = nueva;
                    detalleVenta.factura = factura;

                    HttpClient venta = new HttpClient();
                    venta.BaseAddress = new Uri("http://localhost:61291/");
                    var responseVenta = venta.PostAsync("api/GuardarVenta",detalleVenta, new JsonMediaTypeFormatter()).Result;

                    Session["DETALLE"] = null;
                }

            }
            return View("vRealizarVenta");
        }

        private double CalcularTotal(List<DetalleCompra> detalle)
        {
            double total = 0;
            foreach(DetalleCompra item in detalle)
            {
                total = total + (item.producto.Precio * item.cantidad);
            }
            return total;
        }

        private double CalcularIVA(double total)
        {
            return (total * 12) / 100;
        }

        private List<Detalle> ListaDetalles(List<DetalleCompra> detalle,int factura,int cliente)
        {
            List<Detalle> tmp = new List<Detalle>();

            foreach (DetalleCompra item in detalle)
            {
                Detalle nuevo = new Detalle();
                nuevo.Factura = factura;
                nuevo.Producto = item.producto.producto;
                nuevo.Cliente = cliente;
                nuevo.PrecioUnidad = item.producto.Precio;
                nuevo.Cantidad = item.cantidad;

                tmp.Add(nuevo);
            }

            return tmp;
        }
    }
}
