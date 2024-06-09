using DataAccess.DTO;
using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Mapeador
{
    public abstract class MapUsuariosModel
    {
        protected UsuariosModel MapMostrarUsuarioDTO(MostrarUsuariosDTO MostrarUsuariosDTO)
        {
            var MostrarUsuariosModelDTO = new UsuariosModel()
            {
                IdUsuario = Convert.ToInt32(MostrarUsuariosDTO.idUsuario),
                Login = MostrarUsuariosDTO.Login,
                Icono = MostrarUsuariosDTO.Icono,
            };
            return MostrarUsuariosModelDTO;
        }

        protected List<UsuariosModel> MapMostrarUsuarioDTO(IEnumerable<MostrarUsuariosDTO> MostrarUsuariosDTO)
        {
            List<UsuariosModel> MapMostrarUsuarioModelDTO = new  List<UsuariosModel>();
            foreach (var item in MostrarUsuariosDTO)
            {
                MapMostrarUsuarioModelDTO.Add(MapMostrarUsuarioDTO(item));
            }
            return MapMostrarUsuarioModelDTO;
        }

        protected Usuarios MapUsuariosEntity(UsuariosModel objUsuariosModel)
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

        protected UsuariosModel MapUsuariosEntity(Usuarios usuarios)
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

        protected List<UsuariosModel> MapUsuarioModel(IEnumerable<Usuarios> ListUsuarios)
        {
            var ListUsuariosModel = new List<UsuariosModel>();
            foreach (var item in ListUsuarios)
            {
                ListUsuariosModel.Add(MapUsuariosEntity(item));
            }
            return ListUsuariosModel;
        }

    }
}
