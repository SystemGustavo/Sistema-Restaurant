using Domain.Models;
using Domain.Repository;
using Presentation.Helpers;
using Presentation.Utils;
using Presentation.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class EmpresaPresenter : ControlsGeneric
    {
        private IEmpresaView IEmpresaView;
        private IEmpresaModel IEmpresaModel;
        

        public EmpresaPresenter(IEmpresaView IEmpresaView,EmpresaModel EmpresaModel)
        {
            this.IEmpresaView = IEmpresaView;
            this.IEmpresaModel = EmpresaModel;

            //Subscribe event handler methods to view events
            this.IEmpresaView.FormLoad += FrmEmpresa_Load;
            this.IEmpresaView.btnAccionClick += btnAccion_Click;
            this.IEmpresaView.cbPaisSelectedIndexChanged += cbPais_SelectedIndexChanged;
            this.IEmpresaView.rbSiCheckedChanged += rbSi__CheckedChanged;
            this.IEmpresaView.rbNoCheckedChanged += rbNo__CheckedChanged;
            this.IEmpresaView.EventClickImagen += pbImagen_Click;
            this.IEmpresaView.EventLabelClick += lblFBD_click;

        }

        private void lblFBD_click(object sender, EventArgs e)
        {
            ObtenerRutaDeCarpeta();
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            ListarCombobox();
            this.IEmpresaView.cbpaises.DisplayMember = "Pais";
            this.IEmpresaView.cbpaises.ValueMember = "Moneda";
            this.IEmpresaView.cbmonedas.Text = string.Empty;
        }

        public void ListarCombobox()
        {
            this.IEmpresaView.cbpaises.DataSource = this.IEmpresaModel.ListPaises();
            this.IEmpresaView.cbImpuesto.DataSource = this.IEmpresaModel.ListImpuestos();
            this.IEmpresaView.cbImpuestoValue.DataSource = this.IEmpresaModel.ListValoresImpuestos();
        }

        private void ObtenerRutaDeCarpeta()
        {
            using (this.IEmpresaView.fbd = new FolderBrowserDialog())
            {
                if (this.IEmpresaView.fbd.ShowDialog() == DialogResult.OK)
                    this.IEmpresaView.Carpeta_para_copias_de_seguridad = this.IEmpresaView.fbd.SelectedPath;
            };
        }

        private void rbNo__CheckedChanged(object sender, EventArgs e)
        {
            IEmpresaView.panelImpuesto.Visible = false;
            IEmpresaView.Impuesto = string.Empty;
            IEmpresaView.cbImpuestoValue.Text = "";
        }

        private void rbSi__CheckedChanged(object sender, EventArgs e)
        {
            IEmpresaView.panelImpuesto.Visible = true;
            IEmpresaView.Impuesto="<< Seleccione Impuesto >>";
            IEmpresaView.cbImpuestoValue.Text = "0";
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.IEmpresaView.cbmonedas.Text = this.IEmpresaView.cbpaises.SelectedValue.ToString();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            var objModeloEmpresa = FillEmpresaModel();
            var objDataValidation = new DataValidation(objModeloEmpresa);
            if (objDataValidation.Result)
            {
                this.IEmpresaModel.Add(objModeloEmpresa);
            }
            else
            {
                MessageBox.Show(objDataValidation.ErrorMessage);
            }
            
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            ImagenClick(IEmpresaView.imagen);
        }

        private EmpresaModel FillEmpresaModel()
        {
            try
            {
                EmpresaModel objEmpresaModel = new EmpresaModel();
                objEmpresaModel.Nombre_Empresa = IEmpresaView.nombreEmpresa;
                objEmpresaModel.Logo = ItemConverter.ImageToBinary(IEmpresaView.imagen.Image);
                VenderConImpuesto();
                objEmpresaModel.Impuesto = IEmpresaView.Impuesto;
                objEmpresaModel.Trabajas_con_impuestos = IEmpresaView.Trabajas_con_impuestos;
                if (IEmpresaView.cbImpuestoValue.Text == "") objEmpresaModel.Porcentaje_impuesto = null;
                else objEmpresaModel.Porcentaje_impuesto = IEmpresaView.Porcentaje_impuesto;
                objEmpresaModel.Moneda = IEmpresaView.Moneda;
                objEmpresaModel.Carpeta_para_copias_de_seguridad = IEmpresaView.Carpeta_para_copias_de_seguridad;
                objEmpresaModel.Ultima_fecha_de_copia_date = IEmpresaView.Ultima_fecha_de_copia_de_date;
                objEmpresaModel.Pais = IEmpresaView.Pais;
                ValidarNotas();
                objEmpresaModel.Tiponotas = IEmpresaView.Tiponotas;
                return objEmpresaModel;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return null;
        }

        private void ValidarNotas()
        {
            if (IEmpresaView.rbnotageneral.Checked)
                IEmpresaView.Tiponotas = "General";
            if (IEmpresaView.rbnotapedido.Checked)
                IEmpresaView.Tiponotas = "Por Pedidos";
        }

        private void VenderConImpuesto()
        {
            if (IEmpresaView.rbSi.Checked)
                IEmpresaView.Trabajas_con_impuestos = "Si";
                
            if (IEmpresaView.rbNo.Checked) {
                IEmpresaView.Trabajas_con_impuestos = "No";
                //IEmpresaView.cbImpuestoValue.Text=null;
                IEmpresaView.Impuesto = string.Empty;
            }
        }

    }
}
