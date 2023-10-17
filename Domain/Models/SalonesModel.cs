using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SalonesModel
    {
        public int IdSalon { get; set; }
        public string Salon { get; set; }
        public string Estado { get; set; }

        public List<SalonesModel> ListSalonesModel { get; set; }

        private ISalonesRepository SalonesRepository;
       

        public SalonesModel()
        {
            SalonesRepository = new SalonesRepository();
        }

        public List<SalonesModel> ListSalones()
        {
            var SalonesList = SalonesRepository.GetAll();
            ListSalonesModel = new List<SalonesModel>();
            foreach (Salones item in SalonesList)
            {
                ListSalonesModel.Add(new SalonesModel
                {
                    IdSalon =item.IdSalon,
                    Salon = item.Salon,
                    Estado = item.Estado
                });
            }
            return ListSalonesModel;
        }

        public void AddSalon(SalonesModel salonesModel)
        {
            var objSalon = new Salones();
            objSalon.Salon = salonesModel.Salon;
            SalonesRepository.Add(objSalon);
        }
    }
}
