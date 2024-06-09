using Common.Bases;
using Common.Cache;
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
    public class MovimientoDeCajaRepository : RepositoryMaster, IMovimientoDeCajaRepository
    {
        public readonly string VMovimientoDeCajaPorUsuario;
        public readonly string vMovimientoDeCajaPorSerial;
        public readonly string InsertarMovimientoCaja;
        public readonly string EditDineroInicial;

        public MovimientoDeCajaRepository()
        {
            VMovimientoDeCajaPorUsuario = "MostrarMovCajaUser";
            vMovimientoDeCajaPorSerial = "MostrarMovimientosCaja";
            InsertarMovimientoCaja = "insertar_MovimientosCaja";
            EditDineroInicial = "EditarDineroInicial";
        }

        public void Add(MovimientoDeCaja entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientoDeCaja> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovimientoDeCaja GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int MovimientoDeCajaPorIdUsuario(int idUsuario, string SerialPc)
        {
           
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@serial", SerialPc));
            parametros.Add(new SqlParameter("@idusuario", idUsuario));
            CajaCache.idMovimientoCaja = ExecuteScalarWithParameters(VMovimientoDeCajaPorUsuario);
            return CajaCache.idMovimientoCaja;
        }

        public string MovimientoDeCajaPorSerial(string SerialPc)
        {
            parametro = new SqlParameter("@serial", SerialPc);
            var Table = ExecuteReaderWithParameter(vMovimientoDeCajaPorSerial);
            if (Table.Rows.Count > 0){
                foreach (DataRow item in Table.Rows)
                {
                    CajaCache.UsuarioInicioCaja = item[1].ToString();
                }
                return CajaCache.UsuarioInicioCaja;
            }
            else
                return null;
        }

        public void Update(MovimientoDeCaja entity)
        {
            throw new NotImplementedException();
        }

        public bool EditarDineroInicial(int IdCaja, double EfectivoInicial)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@EfectivoInicial", EfectivoInicial));
            parametros.Add(new SqlParameter("@Id_caja", IdCaja));
            ExecuteNonQuery(EditDineroInicial);
            return true;
        }

        public void Add(int IdUsuario, int IdCaja)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Idusuario", IdUsuario));
            parametros.Add(new SqlParameter("@IdCaja", IdCaja));
            ExecuteNonQuery(InsertarMovimientoCaja);
        }
    }
}
