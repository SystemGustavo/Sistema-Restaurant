using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class PuntoDeVentaCache
    {
        public static int IdProducto { get; set; }
        public static double PrecioDeVenta { get; set; }
        public static double PrecioDeCompra{ get; set; }
        public static string VentaGenerada { get; set; }
    }
}
