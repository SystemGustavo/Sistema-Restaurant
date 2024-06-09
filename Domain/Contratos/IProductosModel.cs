using Domain.BaseModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductosModel : IGenericModel<ProductosModel>
    {
        List<ProductosModel> MostrarProductosPorGrupos(int IdGrupo, string value);
        bool RestaurarProductos(int idProducto);
        List<ProductosModel> ListMostrarColorXProductoDTO(int IdProducto);

    }
}
