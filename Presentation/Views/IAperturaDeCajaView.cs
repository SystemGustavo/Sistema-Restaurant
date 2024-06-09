using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IAperturaDeCajaView : ITecladoNumerico
    {
        string Monto { get; set; }
        Form FrmAperturaCaja { get; set; }
        Panel pnlCaja { get; set; }

        event EventHandler botonOmitir;
        event EventHandler botonIniciar;
        event EventHandler formAperturaCaja;
        event KeyPressEventHandler EventKeyPressMonto;
    }
}
