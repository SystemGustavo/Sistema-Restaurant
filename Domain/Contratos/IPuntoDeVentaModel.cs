using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contratos
{
    public interface IPuntoDeVentaModel
    {
        List<PuntoDeVentaModel> PaginarProductosPorGrupo(int idGrupo, int desde, int hasta);
        List<PuntoDeVentaModel> PaginarGrupoProductos(int desde, int hasta);
        List<PuntoDeVentaModel> MostrarDetalleVenta(int IdMesa, int IdVenta);
    }
}
