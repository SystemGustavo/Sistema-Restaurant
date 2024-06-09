using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class DatosDetalleVentasVM
    {
        public int IdDetalleVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Estado { get; set; }
    }
}
