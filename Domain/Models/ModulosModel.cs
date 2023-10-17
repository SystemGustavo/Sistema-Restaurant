using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ModulosModel
    {
        public int IdModulo { get; set; }
        public string Modulo { get; set; }

        private IModulosRepository ModulosRepository { get; set; }

        public ModulosModel()
        {
            ModulosRepository = new ModulosRepository();
        }

        public List<ModulosModel> GetAllModulos()
        {
            var ModulosEntity = ModulosRepository.GetAll();
            if (ModulosEntity != null)
                return MapModulosEntity(ModulosEntity);
            else
                return null;
        }

        public ModulosModel MapModulosEntity(Modulos objModuloEntity)
        {
            var objModulosModel = new ModulosModel()
            {
                IdModulo = objModuloEntity.IdModulo,
                Modulo = objModuloEntity.Modulo
            };
            return objModulosModel;
        }

        public List<ModulosModel> MapModulosEntity(IEnumerable<Modulos> objListModulosEntity)
        {
            var objListModulosModel = new List<ModulosModel>();
            foreach (var item in objListModulosEntity)
            {
                objListModulosModel.Add(MapModulosEntity(item));
            }
            return objListModulosModel;
        }
    }
}
