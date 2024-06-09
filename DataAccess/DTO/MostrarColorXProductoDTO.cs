using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MostrarColorXProductoDTO
    {
        public string ColorHtml { get; set; }
        public int IdColor { get; set; }
        public byte[] Imagen { get; set; }
        public string EstadoImagen { get; set; }
        public double Precio_de_compra { get; set; }
        public double Precio_de_venta { get; set; }
    }
}
