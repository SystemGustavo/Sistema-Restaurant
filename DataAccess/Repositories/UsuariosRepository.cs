using Common.Cache;
using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class UsuariosRepository : RepositoryMaster, IUsuariosRepository
    {
        public readonly string MostrarUsuarios;
        public readonly string InsertarUsuarios;
        public readonly string EditarUsuarios;
        public readonly string EliminarUsuarios;
        public readonly string ValidarUsuario;
        public readonly string BuscarUsuarios;
        public readonly string RetornaIdUsuario;

        public UsuariosRepository()
        {
            MostrarUsuarios = "mostrar_Usuarios";
            InsertarUsuarios = "insertar_Usuarios";
            EditarUsuarios = "editar_Usuarios";
            EliminarUsuarios = "eliminar_Usuarios";
            ValidarUsuario = "validarUsuario";
            BuscarUsuarios = "buscar_usuarios";
            RetornaIdUsuario = "ObtenerIdUsuario";
        }

        public void Add(Usuarios entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", entity.Nombre));
            parametros.Add(new SqlParameter("@Login", entity.Login));
            parametros.Add(new SqlParameter("@Password", entity.Password));
            parametros.Add(new SqlParameter("@Icono", entity.Icono));
            parametros.Add(new SqlParameter("@Correo", entity.Correo));
            parametros.Add(new SqlParameter("@Rol", entity.Rol));
            parametros.Add(new SqlParameter("@Estado", "ACTIVO"));
            ExecuteNonQuery(InsertarUsuarios);
        }

        public void Delete(int Id)
        {
            parametro = new SqlParameter("IdUsuario",Id);
            ExecuteNonQueryInParametro(EliminarUsuarios);
        }

        public IEnumerable<Usuarios> GetAll()
        {
            var ResultTable = ExecuteReader(MostrarUsuarios);
            List<Usuarios> objListUsuarios = new List<Usuarios>();
            if (ResultTable.Rows.Count > 0)
            {
                foreach (DataRow row in ResultTable.Rows)
                {
                    objListUsuarios.Add(new Usuarios
                    {
                        IdUsuario = (int)(row[0]),
                        Nombre = row[1].ToString(),
                        Login = row[2].ToString(),
                        Password = row[3].ToString(),
                        Icono = (byte[])row[4],
                        Correo = row[5].ToString(),
                        Rol = row[6].ToString(),
                        Estado = row[7].ToString()
                    });
                }
                return objListUsuarios;
            }
            else
                return null;
        }

        public Usuarios GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int ObtenerIdUsuario(string login)
        {
            parametro = new SqlParameter("Login",login);
            int result = ExecuteScalarWithParameter(RetornaIdUsuario);
            return result;
        }

        public Usuarios IniciarSesion(string usuario, string contraseña)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@login", usuario));
            parametros.Add(new SqlParameter("@password", contraseña));
            var table = ExecuteReaderWithParameters(ValidarUsuario);

            if (table.Rows.Count > 0)
            {
                var objusuario = new Usuarios();
                foreach (DataRow row in table.Rows)
                {
                    objusuario.IdUsuario = (int)(row[0]);
                    objusuario.Nombre = row[1].ToString();
                    objusuario.Login = row[2].ToString();
                    objusuario.Password = row[3].ToString();
                    objusuario.Icono = (byte[])row[4];
                    objusuario.Correo = row[5].ToString();
                    objusuario.Rol = row[6].ToString();
                    objusuario.Estado = row[7].ToString();
                }

                UsuarioCache.idUsuario = objusuario.IdUsuario;
                UsuarioCache.Usuario = objusuario.Login;
                UsuarioCache.Position = objusuario.Rol;

                return objusuario;
            }
            else
                return null;
        }

        public IEnumerable<MostrarUsuariosDTO> MostrarUsuariosDTO()
        {
            var ResultTable = ExecuteReader(MostrarUsuarios);
            var objListMostrarUsuarioDTO = new List<MostrarUsuariosDTO>();
            foreach (DataRow item in ResultTable.Rows)
            {
                objListMostrarUsuarioDTO.Add(new MostrarUsuariosDTO
                {
                    idUsuario = Convert.ToInt32(item[0]),
                    Login = item[2].ToString(),
                    Icono = (byte[])item[4]
                });
            }
            return objListMostrarUsuarioDTO;
        }

        public void Update(Usuarios entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdUsuario",entity.IdUsuario));
            parametros.Add(new SqlParameter("@Nombre", entity.Nombre));
            parametros.Add(new SqlParameter("@Login", entity.Login));
            parametros.Add(new SqlParameter("@Password", entity.Password));
            parametros.Add(new SqlParameter("@Icono", entity.Icono));
            parametros.Add(new SqlParameter("@Correo", entity.Correo));
            parametros.Add(new SqlParameter("@Rol", entity.Rol));
            ExecuteNonQuery(EditarUsuarios);
        }

        public int ValidarUsuarios(string usuario,string contraseña)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@login", usuario));
            parametros.Add(new SqlParameter("@password", contraseña));
            int result = ExecuteScalarWithParameter(ValidarUsuario);
            return result;
        }
    }
}
