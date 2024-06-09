using DataAccess.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapeador
{
    public abstract class MapPuntoDeVentaModel
    {
        protected PuntoDeVentaModel MapPaginarProductosPorGrupo (PaginarProductosPorGrupoDTO obj)
        {
            var objPuntoDeVentaModel = new PuntoDeVentaModel()
            {
                Id_Producto = obj.Id_Producto,
                Descripcion = obj.Descripcion,
                Imagen = obj.Imagen,
                Precio_de_venta = obj.Precio_de_venta,
                Estado_imagen = obj.Estado_imagen,
                Id_grupo = obj.Id_grupo,
                Precio_de_compra = obj.Precio_de_compra,
                Estado = obj.Estado,
                Moneda = obj.Moneda
            };

            return objPuntoDeVentaModel;
        }

        protected List<PuntoDeVentaModel> MapPaginarProductosPorGrupo (IEnumerable<PaginarProductosPorGrupoDTO> ListPaginado)
        {
            var PaginarProductosPorGrupo = new List<PuntoDeVentaModel>();
            foreach (var item in ListPaginado)
            {
                PaginarProductosPorGrupo.Add(MapPaginarProductosPorGrupo(item));
            }
            return PaginarProductosPorGrupo;
        }

        protected PuntoDeVentaModel MapPaginarGrupos(PaginarGrupoProductosDTO obj)
        {
            var objPuntoDeVentaModel = new PuntoDeVentaModel()
            {
                IdLine = obj.IdLine,
                Grupo = obj.Grupo,
                Imagen = obj.Icono,
                Estado_imagen = obj.Estado_de_icono,
                Estado = obj.Estado
            };

            return objPuntoDeVentaModel;
        }

        protected List<PuntoDeVentaModel> MapPaginarGrupos(IEnumerable<PaginarGrupoProductosDTO> ListPaginado)
        {
            var PaginarGrupos = new List<PuntoDeVentaModel>();
            foreach (var item in ListPaginado)
            {
                PaginarGrupos.Add(MapPaginarGrupos(item));
            }
            return PaginarGrupos;
        }

        protected PuntoDeVentaModel MapMostrarDetalleVenta(MostrarDetalleVentaDTO MostrarDetalleVentaDTO)
        {
            var MostrarDetalleVenta = new PuntoDeVentaModel()
            {
                Id_Producto = MostrarDetalleVentaDTO.IdProducto,
                Descripcion = MostrarDetalleVentaDTO.Descripcion,
                Cantidad = MostrarDetalleVentaDTO.Cantidad,
                PrecioUnitario = MostrarDetalleVentaDTO.PrecioUnitario,
                TotalAPagar = MostrarDetalleVentaDTO.TotalAPagar,
                idDetalleVenta = MostrarDetalleVentaDTO.idDetalleVenta,
                Estado = MostrarDetalleVentaDTO.Estado,
                IdVenta = MostrarDetalleVentaDTO.IdVenta,
                ColorHtml = MostrarDetalleVentaDTO.ColorHtml,
                Nota = MostrarDetalleVentaDTO.Nota,
                CodUm = MostrarDetalleVentaDTO.CodUm,
                Codigo = MostrarDetalleVentaDTO.Codigo,
                CodigoSunat = MostrarDetalleVentaDTO.Codigo
            };
            return MostrarDetalleVenta;
        }

        protected List<PuntoDeVentaModel> MapMostrarDetalleVenta(IEnumerable<MostrarDetalleVentaDTO> ListDetalleVenta)
        {
            var MostrarDetalleVenta = new List<PuntoDeVentaModel>();
            foreach (var item in ListDetalleVenta)
            {
                MostrarDetalleVenta.Add(MapMostrarDetalleVenta(item));
            }
            return MostrarDetalleVenta;
        }
    }
}
