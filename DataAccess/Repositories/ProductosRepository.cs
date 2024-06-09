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
    public class ProductosRepository : RepositoryMaster, IProductosRepository
    {
        public readonly string InsertarProducto;
        public readonly string EditarProducto;
        public readonly string EliminarProducto;
        public readonly string RestaurarProducto;
        public readonly string ObtenerProductoPorId;
        public readonly string MostrarProductosPorGrupos;
        public readonly string MostrarColorXProducto;
        public ProductosRepository()
        {
            MostrarProductosPorGrupos = "mostrar_Productos_por_grupo";
            InsertarProducto = "insertar_Producto";
            EditarProducto = "editarProductos";
            EliminarProducto = "eliminarProductos";
            RestaurarProducto = "RestaurarProductos";
            MostrarColorXProducto = "mostrarColorxProducto";
            ObtenerProductoPorId = "ObtenerProductoXId";
        }

        public void Add(Productos entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Descripcion", entity.Descripcion));
            parametros.Add(new SqlParameter("@Id_grupo", entity.Id_grupo));
            parametros.Add(new SqlParameter("@Precio_de_venta", entity.Precio_de_venta));
            parametros.Add(new SqlParameter("@Precio_de_compra", entity.Precio_de_compra));
            parametros.Add(new SqlParameter("@Estado_imagen", entity.Estado_imagen));
            parametros.Add(new SqlParameter("@Imagen", entity.Imagen));
            parametros.Add(new SqlParameter("@Idcolor", entity.Idcolor));
            ExecuteNonQuery(InsertarProducto);
        }

        public void Delete(int Id)
        {
            parametro = new SqlParameter("@Idproducto", Id);
            ExecuteNonQueryInParametro(EliminarProducto);
        }

        public IEnumerable<Productos> GetAll()
        {
            throw new NotImplementedException();
        }

        public Productos GetById(int id)
        {
            parametro = new SqlParameter("@idproducto", id);
            var table = ExecuteReaderWithParameter(ObtenerProductoPorId);
            if (table.Rows.Count > 0)
            {
                Productos objProducto = new Productos();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[2] == DBNull.Value ? null : (byte[])row[2];
                    objProducto.Id_Producto = Convert.ToInt32(row[0]);
                    objProducto.Descripcion = row[1].ToString();
                    objProducto.Imagen = img;
                    objProducto.Id_grupo = Convert.ToInt32(row[3]);
                    objProducto.Precio_de_venta = Convert.ToDouble(row[4]);
                    objProducto.Precio_de_compra = Convert.ToDouble(row[5]);
                    objProducto.Estado_imagen = row[6].ToString();
                    objProducto.Idcolor = Convert.ToInt32(row[7]);
                    objProducto.Estado = row[8].ToString();
                }
                return objProducto;
            }
            else
                return null;
        }

        public IEnumerable<MostrarColorXProductoDTO> ListMostrarColorXProductoDTO(int IdProducto)
        {
            parametro = new SqlParameter("@Idproducto",IdProducto);
            var table = ExecuteReaderWithParameter(MostrarColorXProducto);
            if (table.Rows.Count > 0)
            {
                var MostrarColorXProductoDTO = new List<MostrarColorXProductoDTO>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[2] == DBNull.Value ? null : (byte[])row[2];
                    MostrarColorXProductoDTO.Add(new MostrarColorXProductoDTO
                    {
                        ColorHtml = row[0].ToString(),
                        IdColor = Convert.ToInt32(row[1]),
                        Imagen = img,
                        EstadoImagen = row[3].ToString(),
                        Precio_de_compra = Convert.ToDouble(row[4]),
                        Precio_de_venta = Convert.ToDouble(row[5])
                    });
                }
                return MostrarColorXProductoDTO;
            }
            else
                return null;
        }

        public IEnumerable<MostrarProductosPorGrupoDTO> ListMostrarProductosPorGrupo(int idGrupo, string value)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_grupo", idGrupo));
            parametros.Add(new SqlParameter("@buscador", value));
            var table = ExecuteReaderWithParameters(MostrarProductosPorGrupos);
            if (table.Rows.Count > 0)
            {
                var MotrarProductosPorGrupos =  new List<MostrarProductosPorGrupoDTO>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[2] == DBNull.Value ? null : (byte[])row[2];
                    MotrarProductosPorGrupos.Add(new MostrarProductosPorGrupoDTO
                    { 
                        IdProducto1 = (int)(row[0]),
                        Descripcion = row[1].ToString(),
                        Estado_imagen = row[6].ToString(),
                        Estado = row[8].ToString(),
                        Imagen = img,
                        Precio_de_venta = Convert.ToDouble(row[4]),
                        Moneda = row[13].ToString()
                    });
                }
                return MotrarProductosPorGrupos;
            }
            else
                return null;
        }

        public bool RestaurarProductos(int idProducto)
        {
            parametro = new SqlParameter("@Idproducto", idProducto);
            var result = ExecuteNonQueryInParametro(RestaurarProducto);
            if (result > 0)
                return true;
            else
                return false;
        }

        public void Update(Productos entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Descripcion", entity.Descripcion));
            parametros.Add(new SqlParameter("@Imagen", entity.Imagen));
            parametros.Add(new SqlParameter("@PrecioVenta", entity.Precio_de_venta));
            parametros.Add(new SqlParameter("@PrecioCompra", entity.Precio_de_compra));
            parametros.Add(new SqlParameter("@Estadoimagen", entity.Estado_imagen));
            parametros.Add(new SqlParameter("@Idcolor", entity.Idcolor));
            parametros.Add(new SqlParameter("@Idproducto", entity.Id_Producto));
            parametros.Add(new SqlParameter("@CodUm", entity.CodUm));
            parametros.Add(new SqlParameter("@CodigoSunat", entity.CodigoSunat));
            parametros.Add(new SqlParameter("@Codigo", entity.Codigo));
            ExecuteNonQuery(EditarProducto);
        }
    }
}
