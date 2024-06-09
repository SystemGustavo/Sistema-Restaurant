using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapeador
{
    public abstract class MapGrupoProductosModel
    {
        protected GrupoProductosModel MapGrupoProductosModels(GrupoProductos objGrupoDeProductosEntity)
        {
            var ObjGrupoDeProductosModel = new GrupoProductosModel()
            {
                Idline = Convert.ToInt32(objGrupoDeProductosEntity.Idline),
                Grupo = objGrupoDeProductosEntity.Grupo,
                Por_defecto = objGrupoDeProductosEntity.Por_defecto,
                Icono = objGrupoDeProductosEntity.Icono,
                Estado = objGrupoDeProductosEntity.Estado,
                Estado_de_icono = objGrupoDeProductosEntity.Estado_de_icono,
                Idcolor = objGrupoDeProductosEntity.Idcolor
            };
            return ObjGrupoDeProductosModel;
        }

        protected GrupoProductos MapGrupoProductosModels(GrupoProductosModel objGrupoProductosModel)
        {
            var ObjGrupoDeProductos= new GrupoProductos()
            {
                Idline = Convert.ToInt32(objGrupoProductosModel.Idline),
                Grupo = objGrupoProductosModel.Grupo,
                Por_defecto = objGrupoProductosModel.Por_defecto,
                Icono = objGrupoProductosModel.Icono,
                Estado = objGrupoProductosModel.Estado,
                Estado_de_icono = objGrupoProductosModel.Estado_de_icono,
                Idcolor = objGrupoProductosModel.Idcolor
            };
            return ObjGrupoDeProductos;
        }

        protected List<GrupoProductosModel> MapGrupoDeProductosModels(IEnumerable<GrupoProductos> ListGrupoDeProductosEntity)
        {
            List<GrupoProductosModel> ListGrupoDeProductosModel = new List<GrupoProductosModel>();
            foreach (var item in ListGrupoDeProductosEntity)
            {
                ListGrupoDeProductosModel.Add(MapGrupoProductosModels(item));
            }
            return ListGrupoDeProductosModel;
        }

        protected GrupoProductos MapUpdateGrupoProducto(GrupoProductosModel objGrupoDeProductosModel)
        {
            var ObjGrupoDeProductosModel = new GrupoProductos()
            {
                Grupo = objGrupoDeProductosModel.Grupo,
                Idline = Convert.ToInt32(objGrupoDeProductosModel.Idline),
                Icono = objGrupoDeProductosModel.Icono,
                Estado_de_icono = objGrupoDeProductosModel.Estado_de_icono,
                Idcolor = Convert.ToInt32(objGrupoDeProductosModel.Idcolor)
            };
            return ObjGrupoDeProductosModel;
        }

    }
}
