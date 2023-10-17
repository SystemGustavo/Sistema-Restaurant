using Common.Bases;
using Common.Cache;
using DataAccess.Contracts;
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
    public class CajaRepository : RepositoryMaster, ICajaRepository
    {
        public readonly string MostrarCajaSerial;
        public readonly string AddCaja;
        public CajaRepository()
        {
            MostrarCajaSerial = "mostrarCajaSerial";
            AddCaja = "Insertar_caja";
        }

        public void Add(Caja entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion",entity.Descripcion));
            parametros.Add(new SqlParameter("@Tema",entity.Tema));
            parametros.Add(new SqlParameter("@Serial_PC",entity.Serial_PC));
            parametros.Add(new SqlParameter("@Tipo",entity.Tipo));
            ExecuteNonQuery(AddCaja);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Caja> GetAll()
        {
            throw new NotImplementedException();
        }

        public Caja GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int MostrarIdCajaSerial(string Serial)
        {
            //0025_38BB_21B8_FCF3. ->SerialPc
            parametro = new SqlParameter("@Serial", Serial);
            var Table = ExecuteReaderWithParameter(MostrarCajaSerial);
            if (Table.Rows.Count > 0){
                foreach (DataRow item in Table.Rows)
                {
                    CajaCache.idCaja = Convert.ToInt32(item[0]);
                }
                return CajaCache.idCaja;
            }
            else
                return 0;
        }

        public void Update(Caja entity)
        {
            throw new NotImplementedException();
        }
    }
}
