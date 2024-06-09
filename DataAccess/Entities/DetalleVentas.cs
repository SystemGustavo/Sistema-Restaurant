using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DetalleVentas
    {
        public int iddetalle_venta { get; set; }
        public int idventa { get; set; }
        public int Id_producto { get; set; }
        public double cantidad { get; set; }
        public double preciounitario { get; set; }
        public double Total_a_pagar { get; set; }
        public string Estado { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public string Estado_de_pago { get; set; }
        public string Donde_se_consumira { get; set; }
        public string Nota { get; set; }
    }
}
