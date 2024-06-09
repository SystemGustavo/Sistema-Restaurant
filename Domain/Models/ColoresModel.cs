using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Contratos;
using Domain.Mapeador;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ColoresModel : MapColoresModel, IColoresModel
    {
        public int Idcolor { get; set; }
        public string colorhtml { get; set; }
        private IColoresRepository ColoresRepository { get; set; }

        public ColoresModel()
        {
            ColoresRepository = new ColoresRepository();
        }

        public void InsertarColores()
        {
            throw new System.NotImplementedException();
        }

        public List<ColoresModel> MostrarColores()
        {
            var ColoresModel = ColoresRepository.MostrarColores();
            if (ColoresModel != null)
                return MapColoresModels(ColoresModel);
            else
                return null;
        }

        public string ObtenerColorPorId(int idColor)
        {
           var ObjColor = MostrarColores().Find(c => c.Idcolor == idColor);
            return ObjColor.colorhtml;
        }
    }
}
