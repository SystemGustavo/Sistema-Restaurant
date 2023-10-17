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
    public class SalonesRepository : RepositoryMaster, ISalonesRepository
    {
        public string GetAllSalones;
        public string AddSalones;

        public SalonesRepository()
        {
            GetAllSalones = "MostrarSalones";
            AddSalones = "insertar_Salon";
        }
        public void Add(Salones entity)
        {
            parametro = new SqlParameter("@Salon", entity.Salon) { SqlDbType = SqlDbType.NVarChar };
            ExecuteNonQueryInParametro(AddSalones);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Salones> GetAll()
        {
            var ResultTable = ExecuteReader(GetAllSalones);
            var listSalones = new List<Salones>();
            foreach (DataRow item in ResultTable.Rows)
            {
                listSalones.Add(new Salones
                {
                    IdSalon = Convert.ToInt32(item[0]),
                    Salon = item[1].ToString(),
                    Estado = item[2].ToString()
                });
            }
            return listSalones;
        }

        public Salones GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Salones entity)
        {
            throw new NotImplementedException();
        }
    }
}
