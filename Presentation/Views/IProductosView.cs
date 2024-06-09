using ControlesPersonalizados.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IProductosView : IGrupoDeProductosView, IColoresView
    {
         int Id_Producto1 { get; set; }
         string Descripcion { get; set; }
         byte[] Imagen { get; set; }
         double Precio_de_compra { get; set; }
         double Precio_de_venta { get; set; }
         string EstadoProducto { get; set; }
         string Estado_Imagen { get; set; }
         string Moneda { get; set; }
         string CodUm { get; set; }
         string CodigoSunat { get; set; }
         string Codigo { get; set; }
         Form FormProductos { get; set; }
         DialogResult objDialogResult { get; set; }
         
         FlowLayoutPanel PanelProductos { get; set; }
         Panel PanelSuperiorAddProducto { get; set; }
         Panel VisorPanelProductos { get; set; }
         CLabel ElegirGrupo { get; set; }

         CTextBox CtxtDescripcion { get; set; }
         CTextBox CtxtPrecioDeCompra { get; set; }
         CTextBox CtxtPrecioDeVenta { get; set; }

         TabPage PestañaProductos{ get; set; }
         TabPage PestañaCrudProductos { get; set; } 
         TabControl TabControl { get; set; }
         Button AccionBoton { get; set; }
         CCircularPictureBox pictureImagen { get; set; }

         event EventHandler EventOnTextChanged1;
         event EventHandler EventFrmProductosLoad;
         event KeyPressEventHandler EventKeyPressPrecioDeCompra;
         event KeyPressEventHandler EventKeyPressPrecioDeVenta;
         event EventHandler EventAgregarProducto;
         event EventHandler EventBotonCancelarProducto;
         event EventHandler EventBotonAccionProducto;
         event EventHandler EventClickImagenProducto;
    }
}
