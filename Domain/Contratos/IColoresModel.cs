using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contratos
{
    public interface IColoresModel
    {
        void InsertarColores();
        List<ColoresModel> MostrarColores();
        string ObtenerColorPorId(int idColor);
    }
}
