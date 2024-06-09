using DataAccess.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IDetalleVentaRepository
    {
        int InsertarDetalleVenta(DetalleVentas objDetalleVenta);
        int EditarEstadoDetalleVenta(int idDetalleVenta);
        IEnumerable<MostrarDetalleVentaDTO> MostrarDetalleVentas(int IdMesa, int IdVenta);
    }
}
