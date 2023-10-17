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
    public class PermisosRepository : RepositoryMaster, IPermisosRepository
    {
        public string InsertarPermisos;
        public string EliminarPermisos;
        public string MostrarPermisos;

        public PermisosRepository()
        {
            InsertarPermisos = "insertar_Permisos";
            EliminarPermisos = "Eliminar_Permisos";
            MostrarPermisos = "mostrar_Permisos";
        }

        public void Add(Permisos entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(List<Permisos> objListPermisosEntity)
        {
            foreach (var item in objListPermisosEntity)
            {
                parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("IdModulo", item.IdModulo));
                parametros.Add(new SqlParameter("IdUsuario", item.IdUsuario));
            }
            var result = TransactionParametersExecuteScalar(InsertarPermisos);
            return result;
        }

        public void Delete(int Id)
        {
            parametro = new SqlParameter("@IdUsuario", Id);
            ExecuteNonQuery(EliminarPermisos);
        }

        public IEnumerable<Permisos> GetAll()
        {
            throw new NotImplementedException();
        }

        public Permisos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MostrarPermisosDTO> mostrarPermisos(int idUsuario)
        {
            parametro = new SqlParameter("idusuario", idUsuario);
            var Result = ExecuteReaderWithParameter(MostrarPermisos);
            if (Result.Rows.Count > 0)
            {
                List<MostrarPermisosDTO> objListMostrarPermisosDTO = new List<MostrarPermisosDTO>();
                foreach (DataRow row in Result.Rows)
                {
                    objListMostrarPermisosDTO.Add(new MostrarPermisosDTO
                    {
                        idModulo = Convert.ToInt32(row[0]),
                        Modulo = row[0].ToString()

                    });
                }
                return objListMostrarPermisosDTO;
            }
            else
                return null;

        }

        public void Update(Permisos entity)
        {
            throw new NotImplementedException();
        }
    }
}
