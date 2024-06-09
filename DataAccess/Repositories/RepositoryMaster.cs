using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class RepositoryMaster : Repository
    {
        protected List<SqlParameter> parametros;
        protected SqlParameter parametro;

        protected DataTable ExecuteReader(string ProcAlmacenado)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }

        protected DataTable ExecuteReaderWithParameters(string ProcAlmacenado)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }

        protected int ExecuteScalarWithParameters(string ProcAlmacenado)
        {
            int result;
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    try{
                        result = Convert.ToInt32(comando.ExecuteScalar());
                    }catch (Exception){
                        result = 0;
                    }
                        return result;
                }
            }
        }

        protected int ExecuteScalarWithParameter(string ProcAlmacenado)
        {
            int result;
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(parametro);
                    try{
                        result = Convert.ToInt32(comando.ExecuteScalar());
                    }catch (Exception){
                        result = 0;
                    }
                    return result;
                }
            }
        }

        protected DataTable ExecuteReaderWithParameter(string ProcAlmacenado)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(parametro);
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }

        protected int ExecuteNonQueryInParametro(string ProcAlmacenado)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(parametro);
                    int resultado = comando.ExecuteNonQuery();
                    parametro.Value = null;
                    return resultado;
                }
            }
        }

        protected int ExecuteNonQuery(string ProcAlmacenado)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = ProcAlmacenado;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    int resultado = comando.ExecuteNonQuery();
                    parametros.Clear();
                    return resultado;

                }
            }
        }

        public int TransactionParameterExecuteScalar(string procAlmacenado)
        {
            int resultado = 0;
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction sqlTransaction = conexion.BeginTransaction())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexion;
                        comando.Transaction = sqlTransaction;
                        comando.CommandText = procAlmacenado;
                        comando.CommandType = CommandType.StoredProcedure;
                        try{
                            comando.Parameters.Add(parametro);
                            resultado = Convert.ToInt32(comando.ExecuteScalar());
                            sqlTransaction.Commit();
                        }catch (Exception){
                            sqlTransaction.Rollback();
                            conexion.Close();
                            throw;
                        }
                    }
                }
            }
            return resultado;
        }

        public int TransactionParametersExecuteScalar(string procAlmacenado)
        {
            int resultado = 0;
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction sqlTransaction = conexion.BeginTransaction())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexion;
                        comando.Transaction = sqlTransaction;
                        comando.CommandText = procAlmacenado;
                        comando.CommandType = CommandType.StoredProcedure;
                        try{
                            foreach (SqlParameter item in parametros)
                            {
                                comando.Parameters.Add(item);
                            }
                            resultado += Convert.ToInt32(comando.ExecuteScalar());
                            parametros.Clear();
                            sqlTransaction.Commit();
                        }catch (Exception){
                            sqlTransaction.Rollback();
                            conexion.Close();
                            throw;
                        }
                    }
                }
            }
            return resultado;
        }

        public int TransactionExecuteNonQuery(string procAlmacenado)
        {
            int resultado = 0;
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction sqlTransaction = conexion.BeginTransaction())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexion;
                        comando.Transaction = sqlTransaction;
                        comando.CommandText = procAlmacenado;
                        comando.CommandType = CommandType.StoredProcedure;
                        try{
                            foreach (SqlParameter item in parametros)
                            {
                                comando.Parameters.Add(item);
                            }
                            resultado = comando.ExecuteNonQuery();
                            parametros.Clear();
                            sqlTransaction.Commit();
                        }catch (Exception){
                            sqlTransaction.Rollback();
                            conexion.Close();
                            throw;
                        }
                    }
                }
            }
            return resultado;
        }
    }
}
