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
    public interface IPermisosRepository : IGenericRepository<Permisos>
    {
        int AddRange(List<Permisos> objListPermisosEntity);
        List<MostrarPermisosDTO> mostrarPermisos(int idUsuario);
    }
}
