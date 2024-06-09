using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class GrupoDeProductosRepository : RepositoryMaster, IGrupoDeProductosRepository
    {
        public readonly string BuscarPorGrupo;
        public readonly string RestaurarGrupo;
        public readonly string EditarGrupoProducto;
        public readonly string EliminarGrupo;
        public readonly string ObtenerGrupoXId;
        public readonly string InsertarGrupoProducto;
        public readonly string PaginarGrupos;

        public GrupoDeProductosRepository()
        {
            BuscarPorGrupo = "buscarGrupos";
            RestaurarGrupo = "restaurarGrupos";
            EliminarGrupo = "eliminarGrupos";
            ObtenerGrupoXId = "ObtenerGrupoXId";
            InsertarGrupoProducto = "Insertar_Grupo_de_Productos";
            EditarGrupoProducto = "editarGrupoProd";
            PaginarGrupos = "Paginar_grupos";
        }

        public void Add(GrupoProductos entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Grupo", entity.Grupo));
            parametros.Add(new SqlParameter("@Por_defecto", entity.Por_defecto));
            parametros.Add(new SqlParameter("@Estado", entity.Estado));
            parametros.Add(new SqlParameter("@Estado_de_icono", entity.Estado_de_icono));
            parametros.Add(new SqlParameter("@Idcolor", entity.Idcolor));
            if (entity.Icono != null)
                parametros.Add(new SqlParameter("@Icono", entity.Icono) { SqlDbType = SqlDbType.Image });
            else                                             
                parametros.Add(new SqlParameter("@Icono", DBNull.Value) { SqlDbType = SqlDbType.Image });
            ExecuteNonQuery(InsertarGrupoProducto);
        }

        public void Delete(int Id)
        {
            parametro = new SqlParameter("@Idgrupo", Id);
            ExecuteNonQueryInParametro(EliminarGrupo);
        }

        public IEnumerable<GrupoProductos> GetAll()
        {
            throw new NotImplementedException();
        }

        public GrupoProductos GetById(int id)
        {
            parametro = new SqlParameter("@idGrupo", id);
            var table = ExecuteReaderWithParameter(ObtenerGrupoXId);
            if (table.Rows.Count > 0)
            {
                GrupoProductos objGrupoProducto = new GrupoProductos();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[3] == DBNull.Value ? null : (byte[])row[3];
                    objGrupoProducto.Idline = Convert.ToInt32(row[0]);
                    objGrupoProducto.Grupo = row[1].ToString();
                    objGrupoProducto.Por_defecto = row[2].ToString();
                    objGrupoProducto.Icono = img;
                    objGrupoProducto.Estado = row[4].ToString();
                    objGrupoProducto.Estado_de_icono = row[5].ToString();
                    objGrupoProducto.Idcolor = Convert.ToInt32(row[6]);
                }
                return objGrupoProducto;
            }
            else
                return null;
        }

        public void Update(GrupoProductos entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Grupo", entity.Grupo));
            parametros.Add(new SqlParameter("@Idcolor", entity.Idcolor));
            parametros.Add(new SqlParameter("@Idgrupo", entity.Idline));
            parametros.Add(new SqlParameter("@estadoicono", entity.Estado_de_icono));
            if (entity.Icono != null)
                parametros.Add(new SqlParameter("@Icono", entity.Icono) { SqlDbType = SqlDbType.Image });
            else
                parametros.Add(new SqlParameter("@Icono", DBNull.Value) { SqlDbType = SqlDbType.Image });
            ExecuteNonQuery(EditarGrupoProducto);
        }

        public IEnumerable<GrupoProductos> BuscarPorGrupos(string grupo)
        {
            parametro = new SqlParameter("@buscador", grupo);
            var table = ExecuteReaderWithParameter(BuscarPorGrupo);
            if (table.Rows.Count > 0)
            {
                var ListBuscarPorGrupos = new List<GrupoProductos>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[3] == DBNull.Value ? null : (byte[])row[3];
                    ListBuscarPorGrupos.Add(new GrupoProductos
                    {
                        Idline = (int)(row[0]),
                        Grupo = row[1].ToString(),
                        Por_defecto = row[2].ToString(),
                        Icono = img,
                        Estado = row[4].ToString(),
                        Estado_de_icono = row[5].ToString(),
                        Idcolor = Convert.ToInt32(row[6])
                    });
                }
                return ListBuscarPorGrupos;
            }
            else
                return null;
        }

        public bool RestaurarGrupoDeProductos(int IdGrupo)
        {
            parametro = new SqlParameter("@Idgrupo", IdGrupo);
            int result = ExecuteNonQueryInParametro(RestaurarGrupo);
            if (result > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<GrupoProductos> PaginarGrupoProductos(int desde, int hasta)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@desde", desde));
            parametros.Add(new SqlParameter("@hasta", hasta));
            var table = ExecuteReaderWithParameters(PaginarGrupos);
            if (table.Rows.Count > 0)
            {
                var ListBuscarPorGrupos = new List<GrupoProductos>();
                foreach (DataRow row in table.Rows)
                {
                    byte[] img = row[3] == DBNull.Value ? null : (byte[])row[3];
                    ListBuscarPorGrupos.Add(new GrupoProductos
                    {
                        Idline = (int)(row[0]),
                        Grupo = row[1].ToString(),
                        Por_defecto = row[2].ToString(),
                        Icono = img,
                        Estado = row[4].ToString(),
                        Estado_de_icono = row[5].ToString(),
                        Idcolor = Convert.ToInt32(row[6])
                    });
                }
                return ListBuscarPorGrupos;
            }
            else
                return null;
        }
    }
}
