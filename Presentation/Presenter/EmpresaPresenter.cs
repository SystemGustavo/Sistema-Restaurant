using Domain.Models;
using Domain.Repository;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class EmpresaPresenter
    {
        private IEmpresaView IEmpresaView;
        private IEmpresaModel IEmpresaModel;

        public EmpresaPresenter(IEmpresaView IEmpresaView, EmpresaModel EmpresaModel)
        {
            this.IEmpresaView = IEmpresaView;
            this.IEmpresaModel = EmpresaModel;

            //Subscribe event handler methods to view events
            this.IEmpresaView.FormLoad += FrmEmpresa_Load;
            this.IEmpresaView.btnSiguienteClick += btnSiguiente_Click;
            this.IEmpresaView.cbPaisSelectedIndexChanged += cbPais_SelectedIndexChanged;
            this.IEmpresaView.rbSiCheckedChanged += rbSi__CheckedChanged;
            this.IEmpresaView.rbNoCheckedChanged += rbNo__CheckedChanged;
            this.IEmpresaView.tsbFolderClick += tsbFolder_Click;
            
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            this.IEmpresaView.cbpaises.DataSource = this.IEmpresaModel.ListPaises();
            this.IEmpresaView.cbImpuesto.DataSource = this.IEmpresaModel.ListImpuestos();
            this.IEmpresaView.cbImpuestoValue.DataSource = this.IEmpresaModel.ListValoresImpuestos();
            this.IEmpresaView.cbpaises.DisplayMember = "Pais";
            this.IEmpresaView.cbpaises.ValueMember = "Moneda";
            this.IEmpresaView.cbmonedas.Text = string.Empty;

        }

        private void tsbFolder_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void rbNo__CheckedChanged(object sender, EventArgs e)
        {
            IEmpresaView.panelImpuesto.Visible = false;
        }

        private void rbSi__CheckedChanged(object sender, EventArgs e)
        {
            IEmpresaView.panelImpuesto.Visible = true;
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.IEmpresaView.cbmonedas.Text = this.IEmpresaView.cbpaises.SelectedValue.ToString();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
