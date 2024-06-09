using ControlesPersonalizados.Controles;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmUsuarios : Form,IUsuariosView
    {
        public int IdUsuario { get; set; }
        public string Nombre { get => txtNombre.Text; set => txtNombre.Text=value; }
        public string Login { get => txtUsuario.Text; set => txtUsuario.Text = value; }
        public string Password { get => txtContraseña.Text; set => txtContraseña.Text=value; }
        public string Correo { get => txtCorreo.Text; set => txtCorreo.Text=value; }
        public string Rol { get=>cbxRol.Text; set=>cbxRol.Text=value; }
        public string Estado { get; set; }
        public byte[] Icon { get; set; }
        public CDataGridView dgvPermisos { get => dgvModulos; set=>dgvModulos=value; }
        public string cbxRoles { get => cbxRol.Text; set => cbxRol.Text=value; }
        public TabPage PestañaListaDeUsuarios { get => UsuariosList; set => UsuariosList = value; }
        public TabPage PestañaDetalleDeUsuarios { get => UsuariosDetails; set => UsuariosDetails = value; }
        public TabControl TabControl { get => tabControl1; set => tabControl1 = value; }
        public CDataGridView DGVUsuarios { get => dgvUsuarios; set => dgvUsuarios=value; }
        public Button AccionBoton { get => btnAccion; set => btnAccion=value; }
        public CCircularPictureBox Imagen { get => pbImagen; set => pbImagen=value; }
        public string buscarUsuario { get => txtBuscarUsuario.Text; set => txtBuscarUsuario.Text = value; }

        public FrmUsuarios()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(PestañaDetalleDeUsuarios);
        }

        public event EventHandler EventAgregarNuevo;
        public event EventHandler EventAccion;
        public event EventHandler EventEditar;
        public event EventHandler EventEliminar;
        public event EventHandler EventVerDetalles;
        public event EventHandler EventSelectedIndexChanged;
        public event EventHandler EventCancelar;
        public event EventHandler EventClickImagen;
        public event EventHandler EventOnTextChanged;
        public event KeyPressEventHandler EventKeyPressContraseña;

        private void AssociateAndRaiseViewEvents()
        {
            txtContraseña.KeyPress += (s,e) => 
            {
                EventKeyPressContraseña?.Invoke(s, e);
            };

            txtBuscarUsuario.onTextChanged += delegate
            {
                EventOnTextChanged?.Invoke(this, EventArgs.Empty);
            };

            btnCancelar.Click += delegate
            {
                EventCancelar?.Invoke(this, EventArgs.Empty);
            };

            btnAccion.Click += delegate
            {
                EventAccion?.Invoke(this, EventArgs.Empty);
            };

            btnAgregarNuevo.Click += delegate
            {
                EventAgregarNuevo?.Invoke(this, EventArgs.Empty);
            };

            btnEditar.Click += delegate
            {
                EventEditar?.Invoke(this, EventArgs.Empty);
            };

            btnEliminar.Click += delegate
            {
                EventEliminar?.Invoke(this, EventArgs.Empty);
            };

            btnVerDetalles.Click += delegate
            {
                EventVerDetalles?.Invoke(this, EventArgs.Empty);
            };

            cbxRol.OnSelectedIndexChanged += delegate
            {
                EventSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            };

            pbImagen.Click += delegate
            {
                EventClickImagen?.Invoke(this, EventArgs.Empty);
            };

        }

        public void SetUsuariosListBindingSource(BindingSource usuariosList)
        {
            dgvUsuarios.DataSource = usuariosList;
        }

        public void SetModulosListBindingSource(BindingSource modulosList)
        {
            dgvModulos.DataSource = modulosList;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
