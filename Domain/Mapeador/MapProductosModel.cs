using DataAccess.DTO;
using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Mapeador
{
    public abstract class MapProductosModel
    {
        protected Productos MapProductos(ProductosModel objProductoModel)
        {
            var Productos = new Productos()
            {
                Id_Producto = objProductoModel.Id_Producto1,
                Descripcion = objProductoModel.Descripcion,
                Imagen = objProductoModel.Imagen,
                Id_grupo = objProductoModel.Id_grupo,
                Precio_de_venta = objProductoModel.Precio_de_venta,
                Precio_de_compra = objProductoModel.Precio_de_compra,
                Idcolor = objProductoModel.Idcolor,
                Estado = objProductoModel.Estado,
                Estado_imagen = objProductoModel.Estado_imagen,
                CodUm = objProductoModel.CodUm,
                CodigoSunat = objProductoModel.CodigoSunat,
                Codigo = objProductoModel.Codigo
            };
            return Productos;
        }

        protected ProductosModel MapProductoModel(Productos objProducto)
        {
            var objProductoModel = new ProductosModel()
            {
                Id_Producto1 = objProducto.Id_Producto,
                Descripcion = objProducto.Descripcion,
                Imagen = objProducto.Imagen,
                Id_grupo = objProducto.Id_grupo,
                Precio_de_venta = objProducto.Precio_de_venta,
                Precio_de_compra = objProducto.Precio_de_compra,
                Idcolor = objProducto.Idcolor,
                Estado = objProducto.Estado,
                Estado_imagen = objProducto.Estado_imagen
            };
            return objProductoModel;
        }


        protected ProductosModel MapMostrarColorXProducto(MostrarColorXProductoDTO objMostrarColorXProductoDTO)
        {
            var ProductosModel = new ProductosModel
            {
                ColorHtml = objMostrarColorXProductoDTO.ColorHtml,
                Idcolor = objMostrarColorXProductoDTO.IdColor,
                Imagen = objMostrarColorXProductoDTO.Imagen,
                Estado_imagen = objMostrarColorXProductoDTO.EstadoImagen,
                Precio_de_compra = objMostrarColorXProductoDTO.Precio_de_compra,
                Precio_de_venta = objMostrarColorXProductoDTO.Precio_de_venta
            };
            return ProductosModel;
        }

        protected List<ProductosModel> MapMostrarColorXProducto(IEnumerable<MostrarColorXProductoDTO> objMostrarColorXProducto)
        {
            var MostrarColorXProducto = new List<ProductosModel>();
            foreach (var item in objMostrarColorXProducto)
            {
                MostrarColorXProducto.Add(MapMostrarColorXProducto(item));
            }
            return MostrarColorXProducto;
        }


        //protected List<ProductosModel> MapProductosModels(IEnumerable<Productos> ListProductos)
        //{
        //    List<ProductosModel> ListProductosModel = new List<ProductosModel>();
        //    foreach (var item in ListProductos)
        //    {
        //        ListProductosModel.Add(MapProductosModels(item));
        //    };
        //    return ListProductosModel;

        //}

        protected ProductosModel MapMostrarProductosPorGrupoDTO(MostrarProductosPorGrupoDTO ObjMostrarProductosPorGrupoDTO)
        {
            var MapMostrarProductosPorGrupoDTOs = new ProductosModel()
            {
                Id_Producto1 = Convert.ToInt32(ObjMostrarProductosPorGrupoDTO.IdProducto1),
                Descripcion = ObjMostrarProductosPorGrupoDTO.Descripcion,
                Estado = ObjMostrarProductosPorGrupoDTO.Estado,
                Estado_imagen = ObjMostrarProductosPorGrupoDTO.Estado_imagen,
                Imagen = ObjMostrarProductosPorGrupoDTO.Imagen,
                Moneda = ObjMostrarProductosPorGrupoDTO.Moneda,
                Precio_de_venta = ObjMostrarProductosPorGrupoDTO.Precio_de_venta
            };
            return MapMostrarProductosPorGrupoDTOs;
        }

        protected List<ProductosModel> MapMostrarProductosPorGrupoDTO(IEnumerable<MostrarProductosPorGrupoDTO> objMapMostrarProductosPorGrupoDTO)
        {
            List<ProductosModel> MapMostrarProductosPorGrupoDTOs = new List<ProductosModel>();
            foreach (var item in objMapMostrarProductosPorGrupoDTO)
            {
                MapMostrarProductosPorGrupoDTOs.Add(MapMostrarProductosPorGrupoDTO(item));
            }
            return MapMostrarProductosPorGrupoDTOs;
        }

    }
}
