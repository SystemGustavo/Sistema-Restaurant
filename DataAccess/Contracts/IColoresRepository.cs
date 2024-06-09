using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Contracts
{
    public interface IColoresRepository
    {
        void InsertarColores();
        IEnumerable<Colores> MostrarColores();
    }
}
