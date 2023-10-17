using DataAccess.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMesasRepository : IGenericRepository<Mesas>
    {
        IEnumerable<MostrarMesasPorSalonDTO> MostrarMesasporSalon(int idSalon);
    }
}
