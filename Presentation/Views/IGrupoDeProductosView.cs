using ControlesPersonalizados.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IGrupoDeProductosView
    {
        int Idline { get; set; }
        string Grupo { get; set; }
        string Por_defecto { get; set; }
        byte[] Icono { get; set; }
        string EstadoGrupoProducto { get; set; }
        string Estado_de_icono { get; set; }
        //int Idcolor { get; set; }
        string BuscarGrupo { get; set; }
        TabPage PestañaCrudGrupos { get; set; }
        FlowLayoutPanel PanelGrupo { get; set; }
        FlowLayoutPanel fpColores { get; set; } 
        CTextBox grupo { get; set; }
        CCircularPictureBox pbIcono { get; set; }
        Panel PanelBienvenidaGrupo { get; set; }
        Button AccionButonGrupoProducto { get; set; }
        event EventHandler EventOnTextChanged2;
        event EventHandler EventBotonAccionGrupo;
        event EventHandler EventBotonCancelarGrupo;
        event EventHandler EventAgregarGrupo;
        event EventHandler EventBotonAccionGrupoProducto;
        event EventHandler EventClickIconoGrupoProducto;
    }
}
