
namespace Presentation
{
    partial class FrmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.UsuariosList = new System.Windows.Forms.TabPage();
            this.txtBuscarUsuario = new ControlesPersonalizados.Controles.CTextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregarNuevo = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.dgvUsuarios = new ControlesPersonalizados.Controles.CDataGridView();
            this.UsuariosDetails = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.pbImagen = new ControlesPersonalizados.Controles.CCircularPictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccion = new System.Windows.Forms.Button();
            this.cbxRol = new ControlesPersonalizados.Controles.CComboBox();
            this.dgvModulos = new ControlesPersonalizados.Controles.CDataGridView();
            this.Marcar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCorreo = new ControlesPersonalizados.Controles.CTextBox();
            this.txtContraseña = new ControlesPersonalizados.Controles.CTextBox();
            this.txtUsuario = new ControlesPersonalizados.Controles.CTextBox();
            this.txtNombre = new ControlesPersonalizados.Controles.CTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.UsuariosList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.UsuariosDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.UsuariosList);
            this.tabControl1.Controls.Add(this.UsuariosDetails);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1319, 750);
            this.tabControl1.TabIndex = 0;
            // 
            // UsuariosList
            // 
            this.UsuariosList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.UsuariosList.Controls.Add(this.txtBuscarUsuario);
            this.UsuariosList.Controls.Add(this.btnEliminar);
            this.UsuariosList.Controls.Add(this.btnEditar);
            this.UsuariosList.Controls.Add(this.btnAgregarNuevo);
            this.UsuariosList.Controls.Add(this.btnVerDetalles);
            this.UsuariosList.Controls.Add(this.dgvUsuarios);
            this.UsuariosList.Location = new System.Drawing.Point(4, 25);
            this.UsuariosList.Name = "UsuariosList";
            this.UsuariosList.Padding = new System.Windows.Forms.Padding(3);
            this.UsuariosList.Size = new System.Drawing.Size(1311, 721);
            this.UsuariosList.TabIndex = 0;
            this.UsuariosList.Text = "ListaDeUsuarios";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario._Customizable = true;
            this.txtBuscarUsuario.BackColor = System.Drawing.Color.White;
            this.txtBuscarUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtBuscarUsuario.BorderFocusColor = System.Drawing.Color.Gray;
            this.txtBuscarUsuario.BorderRadius = 7;
            this.txtBuscarUsuario.BorderSize = 5;
            this.txtBuscarUsuario.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtBuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtBuscarUsuario.Location = new System.Drawing.Point(17, 44);
            this.txtBuscarUsuario.MultiLine = true;
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscarUsuario.PasswordChar = false;
            this.txtBuscarUsuario.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtBuscarUsuario.PlaceHolderText = "Buscar por Usuario yo Nombre";
            this.txtBuscarUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscarUsuario.Size = new System.Drawing.Size(415, 44);
            this.txtBuscarUsuario.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.FlaringLine;
            this.txtBuscarUsuario.TabIndex = 5;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Presentation.Resource1.Rojo;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(1168, 647);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(134, 67);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentation.Resource1.azul;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(1026, 647);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(134, 67);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarNuevo
            // 
            this.btnAgregarNuevo.BackgroundImage = global::Presentation.Resource1.verde;
            this.btnAgregarNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarNuevo.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNuevo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarNuevo.Location = new System.Drawing.Point(859, 647);
            this.btnAgregarNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarNuevo.Name = "btnAgregarNuevo";
            this.btnAgregarNuevo.Size = new System.Drawing.Size(159, 67);
            this.btnAgregarNuevo.TabIndex = 2;
            this.btnAgregarNuevo.Text = "Agregar Nuevo";
            this.btnAgregarNuevo.UseVisualStyleBackColor = true;
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.BackgroundImage = global::Presentation.Resource1.naranja;
            this.btnVerDetalles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerDetalles.FlatAppearance.BorderSize = 0;
            this.btnVerDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVerDetalles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalles.Location = new System.Drawing.Point(697, 647);
            this.btnVerDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(154, 67);
            this.btnVerDetalles.TabIndex = 1;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AlternatingRowsColor = System.Drawing.Color.Empty;
            this.dgvUsuarios.AlternatingRowsColorApply = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dgvUsuarios.BorderRadius = 13;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.dgvUsuarios.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.ColumnHeaderHeight = 40;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.ColumnHeadersHeight = 40;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.ColumnHeaderTextColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.Customizable = false;
            this.dgvUsuarios.DgvBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvUsuarios.Location = new System.Drawing.Point(17, 105);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvUsuarios.RowHeaderColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 30;
            this.dgvUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsuarios.RowHeight = 40;
            this.dgvUsuarios.RowsColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuarios.RowsTextColor = System.Drawing.Color.Gray;
            this.dgvUsuarios.RowTemplate.Height = 40;
            this.dgvUsuarios.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.SelectionTextColor = System.Drawing.Color.Gray;
            this.dgvUsuarios.Size = new System.Drawing.Size(1285, 523);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // UsuariosDetails
            // 
            this.UsuariosDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.UsuariosDetails.Controls.Add(this.label7);
            this.UsuariosDetails.Controls.Add(this.Label12);
            this.UsuariosDetails.Controls.Add(this.pbImagen);
            this.UsuariosDetails.Controls.Add(this.btnCancelar);
            this.UsuariosDetails.Controls.Add(this.label1);
            this.UsuariosDetails.Controls.Add(this.btnAccion);
            this.UsuariosDetails.Controls.Add(this.cbxRol);
            this.UsuariosDetails.Controls.Add(this.dgvModulos);
            this.UsuariosDetails.Controls.Add(this.txtCorreo);
            this.UsuariosDetails.Controls.Add(this.txtContraseña);
            this.UsuariosDetails.Controls.Add(this.txtUsuario);
            this.UsuariosDetails.Controls.Add(this.txtNombre);
            this.UsuariosDetails.Controls.Add(this.label6);
            this.UsuariosDetails.Controls.Add(this.label5);
            this.UsuariosDetails.Controls.Add(this.label3);
            this.UsuariosDetails.Controls.Add(this.label4);
            this.UsuariosDetails.Controls.Add(this.label2);
            this.UsuariosDetails.Location = new System.Drawing.Point(4, 25);
            this.UsuariosDetails.Name = "UsuariosDetails";
            this.UsuariosDetails.Padding = new System.Windows.Forms.Padding(3);
            this.UsuariosDetails.Size = new System.Drawing.Size(1311, 721);
            this.UsuariosDetails.TabIndex = 1;
            this.UsuariosDetails.Text = "DetalleDeUsuarios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(401, 413);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 38);
            this.label7.TabIndex = 614;
            this.label7.Text = "Se permite hasta \r\n6 numeros";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.Label12.Location = new System.Drawing.Point(558, 25);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(383, 22);
            this.Label12.TabIndex = 613;
            this.Label12.Text = "(marca los modulos a los que se tendra acceso)";
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
            this.pbImagen.Location = new System.Drawing.Point(168, 88);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(167, 167);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 16;
            this.pbImagen.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Presentation.Resource1.naranja;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(289, 627);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 67);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 46);
            this.label1.TabIndex = 14;
            this.label1.Text = "Usuarios";
            // 
            // btnAccion
            // 
            this.btnAccion.BackgroundImage = global::Presentation.Resource1.rosa;
            this.btnAccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccion.FlatAppearance.BorderSize = 0;
            this.btnAccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccion.ForeColor = System.Drawing.Color.White;
            this.btnAccion.Location = new System.Drawing.Point(118, 628);
            this.btnAccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(142, 67);
            this.btnAccion.TabIndex = 13;
            this.btnAccion.Text = "Acción";
            this.btnAccion.UseVisualStyleBackColor = true;
            // 
            // cbxRol
            // 
            this.cbxRol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.cbxRol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.cbxRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cbxRol.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.cbxRol.BorderRadius = 0;
            this.cbxRol.BorderSize = 2;
            this.cbxRol.Customizable = true;
            this.cbxRol.DataSource = null;
            this.cbxRol.DropDownBackColor = System.Drawing.Color.White;
            this.cbxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbxRol.DropDownTextColor = System.Drawing.Color.Black;
            this.cbxRol.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.cbxRol.Items.AddRange(new object[] {
            "Mozo",
            "Cajero",
            "Administrador"});
            this.cbxRol.Location = new System.Drawing.Point(241, 556);
            this.cbxRol.Name = "cbxRol";
            this.cbxRol.Padding = new System.Windows.Forms.Padding(3);
            this.cbxRol.SelectedIndex = -1;
            this.cbxRol.Size = new System.Drawing.Size(240, 45);
            this.cbxRol.Style = ControlesPersonalizados.Controles.Diseño.ControlStyle.Glass;
            this.cbxRol.TabIndex = 12;
            this.cbxRol.Texts = "";
            // 
            // dgvModulos
            // 
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToDeleteRows = false;
            this.dgvModulos.AllowUserToResizeRows = false;
            this.dgvModulos.AlternatingRowsColor = System.Drawing.Color.Empty;
            this.dgvModulos.AlternatingRowsColorApply = false;
            this.dgvModulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModulos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dgvModulos.BorderRadius = 13;
            this.dgvModulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvModulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvModulos.ColumnHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.dgvModulos.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvModulos.ColumnHeaderHeight = 40;
            this.dgvModulos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvModulos.ColumnHeadersHeight = 40;
            this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvModulos.ColumnHeaderTextColor = System.Drawing.Color.White;
            this.dgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Marcar});
            this.dgvModulos.ColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModulos.Customizable = false;
            this.dgvModulos.DgvBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dgvModulos.EnableHeadersVisualStyles = false;
            this.dgvModulos.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvModulos.Location = new System.Drawing.Point(562, 50);
            this.dgvModulos.Name = "dgvModulos";
            this.dgvModulos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvModulos.RowHeaderColor = System.Drawing.Color.WhiteSmoke;
            this.dgvModulos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvModulos.RowHeadersVisible = false;
            this.dgvModulos.RowHeadersWidth = 30;
            this.dgvModulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvModulos.RowHeight = 40;
            this.dgvModulos.RowsColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Gray;
            this.dgvModulos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvModulos.RowsTextColor = System.Drawing.Color.Gray;
            this.dgvModulos.RowTemplate.Height = 40;
            this.dgvModulos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.SelectionTextColor = System.Drawing.Color.Gray;
            this.dgvModulos.Size = new System.Drawing.Size(741, 646);
            this.dgvModulos.TabIndex = 11;
            // 
            // Marcar
            // 
            this.Marcar.HeaderText = "Marcar";
            this.Marcar.MinimumWidth = 6;
            this.Marcar.Name = "Marcar";
            // 
            // txtCorreo
            // 
            this.txtCorreo._Customizable = true;
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtCorreo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtCorreo.BorderRadius = 7;
            this.txtCorreo.BorderSize = 5;
            this.txtCorreo.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtCorreo.Location = new System.Drawing.Point(241, 480);
            this.txtCorreo.MultiLine = true;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCorreo.PasswordChar = false;
            this.txtCorreo.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtCorreo.PlaceHolderText = null;
            this.txtCorreo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCorreo.Size = new System.Drawing.Size(240, 44);
            this.txtCorreo.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.FlaringLine;
            this.txtCorreo.TabIndex = 9;
            // 
            // txtContraseña
            // 
            this.txtContraseña._Customizable = true;
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtContraseña.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtContraseña.BorderRadius = 7;
            this.txtContraseña.BorderSize = 5;
            this.txtContraseña.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtContraseña.Location = new System.Drawing.Point(242, 407);
            this.txtContraseña.MaxLength = 6;
            this.txtContraseña.MultiLine = true;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtContraseña.PasswordChar = false;
            this.txtContraseña.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtContraseña.PlaceHolderText = null;
            this.txtContraseña.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContraseña.Size = new System.Drawing.Size(152, 44);
            this.txtContraseña.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.FlaringLine;
            this.txtContraseña.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario._Customizable = true;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtUsuario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtUsuario.BorderRadius = 7;
            this.txtUsuario.BorderSize = 5;
            this.txtUsuario.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtUsuario.Location = new System.Drawing.Point(241, 341);
            this.txtUsuario.MultiLine = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtUsuario.PlaceHolderText = null;
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.Size = new System.Drawing.Size(240, 44);
            this.txtUsuario.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.FlaringLine;
            this.txtUsuario.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre._Customizable = true;
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.txtNombre.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(120)))), ((int)(((byte)(218)))));
            this.txtNombre.BorderRadius = 7;
            this.txtNombre.BorderSize = 5;
            this.txtNombre.Font = new System.Drawing.Font("Verdana", 9.5F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(129)))), ((int)(((byte)(132)))));
            this.txtNombre.Location = new System.Drawing.Point(241, 277);
            this.txtNombre.MultiLine = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombre.PasswordChar = false;
            this.txtNombre.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtNombre.PlaceHolderText = null;
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.Size = new System.Drawing.Size(240, 44);
            this.txtNombre.Style = ControlesPersonalizados.Controles.Diseño.TextBoxStyle.MatteLine;
            this.txtNombre.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(145, 577);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 499);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Correo electronico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 352);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 422);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre:";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1319, 750);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.tabControl1.ResumeLayout(false);
            this.UsuariosList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.UsuariosDetails.ResumeLayout(false);
            this.UsuariosDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage UsuariosList;
        private System.Windows.Forms.TabPage UsuariosDetails;
        private ControlesPersonalizados.Controles.CDataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregarNuevo;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private ControlesPersonalizados.Controles.CTextBox txtCorreo;
        private ControlesPersonalizados.Controles.CTextBox txtContraseña;
        private ControlesPersonalizados.Controles.CTextBox txtUsuario;
        private ControlesPersonalizados.Controles.CTextBox txtNombre;
        private ControlesPersonalizados.Controles.CTextBox txtBuscarUsuario;
        private ControlesPersonalizados.Controles.CDataGridView dgvModulos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Marcar;
        private ControlesPersonalizados.Controles.CComboBox cbxRol;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private ControlesPersonalizados.Controles.CCircularPictureBox pbImagen;
        internal System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label label7;
    }
}