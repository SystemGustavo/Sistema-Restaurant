using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IProductosRepository : IGenericRepository<Productos>
    {
        IEnumerable<MostrarProductosPorGrupoDTO> ListMostrarProductosPorGrupo(int idGrupo, string value);
        bool RestaurarProductos(int idProducto);
        IEnumerable<MostrarColorXProductoDTO> ListMostrarColorXProductoDTO(int IdProducto);
    }
}
