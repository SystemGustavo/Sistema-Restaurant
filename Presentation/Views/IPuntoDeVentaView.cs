using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IPuntoDeVentaView
    {
        FlowLayoutPanel fpanelListProductos { get; set; }
        FlowLayoutPanel fpanelListGrupos { get; set; }
        FlowLayoutPanel fpanelDetalleVentas { get; set; }
        Label lblAcumulador { get; set; }
        Form FormCobros { get; set; }
        double acumuladorDinero { get; set; }
        string hora { get; set; }
        string fecha { get; set; }


        event EventHandler EventFrmPuntoDeVentaLoad;
        event EventHandler EventTimerFechaHora;
        event EventHandler EventBoton1Sol;
        event EventHandler EventBoton5Soles;
        event EventHandler EventBoton10Soles;
        event EventHandler EventBoton20Soles;
        event EventHandler EventBoton50Soles;
        event EventHandler EventBoton100Soles;
        event EventHandler EventBotonExacto;

        event EventHandler EventBotonCobrar;
    }
}
