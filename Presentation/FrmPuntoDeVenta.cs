using Presentation.ViewModels;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmPuntoDeVenta : Form,IPuntoDeVentaView
    {

        public FlowLayoutPanel fpanelListProductos { get => fpanelProductos; set => fpanelProductos = value; }
        public string hora { get => lblHora.Text; set => lblHora.Text = value; }
        public string fecha { get => lblFecha.Text; set => lblFecha.Text = value; }
        public double acumuladorDinero { get; set; }
        public Label lblAcumulador { get => lblAcumulado; set => lblAcumulado=value; }
        public Form FormCobros { get; set; }
        public FlowLayoutPanel fpanelListGrupos { get => fPanelGrupos; set => fPanelGrupos=value; }
        public FlowLayoutPanel fpanelDetalleVentas { get => flpDetalleVentas; set => flpDetalleVentas = value; }

        public event EventHandler EventFrmPuntoDeVentaLoad;
        public event EventHandler EventTimerFechaHora;
        public event EventHandler EventBoton1Sol;
        public event EventHandler EventBoton5Soles;
        public event EventHandler EventBoton10Soles;
        public event EventHandler EventBoton20Soles;
        public event EventHandler EventBoton50Soles;
        public event EventHandler EventBoton100Soles;
        public event EventHandler EventBotonExacto;
        public event EventHandler EventBotonCobrar;

        public FrmPuntoDeVenta()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            this.WindowState = FormWindowState.Maximized;
        }

        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate
            {
                EventFrmPuntoDeVentaLoad?.Invoke(this, EventArgs.Empty);
            };

            TiempoFechaHora.Tick += delegate
            {
                EventTimerFechaHora?.Invoke(this, EventArgs.Empty);
            };

            btn1Sol.Click += delegate
            {
                EventBoton1Sol?.Invoke(this, EventArgs.Empty);
            };

            btn5Soles.Click += delegate
            {
                EventBoton5Soles?.Invoke(this, EventArgs.Empty);
            };

            btn20Soles.Click += delegate
            {
                EventBoton20Soles?.Invoke(this, EventArgs.Empty);
            };

            btn10Soles.Click += delegate
            {
                EventBoton10Soles?.Invoke(this, EventArgs.Empty);
            };

            btn50Soles.Click += delegate
            {
                EventBoton50Soles?.Invoke(this, EventArgs.Empty);
            };

            btn100Soles.Click += delegate
            {
                EventBoton100Soles?.Invoke(this, EventArgs.Empty);
            };

            btnExacto.Click += delegate
            {
                EventBotonExacto?.Invoke(this, EventArgs.Empty);
            };

            btnCobrar.Click += delegate
            {
                EventBotonCobrar?.Invoke(this, EventArgs.Empty);
            };

        }

    }
}
