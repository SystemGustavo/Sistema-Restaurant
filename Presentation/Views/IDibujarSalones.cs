using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IDibujarSalones
    {

        event EventHandler AgregarSalon;
        event EventHandler EditarSalon;
        event EventHandler EliminarSalon;
        event EventHandler Salir;

        Button Boton { get; set; }
        Panel Panel1 { get; set; }
        Panel Panel2 { get; set; }

        FlowLayoutPanel FPanelSalones { get; set; }
        Form Form { get; set; }
    }
}
