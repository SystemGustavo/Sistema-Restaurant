using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    interface IIniciosDeSesionRepository : IGenericRepository<IniciosDeSesion>
    {
        int MostrarIdEstadoDeSesion(int IdCaja);
    }
}
