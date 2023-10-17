using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class IniciosDeSesionRepository : RepositoryMaster, IIniciosDeSesionRepository
    {
        public readonly string MostrarInicioDeSesion;
        public readonly string EditarInicioDeSesion;
        public readonly string InsertarInicioSesion;

        public IniciosDeSesionRepository()
        {
            MostrarInicioDeSesion = "mostrarInicioSesion";
            EditarInicioDeSesion = "editarInicioSesion";
            InsertarInicioSesion = "insertarInicioSesion";
        }
        public void Add(IniciosDeSesion entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idsesion", entity.idSesion));
            parametros.Add(new SqlParameter("@idusuario", entity.idCaja));
            ExecuteNonQuery(InsertarInicioSesion);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IniciosDeSesion> GetAll()
        {
            throw new NotImplementedException();
        }

        public IniciosDeSesion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int MostrarIdEstadoDeSesion(int IdCaja)
        {
            parametro = new SqlParameter("@idcaja", IdCaja);
            int idUsuarioSesion = ExecuteScalarWithParameter(MostrarInicioDeSesion);
            return idUsuarioSesion;
        }

        public void Update(IniciosDeSesion entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idsesion", entity.idSesion));
            parametros.Add(new SqlParameter("@idusuario", entity.idCaja));
            ExecuteNonQuery(EditarInicioDeSesion);
        }
    }
}
