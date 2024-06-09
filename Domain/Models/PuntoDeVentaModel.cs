using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Contratos;
using Domain.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PuntoDeVentaModel : MapPuntoDeVentaModel, IPuntoDeVentaModel
    {
        public int Id_Producto { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public double Precio_de_venta { get; set; }
        public string Estado_imagen { get; set; }
        public int Id_grupo { get; set; }
        public double Precio_de_compra { get; set; }
        public string Estado { get; set; }
        public string Moneda { get; set; }
        public int IdLine { get; set; }
        public string Grupo { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalAPagar { get; set; }
        public int idDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public string ColorHtml { get; set; }
        public string Nota { get; set; }
        public string CodUm { get; set; }
        public string Codigo { get; set; }
        public string CodigoSunat { get; set; }
   

        private IPuntoDeVentaRepository PuntoDeVentaRepository;

        public List<PuntoDeVentaModel> listPuntoDeVentaModel;
        public PuntoDeVentaModel()
        {
            PuntoDeVentaRepository = new PuntoDeVentaRepository();
        }


        public List<PuntoDeVentaModel> PaginarProductosPorGrupo(int idGrupo, int desde, int hasta)
        {
            var ListPaginarProductosPorGrupo = PuntoDeVentaRepository.PaginarProductosPorGrupo(idGrupo,desde,hasta);
            if (ListPaginarProductosPorGrupo != null)
                return MapPaginarProductosPorGrupo(ListPaginarProductosPorGrupo);
            else
                return null;
        }

        public List<PuntoDeVentaModel> PaginarGrupoProductos(int desde, int hasta)
        {
            var ListPaginarGrupos = PuntoDeVentaRepository.PaginarGrupoProductos(desde, hasta);
            if (ListPaginarGrupos != null)
                return MapPaginarGrupos(ListPaginarGrupos);
            else
                return null;
        }

        public List<PuntoDeVentaModel> MostrarDetalleVenta(int IdMesa, int IdVenta)
        {
            var ListMostrarDetalleVenta = PuntoDeVentaRepository.MostrarDetalleVentas(IdMesa, IdVenta);
            if (ListMostrarDetalleVenta != null)
                return MapMostrarDetalleVenta(ListMostrarDetalleVenta);
            else
                return null;
        }
    }
}
