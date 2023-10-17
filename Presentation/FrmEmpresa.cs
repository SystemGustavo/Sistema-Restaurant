using ControlesPersonalizados.Controles;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmEmpresa : Form , IEmpresaView
    {
        public string notas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CRadioButton rbSi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CRadioButton rbNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CRadioButton rbnotageneral { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CRadioButton rbnotapedido { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CComboBox cbpaises { get => cbPais; set => cbPais = value; }
        public CComboBox cbmonedas { get => cbMoneda; set => cbMoneda = value; }
        public CComboBox cbImpuesto { get => cbIgv; set => cbIgv=value; }
        public CComboBox cbImpuestoValue { get => cbPorcentaje; set => cbPorcentaje = value; }
        public CPanel panelImpuesto { get => pnImpuesto; set => pnImpuesto=value; }

        public event EventHandler FormLoad;
        public event EventHandler cbPaisSelectedIndexChanged;
        public event EventHandler rbSiCheckedChanged;
        public event EventHandler rbNoCheckedChanged;
        public event EventHandler tsbFolderClick;
        public event EventHandler btnSiguienteClick;

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
        }
    }
}
