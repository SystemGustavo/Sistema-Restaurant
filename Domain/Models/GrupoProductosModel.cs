using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.BaseModels;
using Domain.Contratos;
using Domain.Mapeador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GrupoProductosModel : MapGrupoProductosModel,IGrupoDeProductosModel
    {
        public int Idline { get; set; }
        [Required(ErrorMessage = "El Grupo Producto es requerido.")]
        public string Grupo { get; set; }
        public string Por_defecto { get; set; }
        public byte[] Icono { get; set; }
        [Required(ErrorMessage = "El Estado Grupo Producto es requerido.")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El Estado Icono Grupo Producto es requerido.")]
        public string Estado_de_icono { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "El IdColor debe ser diferente de 0.")]
        public int Idcolor { get; set; }

        private IGrupoDeProductosRepository  GrupoDeProductosRepository { get; set; }
        public GrupoProductosModel()
        {
            GrupoDeProductosRepository = new GrupoDeProductosRepository();
        }

        public List<GrupoProductosModel> ListGrupoDeProductosModel(string grupo)
        {
            var ListBuscarPorGrupos = GrupoDeProductosRepository.BuscarPorGrupos(grupo);
            if (ListBuscarPorGrupos != null)
                return MapGrupoDeProductosModels(ListBuscarPorGrupos);
            else
                return null;
          
        }

        public bool RestaurarGrupoDeProductos(int IdGrupo)
        {
            if (IdGrupo > 0)
            {
                GrupoDeProductosRepository.RestaurarGrupoDeProductos(IdGrupo);
                return true;
            }
            else
                return false;
        }

        public void Add(GrupoProductosModel model)
        {
            GrupoProductos objGrupoProducto = MapGrupoProductosModels(model);
            GrupoDeProductosRepository.Add(objGrupoProducto);
        }

        public void Edit(GrupoProductosModel model)
        {
            GrupoProductos objGrupoProducto = MapUpdateGrupoProducto(model);
            GrupoDeProductosRepository.Update(objGrupoProducto);
        }

        public void Delete(int id)
        {
            GrupoDeProductosRepository.Delete(id);
        }

        public IEnumerable<GrupoProductosModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public GrupoProductosModel GetById(int id)
        {
            var ObjGrupoProducto = GrupoDeProductosRepository.GetById(id);
            if (ObjGrupoProducto != null)
                return MapGrupoProductosModels(ObjGrupoProducto);
            else
                return null;
        }
    }
}
