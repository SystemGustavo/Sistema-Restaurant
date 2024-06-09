using DataAccess.DTO;
using System;
using System.Collections.Generic;


namespace DataAccess.Contracts
{
    public interface IPuntoDeVentaRepository
    {
        IEnumerable<PaginarProductosPorGrupoDTO> PaginarProductosPorGrupo(int idGrupo, int desde, int hasta);
        IEnumerable<PaginarGrupoProductosDTO> PaginarGrupoProductos(int desde, int hasta);
        IEnumerable<MostrarDetalleVentaDTO> MostrarDetalleVentas(int IdMesa, int IdVenta);
    }
}
