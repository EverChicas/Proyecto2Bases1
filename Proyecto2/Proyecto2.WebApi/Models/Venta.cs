using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Venta
    {
        public int venta { get; set; }
        public int NIT { get; set; }
        public string NombreCliente { get; set; }
        public int IVA { get; set; }
        public int MontoPagado { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }
        public int Factura { get; set; }

        public Venta(int venta,int nit,string cliente,int iva,int montoPagado,int usuario,int caja,int factura)
        {
            this.venta = venta;
            this.NIT = nit;
            this.NombreCliente = cliente;
            this.IVA = iva;
            this.MontoPagado = montoPagado;
            this.Usuario = usuario;
            this.Caja = caja;
            this.Factura = factura;
        }
    }
}