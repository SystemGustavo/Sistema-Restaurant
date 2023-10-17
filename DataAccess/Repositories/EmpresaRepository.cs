using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmpresaRepository : RepositoryMaster, IEmpresaRepository
    {
        public readonly string InsertarEmpresa;
        public readonly string EditarEmpresa;
        public readonly string EditarRespaldo;

        public EmpresaRepository()
        {
            InsertarEmpresa = "Insertar_EMPRESA";
            EditarEmpresa = "editarEmpresa";
            EditarRespaldo = "editarRespaldos";
        }
        public void Add(Empresa entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre_Empresa", entity.Nombre_Empresa));
            parametros.Add(new SqlParameter("@Impuesto", entity.Impuesto));
            parametros.Add(new SqlParameter("@Porcentaje_impuesto", entity.Porcentaje_impuesto));
            parametros.Add(new SqlParameter("@Moneda", entity.Moneda));
            parametros.Add(new SqlParameter("@Trabajas_con_impuestos", entity.Trabajas_con_impuestos));
            parametros.Add(new SqlParameter("@Carpeta_para_copias_de_seguridad", entity.Carpeta_para_copias_de_seguridad));
            parametros.Add(new SqlParameter("@Ultima_fecha_de_copia_date", entity.Ultima_fecha_de_copia_date));
            parametros.Add(new SqlParameter("@Pais", entity.Pais));
            parametros.Add(new SqlParameter("@Logo", entity.Logo));
            parametros.Add(new SqlParameter("@Tiponotas", entity.Tiponotas));
            ExecuteNonQuery(InsertarEmpresa);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool EditarRespaldos()
        {
            parametro = new SqlParameter("@Ultima_fecha_de_copia_date", DateTime.Now);
            var result=  ExecuteNonQueryInParametro(EditarRespaldo);
            if (result > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Empresa> GetAll()
        {
            throw new NotImplementedException();
        }

        public Empresa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Empresa entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre_Empresa", entity.Nombre_Empresa));
            parametros.Add(new SqlParameter("@Impuesto", entity.Impuesto));
            parametros.Add(new SqlParameter("@Porcentaje_impuesto", entity.Porcentaje_impuesto));
            parametros.Add(new SqlParameter("@Moneda", entity.Moneda));
            parametros.Add(new SqlParameter("@Trabajas_con_impuestos", entity.Trabajas_con_impuestos));
            parametros.Add(new SqlParameter("@Carpeta_para_copias_de_seguridad", entity.Carpeta_para_copias_de_seguridad));
            parametros.Add(new SqlParameter("@Pais", entity.Pais));
            parametros.Add(new SqlParameter("@Logo", entity.Logo));
            parametros.Add(new SqlParameter("@Tiponotas", entity.Tiponotas));
            ExecuteNonQuery(EditarEmpresa);
        }
    }
}
