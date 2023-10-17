using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseModels
{
    public interface IMovimientoDeCajaModel : IGeneric<IMovimientoDeCajaModel>
    {
        int MovimientoDeCajaPorUsuario(int UsuarioInicioCaja, string SerialPc);
        string MovimientoDeCajaPorSerial(string SerialPc);
        bool EditarDineroInicial(int IdCaja, double EfectivoInicial);
    }
}
