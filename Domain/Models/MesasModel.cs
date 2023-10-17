using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MesasModel
    {
        public int IdMesa { get; set; }
        public string Mesa { get; set; }
        public int IdSalon { get; set; }
        public string EstadoVida { get; set; }
        public string EstadoDisponibilidad { get; set; }

        private IMesasRepository MesasRepository;
        private List<MostrarMesasPorSalonDTOs> MostrarMesasPorSalonDTOsList { get; set; }

        public Salones Salon { get; set; }

        public MesasModel()
        {
            MesasRepository = new MesasRepository();
        }

        public List<MostrarMesasPorSalonDTOs> MostrarMesasPorSalones(int idSalon)
        {
            var MesasxSalonList = MesasRepository.MostrarMesasporSalon(idSalon);
            MostrarMesasPorSalonDTOsList = new List<MostrarMesasPorSalonDTOs>();
            foreach (MostrarMesasPorSalonDTOs item in MapListMostrarMesasPorSalonDTOs(MesasxSalonList))
            {
                MostrarMesasPorSalonDTOsList.Add(new MostrarMesasPorSalonDTOs
                {
                    IdMesa = item.IdMesa,
                    Mesa = item.Mesa,
                });
            }
            return MostrarMesasPorSalonDTOsList;
        }

        public MostrarMesasPorSalonDTOs MapMostrarMesasPorSalonDTOs (MostrarMesasPorSalonDTO MostrarMesasPorSalonDTO)
        {
            var MostrarMesasPorSalonDTOs = new MostrarMesasPorSalonDTOs()
            {
                IdMesa = MostrarMesasPorSalonDTO.IdMesa,
                Mesa = MostrarMesasPorSalonDTO.Mesa
            };
            return MostrarMesasPorSalonDTOs;
        }

        public List<MostrarMesasPorSalonDTOs> MapListMostrarMesasPorSalonDTOs(IEnumerable<MostrarMesasPorSalonDTO> ListMostrarMesasPorSalonDTO)
        {
            var ListMostrarMesasPorSalonDTOs = new List<MostrarMesasPorSalonDTOs>();
            foreach (var item in ListMostrarMesasPorSalonDTO)
            {
                ListMostrarMesasPorSalonDTOs.Add(MapMostrarMesasPorSalonDTOs(item));
            }
            return ListMostrarMesasPorSalonDTOs;
        }
    }
}
