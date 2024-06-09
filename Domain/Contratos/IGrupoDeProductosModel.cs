using Domain.BaseModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contratos
{
    public interface IGrupoDeProductosModel : IGenericModel<GrupoProductosModel>
    {
        List<GrupoProductosModel> ListGrupoDeProductosModel(string grupo);
        bool RestaurarGrupoDeProductos(int IdGrupo);
    }
}
