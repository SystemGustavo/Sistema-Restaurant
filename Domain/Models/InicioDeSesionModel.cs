using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class InicioDeSesionModel
    {
        public int idSesion { get; set; }
        public int idCaja { get; set; }
        public int idUsuario { get; set; }

        private IniciosDeSesionRepository IniciosDeSesion { get; set; }
        
        public InicioDeSesionModel()
        {
            IniciosDeSesion = new IniciosDeSesionRepository();
        }

        public InicioDeSesionModel(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public InicioDeSesionModel(int idUsuario,int idSesion)
        {
            this.idUsuario = idUsuario;
            this.idSesion = idSesion;
        }

        public int MostrarIdEstadoDeSesion(int IdCaja)
        {
            return IniciosDeSesion.MostrarIdEstadoDeSesion(IdCaja);
        }

        public IniciosDeSesion MapIniciosDeSesion(InicioDeSesionModel objIniciosDeSesionModel)
        {
            IniciosDeSesion ObjIniciosDeSesion = new IniciosDeSesion()
            {
                idSesion = objIniciosDeSesionModel.idSesion,
                idUsuario = objIniciosDeSesionModel.idUsuario
            };
            return ObjIniciosDeSesion;
        }

        public void Add(InicioDeSesionModel objIniciosDeSesionModel)
        {
            IniciosDeSesion objEntityInicioDeSesion = MapIniciosDeSesion(objIniciosDeSesionModel);
            IniciosDeSesion.Add(objEntityInicioDeSesion);
        }

        public void Update(InicioDeSesionModel objIniciosDeSesionModel)
        {
            IniciosDeSesion objEntityInicioDeSesion = objIniciosDeSesionModel.MapIniciosDeSesion(objIniciosDeSesionModel);
            IniciosDeSesion.Update(objEntityInicioDeSesion);
        }

    }
}
