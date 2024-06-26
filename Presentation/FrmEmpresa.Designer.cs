﻿
namespace Presentation
{
    partial class FrmEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEmpresa = new ControlesPersonalizados.Controles.CTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNotaGeneral = new ControlesPersonalizados.Controles.CRadioButton();
            this.rbNotaPorPedido = new ControlesPersonalizados.Controles.CRadioButton();
            this.pnImpuesto = new ControlesPersonalizados.Controles.CPanel();
            this.cLabel1 = new ControlesPersonalizados.Controles.CLabel();
            this.cbIgv = new ControlesPersonalizados.Controles.CComboBox();
            this.cbPorcentaje = new ControlesPersonalizados.Controles.CComboBox();
            this.btnAccion = new System.Windows.Forms.Button();
            this.txtRuta = new ControlesPersonalizados.Controles.CTextBox();
            this.lblFBD = new System.Windows.Forms.Label();
            this.rbNoImpuesto = new ControlesPersonalizados.Controles.CRadioButton();
            this.rbSiImpuesto = new ControlesPersonalizados.Controles.CRadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMoneda = new ControlesPersonalizados.Controles.CComboBox();
            this.cbPais = new ControlesPersonalizados.Controles.CComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImagen = new ControlesPersonalizados.Controles.CCircularPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.pnImpuesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmpresa
            // 
            this.txtEmpresa._Customizable = true;
            this.txtEmpresa.BackColor = System.Drawing.Color.White;
            this.txtEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtEmpresa.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtEmpresa.BorderRadius = 7;
            this.txtEmpresa.BorderSize = 5;
            this.txtEmpresa.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtEmpresa.Location = new System.Drawing.Point(359, 96);
            this.txtEmpresa.MultiLine = true;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmpresa.PasswordChar = false;
            this.txtEmpresa.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtEmpresa.PlaceHolderText = null;
            this.txtEmpresa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmpresa.Size = new System.Drawing.Size(505, 44);
            this.txtEmpresa.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.MatteLine;
            this.txtEmpresa.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.label2.Location = new System.Drawing.Point(256, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Empresa :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNotaGeneral);
            this.groupBox1.Controls.Add(this.rbNotaPorPedido);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.groupBox1.Location = new System.Drawing.Point(281, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 73);
            this.groupBox1.TabIndex = 604;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notas en Pedido";
            // 
            // rbNotaGeneral
            // 
            this.rbNotaGeneral.AutoSize = true;
            this.rbNotaGeneral.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.rbNotaGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNotaGeneral.Customizable = true;
            this.rbNotaGeneral.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.rbNotaGeneral.ForeColor = System.Drawing.Color.Black;
            this.rbNotaGeneral.Location = new System.Drawing.Point(27, 31);
            this.rbNotaGeneral.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbNotaGeneral.Name = "rbNotaGeneral";
            this.rbNotaGeneral.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbNotaGeneral.Size = new System.Drawing.Size(158, 30);
            this.rbNotaGeneral.TabIndex = 600;
            this.rbNotaGeneral.TabStop = true;
            this.rbNotaGeneral.Text = "Nota General";
            this.rbNotaGeneral.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(110)))), ((int)(((byte)(134)))));
            this.rbNotaGeneral.UseVisualStyleBackColor = true;
            // 
            // rbNotaPorPedido
            // 
            this.rbNotaPorPedido.AutoSize = true;
            this.rbNotaPorPedido.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.rbNotaPorPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNotaPorPedido.Customizable = true;
            this.rbNotaPorPedido.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.rbNotaPorPedido.ForeColor = System.Drawing.Color.Black;
            this.rbNotaPorPedido.Location = new System.Drawing.Point(222, 31);
            this.rbNotaPorPedido.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbNotaPorPedido.Name = "rbNotaPorPedido";
            this.rbNotaPorPedido.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbNotaPorPedido.Size = new System.Drawing.Size(189, 30);
            this.rbNotaPorPedido.TabIndex = 601;
            this.rbNotaPorPedido.TabStop = true;
            this.rbNotaPorPedido.Text = "Nota por Pedido";
            this.rbNotaPorPedido.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(110)))), ((int)(((byte)(134)))));
            this.rbNotaPorPedido.UseVisualStyleBackColor = true;
            // 
            // pnImpuesto
            // 
            this.pnImpuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.pnImpuesto.BorderRadius = 10;
            this.pnImpuesto.Controls.Add(this.cLabel1);
            this.pnImpuesto.Controls.Add(this.cbIgv);
            this.pnImpuesto.Controls.Add(this.cbPorcentaje);
            this.pnImpuesto.Customizable = true;
            this.pnImpuesto.Location = new System.Drawing.Point(281, 252);
            this.pnImpuesto.Name = "pnImpuesto";
            this.pnImpuesto.Size = new System.Drawing.Size(703, 65);
            this.pnImpuesto.TabIndex = 603;
            // 
            // cLabel1
            // 
            this.cLabel1.AutoSize = true;
            this.cLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cLabel1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9.5F);
            this.cLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.cLabel1.LinkLabel = false;
            this.cLabel1.Location = new System.Drawing.Point(663, 14);
            this.cLabel1.Name = "cLabel1";
            this.cLabel1.Size = new System.Drawing.Size(24, 21);
            this.cLabel1.Style = ControlesPersonalizados.Controles.Diseño.LabelStyle.Normal;
            this.cLabel1.TabIndex = 21;
            this.cLabel1.Text = "%";
            // 
            // cbIgv
            // 
            this.cbIgv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbIgv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbIgv.BackColor = System.Drawing.Color.White;
            this.cbIgv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.cbIgv.BorderRadius = 1;
            this.cbIgv.BorderSize = 2;
            this.cbIgv.Customizable = true;
            this.cbIgv.DataSource = null;
            this.cbIgv.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.cbIgv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbIgv.DropDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.cbIgv.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.cbIgv.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.cbIgv.Location = new System.Drawing.Point(12, 14);
            this.cbIgv.Name = "cbIgv";
            this.cbIgv.Padding = new System.Windows.Forms.Padding(3);
            this.cbIgv.SelectedIndex = -1;
            this.cbIgv.Size = new System.Drawing.Size(441, 32);
            this.cbIgv.Style = ControlesPersonalizados.Controles.Diseño.ControlStyle.Glass;
            this.cbIgv.TabIndex = 19;
            this.cbIgv.Texts = "";
            // 
            // cbPorcentaje
            // 
            this.cbPorcentaje.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbPorcentaje.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbPorcentaje.BackColor = System.Drawing.Color.White;
            this.cbPorcentaje.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.cbPorcentaje.BorderRadius = 1;
            this.cbPorcentaje.BorderSize = 2;
            this.cbPorcentaje.Customizable = true;
            this.cbPorcentaje.DataSource = null;
            this.cbPorcentaje.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.cbPorcentaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbPorcentaje.DropDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.cbPorcentaje.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.cbPorcentaje.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.cbPorcentaje.Location = new System.Drawing.Point(499, 14);
            this.cbPorcentaje.Name = "cbPorcentaje";
            this.cbPorcentaje.Padding = new System.Windows.Forms.Padding(3);
            this.cbPorcentaje.SelectedIndex = -1;
            this.cbPorcentaje.Size = new System.Drawing.Size(158, 32);
            this.cbPorcentaje.Style = ControlesPersonalizados.Controles.Diseño.ControlStyle.Glass;
            this.cbPorcentaje.TabIndex = 20;
            this.cbPorcentaje.Texts = "";
            // 
            // btnAccion
            // 
            this.btnAccion.BackgroundImage = global::Presentation.Resource1.azul;
            this.btnAccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccion.FlatAppearance.BorderSize = 0;
            this.btnAccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccion.ForeColor = System.Drawing.Color.White;
            this.btnAccion.Location = new System.Drawing.Point(494, 518);
            this.btnAccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(134, 67);
            this.btnAccion.TabIndex = 602;
            this.btnAccion.Text = "Siguiente";
            this.btnAccion.UseVisualStyleBackColor = true;
            // 
            // txtRuta
            // 
            this.txtRuta._Customizable = true;
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtRuta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtRuta.BorderRadius = 7;
            this.txtRuta.BorderSize = 5;
            this.txtRuta.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtRuta.Location = new System.Drawing.Point(281, 358);
            this.txtRuta.MultiLine = true;
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtRuta.PasswordChar = false;
            this.txtRuta.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtRuta.PlaceHolderText = null;
            this.txtRuta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRuta.Size = new System.Drawing.Size(542, 44);
            this.txtRuta.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.MatteLine;
            this.txtRuta.TabIndex = 598;
            // 
            // lblFBD
            // 
            this.lblFBD.AutoSize = true;
            this.lblFBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.lblFBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFBD.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 10F);
            this.lblFBD.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblFBD.Location = new System.Drawing.Point(277, 333);
            this.lblFBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFBD.Name = "lblFBD";
            this.lblFBD.Size = new System.Drawing.Size(524, 22);
            this.lblFBD.TabIndex = 597;
            this.lblFBD.Text = "Seleccione una Carpeta donde Guardar Las Copias de Seguridad\r\n";
            // 
            // rbNoImpuesto
            // 
            this.rbNoImpuesto.AutoSize = true;
            this.rbNoImpuesto.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.rbNoImpuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNoImpuesto.Customizable = true;
            this.rbNoImpuesto.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.rbNoImpuesto.ForeColor = System.Drawing.Color.Black;
            this.rbNoImpuesto.Location = new System.Drawing.Point(642, 217);
            this.rbNoImpuesto.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbNoImpuesto.Name = "rbNoImpuesto";
            this.rbNoImpuesto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbNoImpuesto.Size = new System.Drawing.Size(70, 30);
            this.rbNoImpuesto.TabIndex = 18;
            this.rbNoImpuesto.TabStop = true;
            this.rbNoImpuesto.Text = "No";
            this.rbNoImpuesto.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(110)))), ((int)(((byte)(134)))));
            this.rbNoImpuesto.UseVisualStyleBackColor = true;
            // 
            // rbSiImpuesto
            // 
            this.rbSiImpuesto.AutoSize = true;
            this.rbSiImpuesto.Checked = true;
            this.rbSiImpuesto.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.rbSiImpuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSiImpuesto.Customizable = true;
            this.rbSiImpuesto.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.rbSiImpuesto.ForeColor = System.Drawing.Color.Black;
            this.rbSiImpuesto.Location = new System.Drawing.Point(569, 217);
            this.rbSiImpuesto.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbSiImpuesto.Name = "rbSiImpuesto";
            this.rbSiImpuesto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbSiImpuesto.Size = new System.Drawing.Size(59, 30);
            this.rbSiImpuesto.TabIndex = 17;
            this.rbSiImpuesto.TabStop = true;
            this.rbSiImpuesto.Text = "Si";
            this.rbSiImpuesto.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(110)))), ((int)(((byte)(134)))));
            this.rbSiImpuesto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.label5.Location = new System.Drawing.Point(258, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Vender con Impuestos ?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(500, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 46);
            this.label4.TabIndex = 15;
            this.label4.Text = "Empresa";
            // 
            // cbMoneda
            // 
            this.cbMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbMoneda.BackColor = System.Drawing.Color.White;
            this.cbMoneda.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.cbMoneda.BorderRadius = 1;
            this.cbMoneda.BorderSize = 2;
            this.cbMoneda.Customizable = true;
            this.cbMoneda.DataSource = null;
            this.cbMoneda.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbMoneda.DropDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.cbMoneda.Enabled = false;
            this.cbMoneda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.cbMoneda.Location = new System.Drawing.Point(685, 160);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Padding = new System.Windows.Forms.Padding(3);
            this.cbMoneda.SelectedIndex = -1;
            this.cbMoneda.Size = new System.Drawing.Size(179, 32);
            this.cbMoneda.Style = ControlesPersonalizados.Controles.Diseño.ControlStyle.Glass;
            this.cbMoneda.TabIndex = 13;
            this.cbMoneda.Texts = "";
            // 
            // cbPais
            // 
            this.cbPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbPais.BackColor = System.Drawing.Color.White;
            this.cbPais.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.cbPais.BorderRadius = 1;
            this.cbPais.BorderSize = 2;
            this.cbPais.Customizable = true;
            this.cbPais.DataSource = null;
            this.cbPais.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.cbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbPais.DropDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.cbPais.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.cbPais.Location = new System.Drawing.Point(340, 160);
            this.cbPais.Name = "cbPais";
            this.cbPais.Padding = new System.Windows.Forms.Padding(3);
            this.cbPais.SelectedIndex = -1;
            this.cbPais.Size = new System.Drawing.Size(233, 32);
            this.cbPais.Style = ControlesPersonalizados.Controles.Diseño.ControlStyle.Glass;
            this.cbPais.TabIndex = 12;
            this.cbPais.Texts = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(580, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Moneda :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 11F);
            this.label1.Location = new System.Drawing.Point(256, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pais :";
            // 
            // pbImagen
            // 
            this.pbImagen.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pbImagen.BorderColor = System.Drawing.Color.RoyalBlue;
            this.pbImagen.BorderColor2 = System.Drawing.Color.HotPink;
            this.pbImagen.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pbImagen.BorderSize = 2;
            this.pbImagen.Customizable = true;
            this.pbImagen.GradientAngle = 50F;
            this.pbImagen.GradientColor = false;
            this.pbImagen.Image = global::Presentation.Resource1.userProfile;
            this.pbImagen.Location = new System.Drawing.Point(12, 148);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(207, 207);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 9;
            this.pbImagen.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbImagen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pnImpuesto);
            this.panel1.Controls.Add(this.cbMoneda);
            this.panel1.Controls.Add(this.btnAccion);
            this.panel1.Controls.Add(this.cbPais);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEmpresa);
            this.panel1.Controls.Add(this.rbSiImpuesto);
            this.panel1.Controls.Add(this.lblFBD);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbNoImpuesto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 645);
            this.panel1.TabIndex = 605;
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1110, 645);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEmpresa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnImpuesto.ResumeLayout(false);
            this.pnImpuesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesPersonalizados.Controles.CTextBox txtEmpresa;
        private System.Windows.Forms.Label label2;
        private ControlesPersonalizados.Controles.CComboBox cbMoneda;
        private ControlesPersonalizados.Controles.CComboBox cbPais;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ControlesPersonalizados.Controles.CCircularPictureBox pbImagen;
        private System.Windows.Forms.Label label4;
        private ControlesPersonalizados.Controles.CRadioButton rbNoImpuesto;
        private ControlesPersonalizados.Controles.CRadioButton rbSiImpuesto;
        private System.Windows.Forms.Label label5;
        private ControlesPersonalizados.Controles.CComboBox cbPorcentaje;
        private ControlesPersonalizados.Controles.CComboBox cbIgv;
        internal System.Windows.Forms.Label lblFBD;
        private ControlesPersonalizados.Controles.CTextBox txtRuta;
        private ControlesPersonalizados.Controles.CRadioButton rbNotaPorPedido;
        private ControlesPersonalizados.Controles.CRadioButton rbNotaGeneral;
        private System.Windows.Forms.Button btnAccion;
        private ControlesPersonalizados.Controles.CPanel pnImpuesto;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlesPersonalizados.Controles.CLabel cLabel1;
        private System.Windows.Forms.Panel panel1;
    }
}