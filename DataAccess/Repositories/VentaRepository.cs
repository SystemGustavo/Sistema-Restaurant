using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VentaRepository : RepositoryMaster,IVentaRepository
    {
        public readonly string InsertarVenta;
        public readonly string MostraridVentaMesa;

        public VentaRepository()
        {
            MostraridVentaMesa = "mostrarIdventaMesa";
            InsertarVenta = "Insertar_ventas";
        }

        public int InsertarVentas(Ventas objVenta)
        {

            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fecha_venta", objVenta.fecha_venta));
            parametros.Add(new SqlParameter("@Id_usuario", objVenta.Id_usuario));
            parametros.Add(new SqlParameter("@Idmovcaja", objVenta.Id_caja));
            parametros.Add(new SqlParameter("@Id_mesa",objVenta.Id_mesa));
            parametros.Add(new SqlParameter("@Numero_personas",objVenta.Numero_personas));
            parametros.Add(new SqlParameter("@Nombrellevar", objVenta.NombreLlevar));
            return ExecuteNonQuery(InsertarVenta);
           
        }

        public int MostrarIdVentaMesa(int IdMesa)
        {
            parametro = new SqlParameter("@Id_mesa", IdMesa);
            return ExecuteScalarWithParameter(MostraridVentaMesa);
        }
    }
}
