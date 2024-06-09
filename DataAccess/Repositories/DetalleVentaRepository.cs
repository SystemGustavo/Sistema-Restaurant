using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DetalleVentaRepository : RepositoryMaster, IDetalleVentaRepository
    {
        public readonly string InsertarDetalleVentas;
        public readonly string MostrarDetalleVenta;
        public readonly string EditarDetalleVenta;

        public DetalleVentaRepository()
        {
            InsertarDetalleVentas = "insertarDetalle_venta";
            MostrarDetalleVenta = "mostrarDetalleVenta";
            EditarDetalleVenta = "editarEstadoDv";
        }
        
        public int InsertarDetalleVenta(DetalleVentas objDetalleVenta)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idventa", objDetalleVenta.idventa));
            parametros.Add(new SqlParameter("@Id_producto", objDetalleVenta.Id_producto));
            parametros.Add(new SqlParameter("@cantidad", objDetalleVenta.idventa));
            parametros.Add(new SqlParameter("@idventa", objDetalleVenta.cantidad));
            parametros.Add(new SqlParameter("@preciounitario", objDetalleVenta.preciounitario));
            parametros.Add(new SqlParameter("@Estado", objDetalleVenta.Estado));
            parametros.Add(new SqlParameter("@Costo", objDetalleVenta.Costo));
            parametros.Add(new SqlParameter("@Estado_de_pago", objDetalleVenta.Estado_de_pago));
            parametros.Add(new SqlParameter("@Donde_se_consumira", objDetalleVenta.Donde_se_consumira));
            return ExecuteNonQuery(InsertarDetalleVentas);
        }
        public int EditarEstadoDetalleVenta(int idDetalleVenta)
        {
            parametro = new SqlParameter("iddetalleventa", idDetalleVenta);
            return ExecuteNonQueryInParametro(EditarDetalleVenta);
        }
        public IEnumerable<MostrarDetalleVentaDTO> MostrarDetalleVentas(int IdMesa, int IdVenta)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id_mesa", IdMesa));
            parametros.Add(new SqlParameter("@Idventa", IdVenta));
            var table = ExecuteReaderWithParameters(MostrarDetalleVenta);

            if (table.Rows.Count > 0)
            {
                var listDetalleVentas = new List<MostrarDetalleVentaDTO>();
                foreach (DataRow row in table.Rows)
                {
                    listDetalleVentas.Add(new MostrarDetalleVentaDTO
                    {
                        IdProducto = Convert.ToInt32(row[0]),
                        Descripcion = row[1].ToString(),
                        Cantidad = Convert.ToInt32(row[2]),
                        PrecioUnitario = Convert.ToDecimal(row[3]),
                        TotalAPagar = Convert.ToDecimal(row[4]),
                        idDetalleVenta = Convert.ToInt32(row[5]),
                        Estado = row[6].ToString(),
                        IdVenta = Convert.ToInt32(row[7]),
                        ColorHtml = row[8].ToString(),
                        Nota = row[9].ToString(),
                        CodUm = row[10].ToString(),
                        Codigo = row[11].ToString(),
                        CodigoSunat = row[12].ToString()
                    });
                }
                return listDetalleVentas;
            }
            else
                return null;
        }
    }
}
