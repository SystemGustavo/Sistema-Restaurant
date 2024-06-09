using Domain.BaseModels;
using Domain.Models;
using Domain.ObjectValues;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IEmpresaModel : IGenericModel<EmpresaModel>
    {
        bool EditarRespaldo();
        List<Paises> ListPaises();
        List<string> ListImpuestos();
        List<int> ListValoresImpuestos();
    }
}
