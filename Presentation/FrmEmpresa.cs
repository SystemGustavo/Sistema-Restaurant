using ControlesPersonalizados.Controles;
using Domain.Models;
using Domain.Repository;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmEmpresa : Form , IEmpresaView
    {
        public string nombreEmpresa { get => txtEmpresa.Text; set => txtEmpresa.Text=value; }
        public byte[] Logo { get; set; }
        public string Impuesto { get=>cbImpuesto.Text; set=> cbImpuesto.Text=value; }
        public double? Porcentaje_impuesto { get=>Convert.ToDouble(cbImpuestoValue.Text); set=>Convert.ToDouble(value); }
        public string Moneda { get => cbMoneda.Text; set => cbMoneda.Text=value; }
        public string Trabajas_con_impuestos { get; set; }
        public string Carpeta_para_copias_de_seguridad { get => txtRuta.Text; set=> txtRuta.Text=value; }
        public DateTime Ultima_fecha_de_copia_de_date { get => DateTime.Now; set => Convert.ToDateTime(value); }
        public string Pais { get => cbpaises.Text; set => cbpaises.Text=value; }
        public string Tiponotas { get; set; }
        public CRadioButton rbSi { get => rbSiImpuesto; set => rbSiImpuesto = value; }
        public CRadioButton rbNo { get => rbNoImpuesto; set => rbNoImpuesto = value; }
        public CRadioButton rbnotageneral { get => rbNotaGeneral; set => rbNotaGeneral = value; }
        public CRadioButton rbnotapedido { get => rbNotaPorPedido; set => rbNotaPorPedido = value; }
        public CComboBox cbpaises { get => cbPais; set => cbPais = value; }
        public CComboBox cbmonedas { get => cbMoneda; set => cbMoneda = value; }
        public CComboBox cbImpuesto { get => cbIgv; set => cbIgv=value; }
        public CComboBox cbImpuestoValue { get => cbPorcentaje; set => cbPorcentaje = value; }
        public CPanel panelImpuesto { get => pnImpuesto; set => pnImpuesto=value; }
        public CCircularPictureBox imagen { get => pbImagen; set => pbImagen=value; }
        public FolderBrowserDialog fbd { get; set; }
        

        public event EventHandler FormLoad;
        public event EventHandler cbPaisSelectedIndexChanged;
        public event EventHandler rbSiCheckedChanged;
        public event EventHandler rbNoCheckedChanged;
        public event EventHandler btnAccionClick;
        public event EventHandler EventClickImagen;
        public event EventHandler EventLabelClick;

        public FrmEmpresa()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate
            {
                FormLoad?.Invoke(this, EventArgs.Empty);
            };

            lblFBD.Click += delegate
            {
                EventLabelClick?.Invoke(this, EventArgs.Empty);
            };

            cbPais.OnSelectedIndexChanged += delegate
            {
                cbPaisSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            };

            rbSiImpuesto.CheckedChanged += delegate
            {
                rbSiCheckedChanged?.Invoke(this, EventArgs.Empty);
            };

            rbNoImpuesto.CheckedChanged += delegate
            {
                rbNoCheckedChanged?.Invoke(this, EventArgs.Empty);
            };

            btnAccion.Click += delegate
            {
                btnAccionClick?.Invoke(this, EventArgs.Empty);
            };

            pbImagen.Click += delegate
            {
                EventClickImagen?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
