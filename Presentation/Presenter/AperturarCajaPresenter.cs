using Common.Bases;
using Common.Cache;
using ControlesPersonalizados.Controles;
using Domain.Models;
using Presentation.Views;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class AperturarCajaPresenter 
    {
        private IAperturaDeCajaView IAperturarCajaView;
        private MovimientoDeCajaModel MovimientoCajaModel;
        private CajasModel CajasModel;

        public AperturarCajaPresenter(IAperturaDeCajaView IAperturarCajaView,
                                      MovimientoDeCajaModel MovimientoCajaModel,
                                      CajasModel CajasModel)
        {
            this.IAperturarCajaView = IAperturarCajaView;
            this.MovimientoCajaModel = MovimientoCajaModel;
            this.CajasModel = CajasModel;

            //Subscribe event handler methods to view events
            IAperturarCajaView.boton1 += btn1_Click;
            IAperturarCajaView.boton2 += btn2_Click;
            IAperturarCajaView.boton3 += btn3_Click;
            IAperturarCajaView.boton4 += btn4_Click;
            IAperturarCajaView.boton5 += btn5_Click;
            IAperturarCajaView.boton6 += btn6_Click;
            IAperturarCajaView.boton7 += btn7_Click;
            IAperturarCajaView.boton8 += btn8_Click;
            IAperturarCajaView.boton9 += btn9_Click;
            IAperturarCajaView.boton0 += btn0_Click;

            IAperturarCajaView.formAperturaCaja += FrmAperturarCaja_Load;
            IAperturarCajaView.botonBorrar += btnBorrar_Click;
            IAperturarCajaView.botonBorrarDerecha += btnBorrarDerecha_Click;
            IAperturarCajaView.botonOmitir += btnOmitir_Click;
            IAperturarCajaView.botonIniciar += btnIniciar_Click;
            IAperturarCajaView.EventKeyPressMonto += txtMonto_KeyPress;

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && (~IAperturarCajaView.TextBox.Text.IndexOf(".")) != 0)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void FrmAperturarCaja_Load(object sender, EventArgs e)
        {
            IAperturarCajaView.pnlCaja.Location = new Point((IAperturarCajaView.FrmAperturaCaja.Width - IAperturarCajaView.pnlCaja.Width) / 2, (IAperturarCajaView.FrmAperturaCaja.Height - IAperturarCajaView.pnlCaja.Height) / 2);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IAperturarCajaView.TextBox.Text))
            {
                double Monto = Convert.ToDouble(IAperturarCajaView.TextBox.Text);
                CajasModel.MostrarIdCajaSerial(Bases.Obtener_serialPC());
                bool result = MovimientoCajaModel.EditarDineroInicial(CajaCache.idCaja, Monto);
                if (result){
                    IAperturarCajaView.FrmAperturaCaja.Dispose();
                    FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                    frmMenu.Show();
                }
            }
                
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.FrmAperturaCaja.Dispose();
            FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
            frmMenu.Show();
        }

        private void btnBorrarDerecha_Click(object sender, EventArgs e)
        {
            int contador = IAperturarCajaView.TextBox.Text.Count();
            if (contador > 0) { IAperturarCajaView.TextBox.Text = IAperturarCajaView.TextBox.Text.Substring(0, IAperturarCajaView.TextBox.Text.Count() - 1); }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Clear();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "0";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "9";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "8";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "7";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "6";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "5";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "4";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "3";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "2";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            IAperturarCajaView.TextBox.Text += "1";
        }
    }
}
