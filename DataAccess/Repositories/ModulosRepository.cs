using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class ModulosRepository : RepositoryMaster, IModulosRepository
    {
        public string InsertarModulo;
        public string ActualizarModulo;
        public string EliminarModulo;
        public string MostrarModulo;

        public ModulosRepository()
        {
            InsertarModulo = "Insertar_Modulos";
            ActualizarModulo = "Editar_Modulos";
            EliminarModulo = "Eliminar_Modulos";
            MostrarModulo = "mostrar_Modulos";
        }

        public void Add(Modulos entity)
        {
            parametro = new SqlParameter("Modulo",entity.Modulo);
            ExecuteNonQueryInParametro(InsertarModulo);
        }

        public void Delete(int Id)
        {
            parametro = new SqlParameter("IdModulo", Id);
            ExecuteNonQueryInParametro(EliminarModulo);
        }

        public IEnumerable<Modulos> GetAll()
        {
            var resultTable = ExecuteReader(MostrarModulo);
            if (resultTable.Rows.Count > 0){
                var objListModulos = new List<Modulos>();
                foreach (DataRow row in resultTable.Rows)
                {
                    objListModulos.Add(new Modulos
                    {
                        IdModulo= Convert.ToInt32(row[0]),
                        Modulo= row[1].ToString()
                    });
                }
                return objListModulos;
            }else
                return null;
        }

        public Modulos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Modulos entity)
        {
            throw new NotImplementedException();
        }
    }
}
