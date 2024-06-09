using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IColoresView
    {
        int Idcolor { get; set; }
        string ProductoColorhtml { get; set; }
        string GrupoProductoColorhtml { get; set; }
        Button btn_GrupoProducto_Color { get; set; }
        Button btn_Producto_Color { get; set; }
        FlowLayoutPanel flpGrupoDeColores { get; set; }
    }
}
