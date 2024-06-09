using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MostrarDetalleVentaDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalAPagar { get; set; }
        public int idDetalleVenta { get; set; }
        public string Estado { get; set; }
        public int IdVenta { get; set; }
        public string ColorHtml { get; set; }
        public string Nota { get; set; }
        public string CodUm { get; set; }
        public string Codigo { get; set; }
        public string CodigoSunat { get; set; }
    }
}
