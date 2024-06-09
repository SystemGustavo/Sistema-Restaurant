using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Mapeador;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ProductosModel : MapProductosModel, IProductosModel
    {
        public int Id_Producto1 { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerido.")]
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El IdGrupo debe ser diferente de 0.")]
        public int Id_grupo { get; set; }
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "El Precio de Venta debe ser diferente de 0.")]
        public double Precio_de_venta { get; set; }
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "El Precio de Compra debe ser diferente de 0.")]
        public double Precio_de_compra { get; set; }
        [Required(ErrorMessage = "El Estado de Imagen es requerido.")]
        public string Estado_imagen { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El IdColor debe ser diferente de 0.")]
        public int Idcolor { get; set; }
        [Required(ErrorMessage = "El Estado es requerido.")]
        public string Estado { get; set; }
        public string CodUm { get; set; }
        public string CodigoSunat { get; set; }
        public string Codigo { get; set; }

        //others properties
        public string Moneda { get; set; }
        public string ColorHtml { get; set; }

        private IProductosRepository ProductosRepository;

        public ProductosModel()
        {
            ProductosRepository = new ProductosRepository();
        }

        public List<ProductosModel> MostrarProductosPorGrupos(int IdGrupo, string value)
        {
            var MostProductosXGrupos = ProductosRepository.ListMostrarProductosPorGrupo(IdGrupo, value);
            if (MostProductosXGrupos != null)
                return MapMostrarProductosPorGrupoDTO(MostProductosXGrupos);
            else
                return null;
        }

        public bool RestaurarProductos(int idProducto)
        {
            var RestaurarProducto = ProductosRepository.RestaurarProductos(idProducto);
            if (RestaurarProducto)
                return true;
            else
                return false;
        }

        public void Add(ProductosModel model)
        {
            ProductosRepository.Add(MapProductos(model));
        }

        public void Edit(ProductosModel model)
        {
            ProductosRepository.Update(MapProductos(model));
        }

        public void Delete(int id)
        {
            ProductosRepository.Delete(id);
        }

        public IEnumerable<ProductosModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductosModel GetById(int id)
        {
            var ObjProducto = ProductosRepository.GetById(id);
            if (ObjProducto != null)
                return MapProductoModel(ObjProducto);
            else
                return null;
        }

        public List<ProductosModel> ListMostrarColorXProductoDTO(int IdProducto)
        {
            var MostrarColorXProductoDTO = ProductosRepository.ListMostrarColorXProductoDTO(IdProducto);
            if (MostrarColorXProductoDTO != null)
                return MapMostrarColorXProducto(MostrarColorXProductoDTO);
            else
                return null;
        }
    }
}
