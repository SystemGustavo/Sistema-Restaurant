using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MostrarProductosPorGrupoDTO
    {
        public int IdProducto1 { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Estado_imagen { get; set; }
        public byte[] Imagen { get; set; }
        public string Moneda { get; set; }
        public double Precio_de_venta { get; set; }
    }
}
