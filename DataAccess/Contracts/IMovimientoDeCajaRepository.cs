using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace DataAccess.Contracts
{
    public interface IMovimientoDeCajaRepository : IGenericRepository<MovimientoDeCaja>
    {
        string MovimientoDeCajaPorSerial(string SerialPc);
        int MovimientoDeCajaPorIdUsuario(int idUsuario,string SerialPc);
        bool EditarDineroInicial(int IdCaja, double EfectivoInicial);
        void Add(int IdUsuario, int IdCaja);
    }
}
