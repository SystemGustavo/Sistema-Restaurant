using DataAccess.Contracts;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class PuntoDeVentaRepository : RepositoryMaster,IPuntoDeVentaRepository
    {
        public readonly string PaginarProductosPorGrupos;
        public readonly string PaginarGrupos;
        public readonly string MostrarDetalleVenta;

        public PuntoDeVentaRepository()
        {
            PaginarGrupos = "Paginar_grupos";
            PaginarProductosPorGrupos = "paginar_Productos_por_grupo";
            MostrarDetalleVenta = "mostrarDetalleVenta";
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

        public IEnumerable<PaginarGrupoProductosDTO> PaginarGrupoProductos(int desde, int hasta)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Desde", desde));
            parametros.Add(new SqlParameter("@Hasta", hasta));
            var table = ExecuteReaderWithParameters(PaginarGrupos);

            if (table.Rows.Count > 0)
            {
                var listPaginarGrupos = new List<PaginarGrupoProductosDTO>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[2] == DBNull.Value ? null : (byte[])row[2];
                    listPaginarGrupos.Add(new PaginarGrupoProductosDTO
                    {
                        IdLine = Convert.ToInt32(row[0]),
                        Grupo = row[1].ToString(),
                        Icono = img,
                        Estado_de_icono = row[3].ToString(),
                        Estado = row[4].ToString()
                    });
                }
                return listPaginarGrupos;
            }
            else
                return null;
        }

        public IEnumerable<PaginarProductosPorGrupoDTO> PaginarProductosPorGrupo(int idGrupo, int desde, int hasta)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_grupo", idGrupo));
            parametros.Add(new SqlParameter("@Desde", desde));
            parametros.Add(new SqlParameter("@Hasta", hasta));
            var table = ExecuteReaderWithParameters(PaginarProductosPorGrupos);

            if (table.Rows.Count > 0)
            {
                var listPaginarProductosXGrupo = new List<PaginarProductosPorGrupoDTO>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[2] == DBNull.Value ? null : (byte[])row[2];
                    listPaginarProductosXGrupo.Add(new PaginarProductosPorGrupoDTO
                    {
                        Id_Producto = Convert.ToInt32(row[0]),
                        Descripcion = row[1].ToString(),
                        Imagen = img,
                        Precio_de_venta = Convert.ToDouble(row[3]),
                        Estado_imagen = row[4].ToString(),
                        Id_grupo = Convert.ToInt32(row[5]),
                        Precio_de_compra = Convert.ToDouble(row[6]),
                        Estado = row[7].ToString(),
                        Moneda = row[8].ToString()
                    });
                }
                return listPaginarProductosXGrupo;
            }
            else
                return null;
        }
    }
}
