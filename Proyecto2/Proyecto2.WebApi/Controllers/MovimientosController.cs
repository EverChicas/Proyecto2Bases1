using Proyecto2.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2.WebApi.Controllers
{
    public class MovimientosController : ApiController
    {
        [HttpPost]
        public IEnumerable<Movimiento> MostrarMovmientos(string fecha)
        {
            List<Movimiento> lista = new List<Movimiento>();

            return lista;
        }
    }
}
