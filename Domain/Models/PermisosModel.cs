using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PermisosModel
    {
        public int IdPermiso { get; set; }
        public int IdModulo { get; set; }
        public int IdUsuario { get; set; }

        private IPermisosRepository PermisosRepository;
        public PermisosModel()
        {
            PermisosRepository = new PermisosRepository();
        }

        public List<MostrarPermisosDTOs> mostrarPermisos(int idUsuario)
        {
            var PermisosModel = PermisosRepository.mostrarPermisos(idUsuario);
            if (PermisosModel != null)
                return MapMostrarPermisosDTOs(PermisosModel);
            else
                return null;
        }

        public int AddRange(List<PermisosModel> objListPermisosModel)
        {
            var PermisosEntity = MapPermisosEntity(objListPermisosModel);
            var result = PermisosRepository.AddRange(PermisosEntity);
            return result;
        }

        public void EliminarPermiso(int id)
        {
           PermisosRepository.Delete(id);
        }

        private MostrarPermisosDTOs MapMostrarPermisosDTOs(MostrarPermisosDTO objMostrarPermisosDTO)
        {
            var objMostrarPermisosDTOs = new MostrarPermisosDTOs
            {
                idModulo = objMostrarPermisosDTO.idModulo,
                Modulo = objMostrarPermisosDTO.Modulo
            };
            return objMostrarPermisosDTOs;
        }

        private List<MostrarPermisosDTOs> MapMostrarPermisosDTOs(List<MostrarPermisosDTO> objListMostrarPermisosDTO)
        {
            var ObjListMostrarPermisosDTOs = new List<MostrarPermisosDTOs>();
            foreach (var item in objListMostrarPermisosDTO)
            {
                ObjListMostrarPermisosDTOs.Add(MapMostrarPermisosDTOs(item));
            }
            return ObjListMostrarPermisosDTOs;
        }

        private Permisos MapPermisosEntity(PermisosModel objPermisosModel)
        {
            var Permisos = new Permisos
            {
                IdPermiso= objPermisosModel.IdModulo,
                IdModulo = objPermisosModel.IdModulo,
                IdUsuario = objPermisosModel.IdUsuario
            };
            return Permisos;
        }

        private List<Permisos> MapPermisosEntity(List<PermisosModel> objListPermisosModel)
        {
            List<Permisos> objListPermisos = new List<Permisos>();
            foreach (var item in objListPermisosModel)
            {
                objListPermisos.Add(MapPermisosEntity(item));
            }
            return objListPermisos;
        }

    }
}
