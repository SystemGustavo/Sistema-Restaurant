using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IGrupoDeProductosRepository : IGenericRepository<GrupoProductos>
    {
        IEnumerable<GrupoProductos> BuscarPorGrupos(string grupo);
        bool RestaurarGrupoDeProductos(int IdGrupo);
        IEnumerable<GrupoProductos> PaginarGrupoProductos(int desde,int hasta);
    }
}
