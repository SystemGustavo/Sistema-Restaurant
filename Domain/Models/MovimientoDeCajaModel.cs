using Common.Cache;
using DataAccess.Contracts;
using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovimientoDeCajaModel
    {
        public int IdMovimientoCaja { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafin { get; set; }
        public double ingresos { get; set; }
        public double egresos { get; set; }
        public double VEfectivo { get; set; }
        public double VCredito { get; set; }
        public double VTarjeta { get; set; }
        public int Idusuario { get; set; }
        public double EfectivoCalculado { get; set; }
        public double EfectivoReal { get; set; }
        public double EfectivoDiferencia { get; set; }
        public int IdCaja { get; set; }
        public string Estado { get; set; }
        public double EfectivoInicial { get; set; }
        

        private IMovimientoDeCajaRepository MovimientoDeCajaRepository{ get; set; }

        public MovimientoDeCajaModel()
        {
            MovimientoDeCajaRepository = new MovimientoDeCajaRepository();
        }

        public void InsertarMovimientoDeCaja(int IdUsuario, int IdCaja)
        {
            MovimientoDeCajaRepository.Add(IdUsuario, IdCaja);
        }

        public int MovimientoDeCajaPorIdUsuario(int idUsuario,string SerialPc)
        {
            return MovimientoDeCajaRepository.MovimientoDeCajaPorIdUsuario(idUsuario, SerialPc);
        }

        public string MovimientoDeCajaPorSerial(string SerialPc)
        {
           return MovimientoDeCajaRepository.MovimientoDeCajaPorSerial(SerialPc);
        }

        public bool EditarDineroInicial(int IdCaja, double EfectivoInicial)
        {
            var result = MovimientoDeCajaRepository.EditarDineroInicial(IdCaja, EfectivoInicial);
            if (result)
                return true;
            else
                return false;
        }

    }
}
