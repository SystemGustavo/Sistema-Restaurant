using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapeador
{
    public abstract class MapColoresModel
    {
        protected ColoresModel MapColoresModels(Colores objColores) 
        {
            var ColoresModel = new ColoresModel
            {
                Idcolor = objColores.Idcolor,
                colorhtml = objColores.colorhtml
            };
            return ColoresModel;
        }

        protected List<ColoresModel> MapColoresModels (IEnumerable<Colores> ListColores) 
        {
            var ColoresModel = new List<ColoresModel>();
            foreach (var item in ListColores)
            {
                ColoresModel.Add(MapColoresModels(item));
            }
            return ColoresModel;
        }

    }
}
