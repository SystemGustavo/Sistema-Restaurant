using Common;
using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UsuariosModel
    {
        [DisplayName("Id")]
        public int IdUsuario { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre del usuario es requerido.")]
        public string Nombre { get; set; }
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string Login { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "la Contraseña es requerida.")]
        public string Password { get; set; }
        [DisplayName("Foto")]
        [Browsable(false)]
        public byte[] Icono { get; set; }
        [DisplayName("Correo")]
        [Required(ErrorMessage = "El Correo es requerido.")]
        public string Correo { get; set; }
        [DisplayName("Rol")]
        [Required(ErrorMessage = "El Rol es requerido.")]
        public string Rol { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }

        private List<MostrarUsuariosDTOs> ListMostrarUsuariosDTOs { get; set; }
        private List<UsuariosModel> ListUsuariosModel { get; set; }

        private IUsuariosRepository UsuariosRepository;

        public UsuariosModel()
        {
            UsuariosRepository = new UsuariosRepository();
        }

        public int validarUsuarios(string usuario,string contraseña)
        {
            var id = UsuariosRepository.ValidarUsuarios(usuario, contraseña);
            return id;
        }

        public int ObtenerIdUsuario(string login)
        {
            var getIdUsuario = UsuariosRepository.ObtenerIdUsuario(login);
            return getIdUsuario;
        }

        public List<UsuariosModel> GetAllUsuarios()
        {
            var ListUsuarios = UsuariosRepository.GetAll();
            if (ListUsuarios != null)
            {
                var objListUsuariosEntity = MapListUsuariosModel(ListUsuarios);
                return objListUsuariosEntity;
            }
            else
                return null;
        }

        public List<UsuariosModel> BuscarUsuarios(string valor)
        {
            return ListUsuariosModel.FindAll(u=>u.Nombre.Contains(valor) || u.Login.Contains(valor));
        }

        public void InsertarUsuario(UsuariosModel objUsuarioModel)
        {
            Usuarios objUsuarioEntity = MapUsuariosEntity(objUsuarioModel);
            UsuariosRepository.Add(objUsuarioEntity);
        }

        public void ActualizarUsuario(UsuariosModel objUsuarioModel)
        {
            Usuarios objUsuarioEntity = MapUsuariosEntity(objUsuarioModel);
            UsuariosRepository.Update(objUsuarioEntity);
        }

        public void EliminarUsuario(int id)
        {
            UsuariosRepository.Delete(id);
        }

        public UsuariosModel IniciarSesion(string usuario,string contraseña)
        {
            var usuarioEntity = UsuariosRepository.IniciarSesion(usuario, contraseña);
            if (usuarioEntity != null)
                return MapUsuariosModel(usuarioEntity);
            else
                return null;
        }
                                                                                             
        public List<MostrarUsuariosDTOs> MostrarUsuarios()
        {
            var ListMostrarUsuarios = UsuariosRepository.MostrarUsuariosDTO();
            var ListMostrarUsuariosDTOs = new List<MostrarUsuariosDTOs>();
            var MapListMostrarUsuariosDtos = MapListMostrarUsuariosDTOs(ListMostrarUsuarios);
            foreach (var item in MapListMostrarUsuariosDtos)
            {
                ListMostrarUsuariosDTOs.Add(new MostrarUsuariosDTOs
                {
                    idUsuario = item.idUsuario,
                    Login = item.Login,
                    Icono = item.Icono,
                });
            }
            return ListMostrarUsuariosDTOs;
        }

        private Usuarios MapUsuariosEntity(UsuariosModel objUsuariosModel)
        {
            var ObjUsuariosEntity = new Usuarios()
            {
                IdUsuario = objUsuariosModel.IdUsuario,
                Nombre = objUsuariosModel.Nombre,
                Login = objUsuariosModel.Login,
                Password = objUsuariosModel.Password,
                Icono = objUsuariosModel.Icono,
                Correo = objUsuariosModel.Correo,
                Rol = objUsuariosModel.Rol,
                Estado = objUsuariosModel.Estado
            };

            return ObjUsuariosEntity;
        }

        private UsuariosModel MapUsuariosModel(Usuarios usuarios)
        {
            var UsuariosModel = new UsuariosModel()
            {
                IdUsuario = usuarios.IdUsuario,
                Nombre = usuarios.Nombre,
                Login = usuarios.Login,
                Password = usuarios.Password,
                Icono = usuarios.Icono,
                Correo = usuarios.Correo,
                Rol = usuarios.Rol,
                Estado = usuarios.Estado
            };

            return UsuariosModel;
        }

        private MostrarUsuariosDTOs MapMostrarUsuariosDTOs(MostrarUsuariosDTO MostrarUsuariosDTO)
        {
            var MostrarUsuariosDTOs = new MostrarUsuariosDTOs()
            {
                idUsuario = Convert.ToInt32(MostrarUsuariosDTO.idUsuario),
                Login = MostrarUsuariosDTO.Login,
                Icono = MostrarUsuariosDTO.Icono,
            };
            return MostrarUsuariosDTOs;
        }

        private List<MostrarUsuariosDTOs> MapListMostrarUsuariosDTOs(IEnumerable<MostrarUsuariosDTO> ListMostrarUsuariosDTO)
        {
            var ListMostrarUsuariosDTOs = new List<MostrarUsuariosDTOs>();
            foreach (var item in ListMostrarUsuariosDTO)
            {
                ListMostrarUsuariosDTOs.Add(MapMostrarUsuariosDTOs(item));
            }
            return ListMostrarUsuariosDTOs;
        }

        public List<UsuariosModel> MapListUsuariosModel(IEnumerable<Usuarios> ListUsuarios)
        {
            ListUsuariosModel = new List<UsuariosModel>();
            foreach (var item in ListUsuarios)
            {
                ListUsuariosModel.Add(MapUsuariosModel(item));
            }
            return ListUsuariosModel;
        }
    }
}
