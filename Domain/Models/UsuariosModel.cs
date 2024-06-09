using Common;
using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.DTOs;
using Domain.Mapeador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UsuariosModel : MapUsuariosModel
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

        //private List<MostrarUsuariosDTOs> ListMostrarUsuariosDTOs { get; set; }
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
                ListUsuariosModel = MapUsuarioModel(ListUsuarios);
                return ListUsuariosModel;
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
                return MapUsuariosEntity(usuarioEntity);
            else
                return null;
        }
                                                                                             
        public List<UsuariosModel> MostrarUsuarios()
        {
            var MostrarUsuariosDTO = UsuariosRepository.MostrarUsuariosDTO();
            var MostrarUsuarioDTO = MapMostrarUsuarioDTO(MostrarUsuariosDTO);
            return MostrarUsuarioDTO;
        }

    }
}
