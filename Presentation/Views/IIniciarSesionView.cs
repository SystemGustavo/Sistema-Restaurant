using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IIniciarSesionView : ITecladoNumerico
    {
        string usuario { get; set; }
        string contraseña { get; set; }
        Panel PanelVisorUsuarios { get; set; }
        Panel PanelVisorContraseña { get; set; }
        Form FormIniciarSesion { get; set; }
        FlowLayoutPanel FlowPanelMostradorUsuario { get; set; }

        event EventHandler load;
        event EventHandler botonCambiarDeUsuario;
    }
}
