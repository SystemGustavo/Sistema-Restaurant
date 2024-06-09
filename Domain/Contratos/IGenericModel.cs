using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseModels
{
    public interface IGenericModel<Model> where Model : class
    {
        void Add(Model model);//Agregar nuevo Model.
        void Edit(Model model);//Editar nuevo Model.
        void Delete(int id);//Eliminar nuevo Model.
        IEnumerable<Model> GetAll();//listar datos de un Model.
        Model GetById(int id);//Obtener un Model por valor(Buscar).
    }
}
