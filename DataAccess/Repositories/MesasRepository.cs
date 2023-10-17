using DataAccess.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class MesasRepository : RepositoryMaster, IMesasRepository
    {
        public string AddMesas;
        public string MostrarMesasPorSalon;

        public MesasRepository()
        {
            AddMesas = "AddMesas";
            MostrarMesasPorSalon = "mostrar_mesas_por_salon2";
        }
        public void Add(Mesas entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@mesa", entity.Mesa) { SqlDbType = SqlDbType.NVarChar });
            parametros.Add(new SqlParameter("@idsalon", entity.IdSalon) { SqlDbType = SqlDbType.Int });
            ExecuteNonQuery(AddMesas);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mesas> GetAll()
        {
            throw new NotImplementedException();
        }

        public Mesas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MostrarMesasPorSalonDTO> MostrarMesasporSalon(int idSalon)
        {
            parametro = new SqlParameter("@id_salon", idSalon) { SqlDbType = SqlDbType.Int };
            var ResultTable = ExecuteReaderWithParameter(MostrarMesasPorSalon);
            var listMesasxSalon = new List<MostrarMesasPorSalonDTO>();
            foreach (DataRow item in ResultTable.Rows)
            {
                listMesasxSalon.Add(new MostrarMesasPorSalonDTO
                {
                    IdMesa = Convert.ToInt32(item[0]),
                    Mesa = item[1].ToString(),
                });
            }
            return listMesasxSalon;
        }

        public void Update(Mesas entity)
        {
            throw new NotImplementedException();
        }
    }
}
