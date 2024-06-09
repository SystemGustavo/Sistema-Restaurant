using ControlesPersonalizados.Controles;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmProductos : Form, IProductosView
    {
        public int Id_Producto1 { get; set; }
        public string Descripcion { get => txtBuscarProducto.Text; set => txtBuscarProducto.Text=value; }
        public byte[] Imagen { get; set; }
        public double Precio_de_compra { get => Convert.ToDouble(txtPrecioDeCompra.Text); set => Convert.ToDouble(value); }
        public double Precio_de_venta { get => Convert.ToDouble(txtPrecioDeVenta.Text); set => Convert.ToDouble(value); }
        public string EstadoProducto { get; set; }
        public string Moneda { get; set; }
        public FlowLayoutPanel PanelProductos { get => fpnlLateralCentral; set => fpnlLateralCentral=value; }
        public int Idline { get; set; }
        public string Grupo { get => txtGrupo.Text; set => txtGrupo.Text = value; }
        public string Por_defecto { get => "No"; set => value.ToString(); }
        public byte[] Icono { get; set; }
        public string Estado_de_icono { get; set; }
        public int Idcolor { get; set; }
        public FlowLayoutPanel PanelGrupo { get => PanelGrupos; set => PanelGrupos=value; }
        public Form FormProductos { get => this; set => this.FormProductos =value; }
        public DialogResult objDialogResult { get; set; }
        public Panel PanelBienvenidaGrupo { get => PanelIniciarGrupo; set => PanelIniciarGrupo=value; }
        public Panel VisorPanelProductos { get => pnlVisorProductos; set => pnlVisorProductos=value; }
        public CLabel ElegirGrupo { get => lblElejirGrupo; set => lblElejirGrupo=value; }
        public string colorhtml { get; set; }
        public FlowLayoutPanel flpGrupoDeColores { get => fpGrupoColores; set => fpGrupoColores = value; }
        //public Button btnColor { get => btnProductoColor; set => btnProductoColor=value; }
        public CTextBox CtxtPrecioDeCompra { get => txtPrecioDeCompra; set => txtPrecioDeCompra=value; }
        public CTextBox CtxtPrecioDeVenta { get => txtPrecioDeVenta; set => txtPrecioDeVenta=value; }
        public TabPage PestañaProductos { get => tbProducto; set => tbProducto=value; }
        public TabPage PestañaCrudProductos { get => tbCrudProducto; set => tbCrudProducto=value; }
        public TabPage PestañaCrudGrupos { get => tbCrudGrupos; set => tbCrudGrupos=value; }
        public TabControl TabControl { get => tbProductos; set => tbProductos = value; }
        public Button AccionBoton { get => btnAccionProducto; set =>btnAccionProducto = value; }
        public CTextBox CtxtDescripcion { get => txtDescripcion; set => txtDescripcion = value; }
        public string EstadoGrupoProducto { get => "Activo"; set=>value.ToString(); }
        public string Estado_Imagen { get; set; }
        public CCircularPictureBox pictureImagen { get => pbImagen; set => pbImagen = value; }
        public FlowLayoutPanel fpColores { get =>flpColores; set => flpColores=value; }
        public CTextBox grupo { get => txtGrupo; set => txtGrupo=value; }
        public string ProductoColorhtml { get; set; }
        public string GrupoProductoColorhtml { get; set; }
        public Button btn_GrupoProducto_Color { get => btnGrupoProductoColor; set => btnGrupoProductoColor=value; }
        public Button btn_Producto_Color { get => btnProductoColor; set => btnProductoColor=value; }
        public CCircularPictureBox pbIcono { get => pbIconoGrupo; set => pbIconoGrupo=value; }
        public string BuscarGrupo { get => txtBuscarPorGrupos.Text; set => txtBuscarPorGrupos.Text=value; }
        public Button AccionButonGrupoProducto { get => btnAccionGrupoProducto; set => btnAccionGrupoProducto=value; }
        public string CodUm { get; set; }
        public string CodigoSunat { get; set; }
        public string Codigo { get; set; }
        public Panel PanelSuperiorAddProducto { get => PanelSuperiorAgregarProducto; set=> PanelSuperiorAgregarProducto = value; }

        public event EventHandler EventOnTextChanged1;
        public event EventHandler EventOnTextChanged2;
        public event EventHandler EventFrmProductosLoad;
        public event KeyPressEventHandler EventKeyPressPrecioDeCompra;
        public event KeyPressEventHandler EventKeyPressPrecioDeVenta;
        public event EventHandler EventAgregarProducto;
        public event EventHandler EventAgregarGrupo;
        public event EventHandler EventBotonCancelarProducto;
        public event EventHandler EventBotonAccionProducto;
        public event EventHandler EventBotonAccionGrupo;
        public event EventHandler EventBotonCancelarGrupo;
        public event EventHandler EventBotonAccionGrupoProducto;
        public event EventHandler EventClickIconoGrupoProducto;
        public event EventHandler EventClickImagenProducto;

        public FrmProductos()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            pbImagen.Click += delegate
            {
                EventClickImagenProducto?.Invoke(this, EventArgs.Empty);
            };

            pbIconoGrupo.Click += delegate
            {
                EventClickIconoGrupoProducto?.Invoke(this, EventArgs.Empty);
            };

            btnCancelarGrupo.Click += delegate
            {
                EventBotonCancelarGrupo?.Invoke(this, EventArgs.Empty);
            };

            btnAccionGrupoProducto.Click += delegate
            {
                EventBotonAccionGrupo?.Invoke(this, EventArgs.Empty);
            };

            btnAccionProducto.Click += delegate
            {
                EventBotonAccionProducto?.Invoke(this, EventArgs.Empty);
            };

            btnAccionGrupoProducto.Click += delegate
            {
                EventBotonAccionGrupoProducto?.Invoke(this, EventArgs.Empty);
            };

            btnCancelarProducto.Click += delegate
            {
                EventBotonCancelarProducto?.Invoke(this,EventArgs.Empty);
            };

            btnAgregarGrupo.Click += delegate
            {
                EventAgregarGrupo?.Invoke(this, EventArgs.Empty);
            };

            btnAgregarProducto.Click += delegate
            {
                EventAgregarProducto?.Invoke(this, EventArgs.Empty);
            };

            txtPrecioDeVenta.KeyPress += (s, e) =>
            {
                EventKeyPressPrecioDeVenta?.Invoke(s, e);
            };

            txtPrecioDeCompra.KeyPress += (s, e) =>
            {
                EventKeyPressPrecioDeCompra?.Invoke(s, e);
            };

            txtBuscarProducto.onTextChanged += delegate
            {
                EventOnTextChanged1?.Invoke(this, EventArgs.Empty);
            };

            txtBuscarPorGrupos.onTextChanged += delegate
            {
                EventOnTextChanged2?.Invoke(this, EventArgs.Empty);
            };

            this.Load += delegate
            {
                EventFrmProductosLoad?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
