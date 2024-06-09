using Common;
using Common.Bases;
using ControlesPersonalizados.Controles;
using Domain.Contratos;
using Domain.Models;
using Domain.Repositories;
using Presentation.Helpers;
using Presentation.Utils;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Presentation.Presenter
{
    public class ProductosPresenter : ItemConverter
    {
        private readonly IProductosView IProductosView;
        private readonly IProductosModel IProductosModel;
        private readonly IGrupoDeProductosModel IGrupoProductosModel;
        private readonly IColoresModel IColoresModel;

        private ProductosModel objProductoModel = new ProductosModel();
        private GrupoProductosModel objGrupoProductoModel = new GrupoProductosModel();
        private List<ProductosModel> ListProductoModel { get; set; }
        private TransactionAction transaction { get; set; }
        private ColorsAction color { get; set; }
        private string FondoColorImage { get; set; } = "Sin Fondo";
        private string Accion {get;set;}
        public ProductosPresenter(IProductosView _IProductosView,
                                  ProductosModel _ProductosModel,
                                  GrupoProductosModel _GrupoDeProductosModel,
                                  ColoresModel _ColoresModel)
        {
            IProductosView = _IProductosView;
            IProductosModel = _ProductosModel;
            IGrupoProductosModel = _GrupoDeProductosModel;
            IColoresModel = _ColoresModel;

            IProductosView.EventOnTextChanged1 += txtBuscarProducto_OnTextChanged;
            IProductosView.EventOnTextChanged2 += txtBuscarPorGrupos_OnTextChanged;
            IProductosView.EventFrmProductosLoad += FrmProductos_Load;
            IProductosView.EventKeyPressPrecioDeCompra += txtPrecioDeCompra_KeyPress;
            IProductosView.EventKeyPressPrecioDeVenta += txtPrecioDeVenta_KeyPress;
            IProductosView.EventAgregarProducto += btnAgregarProducto_Click;
            IProductosView.EventBotonCancelarProducto += btnCancelarProducto_Click;
            IProductosView.EventBotonAccionProducto += btnAccionProducto_Click;
            IProductosView.EventBotonAccionGrupoProducto += btnAccionGrupoProducto;
            IProductosView.EventAgregarGrupo += btnAgregarGrupo_Click;
            IProductosView.EventBotonCancelarGrupo += btnCancelarGrupo_Click;
            IProductosView.EventClickIconoGrupoProducto += pbIconoGrupoProducto_Click;
            IProductosView.EventClickImagenProducto += pbImagenProducto_Click;
        }

        private void pbImagenProducto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Images(.jpg,.jpeg,.png,.webp)|*.png;*.jpeg;*.jpg;*.webp";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    IProductosView.pictureImagen.Image = new Bitmap(openFile.FileName);
                    IProductosView.Imagen = ItemConverter.ImageToBinary(IProductosView.pictureImagen.Image);
                    IProductosView.Estado_Imagen = "Lleno";
                }
            }
        }
        private void pbIconoGrupoProducto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Images(.jpg,.jpeg,.png,.webp)|*.png;*.jpeg;*.jpg;*.webp";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    IProductosView.pbIcono.Image = new Bitmap(openFile.FileName);
                    IProductosView.Icono = ItemConverter.ImageToBinary(IProductosView.pbIcono.Image);
                    IProductosView.Estado_de_icono = "Lleno";
                }
            }
        }
        private void btnAccionGrupoProducto(object sender, EventArgs e)
        {
            try { 
                objGrupoProductoModel = FillGrupoProductoModel();
                var objDataValidation = new DataValidation(objGrupoProductoModel);
                if (objDataValidation.Result)
                {
                    switch (transaction)
                    {
                        case TransactionAction.Add:
                            IGrupoProductosModel.Add(objGrupoProductoModel);
                            MessageBox.Show("GrupoProducto Registrado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DibujarGrupos();
                            CambiarAPestañaProductos();
                            LimpiarObjetosGrupoProductos();
                            break;
                        case TransactionAction.Edit:
                            IGrupoProductosModel.Edit(objGrupoProductoModel);
                            MessageBox.Show("GrupoProducto Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DibujarGrupos();
                            CambiarAPestañaProductos();
                            LimpiarObjetosGrupoProductos();
                            break;
                        case TransactionAction.Remove:
                            IGrupoProductosModel.Delete(IProductosView.Idline);
                            MessageBox.Show("GrupoProducto Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DibujarGrupos();
                            CambiarAPestañaProductos();
                            HabilitarPanelBienvenida();
                            IProductosView.ElegirGrupo.Text = "Elija un Grupo\n para Iniciar";
                            CentrarLabelEnPanel(IProductosView.ElegirGrupo);
                            LimpiarObjetosGrupoProductos();
                            break;
                        case TransactionAction.Restore:
                            var result = IGrupoProductosModel.RestaurarGrupoDeProductos(IProductosView.Idline);
                            if (result)
                                DibujarGrupos();
                                MessageBox.Show("GrupoProducto Restaurado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarAPestañaProductos();
                                HabilitarPanelBienvenida();
                                IProductosView.ElegirGrupo.Text = "Elija un Grupo\n para Iniciar";
                                CentrarLabelEnPanel(IProductosView.ElegirGrupo);
                                LimpiarObjetosGrupoProductos();
                            break;
                    }
                } 
            }
            catch (Exception ex)
            {
                var message = ExceptionManager.GetMessage(ex);
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAccionProducto_Click(object sender, EventArgs e)
        {
            try
            {
            objProductoModel = FillProductosModel();
            var objDataValidation = new DataValidation(objProductoModel);
                if (objDataValidation.Result)
                {
                    switch (transaction)
                    {
                        case TransactionAction.Add:
                            IProductosModel.Add(objProductoModel);
                            MessageBox.Show("Producto Registrado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarAPestañaProductos();
                            DibujarProductos();
                            LimpiarObjetosProductos();
                            break;
                        case TransactionAction.Edit:
                            IProductosModel.Edit(objProductoModel);
                            MessageBox.Show("Producto Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DibujarProductos();
                            CambiarAPestañaProductos();
                            LimpiarObjetosProductos();
                            break;
                        case TransactionAction.Remove:
                            IProductosModel.Delete(IProductosView.Id_Producto1);
                            MessageBox.Show("Producto Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DibujarProductos();
                            CambiarAPestañaProductos();
                            LimpiarObjetosProductos();
                            break;
                        case TransactionAction.Restore:
                            var result = IProductosModel.RestaurarProductos(IProductosView.Id_Producto1);
                            if (result)
                                DibujarProductos();
                            MessageBox.Show("Producto Restaurado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarAPestañaProductos();
                            LimpiarObjetosProductos();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ExceptionManager.GetMessage(ex);//Obtener mensaje de excepción.
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);//Mostrar mensaje.
            }
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudProductos);
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudGrupos);
            HabilitarPanelBienvenida();
            CentrarLabelEnPanel(IProductosView.ElegirGrupo);
            DibujarGrupos();
            MostrarProductosColores();
            MostrarGrupoProductosColores();
        }
        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            CambiarAPestañaProductos();
        }
        private void btnCancelarGrupo_Click(object sender, EventArgs e)
        {
            CambiarAPestañaProductos();
        }
        private void CambiarAPestañaProductos()
        {
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudProductos);
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudGrupos);
            IProductosView.TabControl.TabPages.Add(IProductosView.PestañaProductos);
        }
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            transaction = TransactionAction.Add;
            Accion = "Nuevo Grupo Producto";
            color = ColorsAction.Verde;
            CambiarDePestañaACrudGrupos(Accion);
            CambiarColorBotonAccionGrupoProducto();

        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            transaction = TransactionAction.Add;
            Accion = "Nuevo Producto";
            color = ColorsAction.Verde;
            CambiarDePestañaACrudProductos(Accion);
            CambiarColorBotonAccionProducto();
        }
        private void CambiarDePestañaACrudProductos(string accion)
        {
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaProductos);
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudGrupos);
            IProductosView.TabControl.TabPages.Add(IProductosView.PestañaCrudProductos);
            IProductosView.PestañaCrudProductos.Text = accion;
        }
        private void CambiarDePestañaACrudGrupos(string accion)
        {
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaCrudProductos);
            IProductosView.TabControl.TabPages.Remove(IProductosView.PestañaProductos);
            IProductosView.TabControl.TabPages.Add(IProductosView.PestañaCrudGrupos);
            IProductosView.PestañaCrudGrupos.Text = accion;
        }
        private void txtPrecioDeVenta_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == '.' && (~IProductosView.CtxtPrecioDeVenta.Text.IndexOf(".")) != 0)
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
        private void txtPrecioDeCompra_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == '.' && (~IProductosView.CtxtPrecioDeCompra.Text.IndexOf(".")) != 0)
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
        public void HabilitarPanelVisorProductos()
        {
            IProductosView.PanelBienvenidaGrupo.Visible = false;
            IProductosView.VisorPanelProductos.Visible = true;
            IProductosView.PanelProductos.Dock = DockStyle.Bottom;
        }
        public void HabilitarPanelBienvenida()
        {
            IProductosView.VisorPanelProductos.Visible = false;
            IProductosView.PanelBienvenidaGrupo.Dock = DockStyle.Fill;
            IProductosView.PanelBienvenidaGrupo.Visible = true;
        }
        public void HabilitarPanelProductos()
        {
            IProductosView.PanelBienvenidaGrupo.Visible = false;
            IProductosView.VisorPanelProductos.Visible = true;
        }
        public void CentrarLabelEnPanel(CLabel label)
        {
            IProductosView.ElegirGrupo.Font = new Font("Microsoft Sans Serif", 32);
            int x = (IProductosView.PanelBienvenidaGrupo.Width - IProductosView.ElegirGrupo.Width) / 2;
            int y = (IProductosView.PanelBienvenidaGrupo.Height - IProductosView.ElegirGrupo.Height) / 2;
            IProductosView.ElegirGrupo.Location = new Point(x,y);
            IProductosView.PanelBienvenidaGrupo.Controls.Add(label);
        }
        private void txtBuscarPorGrupos_OnTextChanged(object sender, EventArgs e)
        {
            DibujarGrupos();
        }
        private void txtBuscarProducto_OnTextChanged(object sender, EventArgs e)
        {
            DibujarProductos();
        }
        public void DibujarProductos()
        {
            IProductosView.PanelProductos.Controls.Clear();
            ListProductoModel = IProductosModel.MostrarProductosPorGrupos(IProductosView.Idline, IProductosView.Descripcion);
            if (ListProductoModel != null)
            {
                foreach (var item in ListProductoModel)
                {
                    CLabel lblprecio = new CLabel();
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox pbImgGrupoProducto = new PictureBox();
                    CImageColorOverlay ImgColorOverlayProducto = new CImageColorOverlay();
                    b.Text = item.Descripcion;
                    b.Name = item.Id_Producto1.ToString();
                    b.Size = new Size(119, 25);
                    b.Font = new Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.FromArgb(0, 103, 192);
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    lblprecio.Text = item.Moneda.ToString() + " " + item.Precio_de_venta.ToString();
                    lblprecio.Name = item.Id_Producto1.ToString();
                    lblprecio.Size = new Size(119, 25);
                    lblprecio.Font = new Font("Microsoft Sans Serif", 13);
                    lblprecio.BackColor = Color.FromArgb(0, 103, 192);
                    lblprecio.ForeColor = Color.White;
                    lblprecio.Dock = DockStyle.Bottom;
                    lblprecio.TextAlign = ContentAlignment.MiddleCenter;
                    lblprecio.Cursor = Cursors.Hand;

                    p1.Size = new Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    ImgColorOverlayProducto.Customizable = true;
                    if (item.Estado == "Eliminado" && item.Estado_imagen == "Lleno" && item.Imagen != null)
                    {
                        ImgColorOverlayProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayProducto.Size = new Size(140, 76);
                        ImgColorOverlayProducto.Dock = DockStyle.Top;
                        ImgColorOverlayProducto.Image = BinaryToImage(item.Imagen);
                        ImgColorOverlayProducto.OverlayColor = Color.Red;
                        ImgColorOverlayProducto.Opacity = 20;
                        lblprecio.BackColor = Color.Red;
                        p1.BackColor = Color.Red;
                        p2.BackColor = Color.Red;
                        b.Font = new Font("Microsoft Sans Serif", 13,FontStyle.Strikeout);
                        lblprecio.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    }
                    if (item.Estado == "Eliminado" && item.Estado_imagen == "Vacio" && item.Imagen == null)
                    {
                        p1.BackColor = Color.Red;
                        p2.BackColor = Color.Red;
                        ImgColorOverlayProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayProducto.Size = new Size(140, 76);
                        ImgColorOverlayProducto.Dock = DockStyle.Top;
                        ImgColorOverlayProducto.Image = null;
                        ImgColorOverlayProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayProducto.OverlayColor = Color.Red;
                        ImgColorOverlayProducto.Opacity = 50;
                        lblprecio.BackColor = Color.Red;
                        b.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Strikeout);
                        lblprecio.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    }
                    if (item.Estado == "Activo" && item.Estado_imagen == "Lleno" && item.Imagen != null)
                    {
                        ImgColorOverlayProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayProducto.Size = new Size(140, 76);
                        ImgColorOverlayProducto.Dock = DockStyle.Top;
                        ImgColorOverlayProducto.Image = BinaryToImage(item.Imagen);
                        ImgColorOverlayProducto.Opacity = 0;
                        p1.BackColor = Color.FromArgb(0, 103, 192);
                        p2.BackColor = Color.FromArgb(0, 103, 192);
                        lblprecio.BackColor = Color.FromArgb(0, 103, 192);
                    }
                    if (item.Estado == "Activo" && item.Estado_imagen == "Vacio" && item.Imagen == null)
                    {
                        ImgColorOverlayProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayProducto.BackgroundImage = null;
                        ImgColorOverlayProducto.Opacity = 0;
                        ImgColorOverlayProducto.Size = new Size(140, 76);
                        ImgColorOverlayProducto.Dock = DockStyle.Top;
                        //p1.BackColor = Color.FromArgb(0, 103, 192);
                        p2.BackColor = Color.FromArgb(0, 103, 192);
                        lblprecio.BackColor = Color.FromArgb(0, 103, 192);
                    }
                    p2.Size = new Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BorderStyle = BorderStyle.None;
                    MenuStrip Menustrip = new MenuStrip();
                    Menustrip.BackColor = Color.Transparent;
                    Menustrip.AutoSize = false;
                    Menustrip.Size = new Size(28, 24);
                    Menustrip.Dock = DockStyle.Right;
                    Menustrip.Name = item.Id_Producto1.ToString();
                    ToolStripMenuItem tsPrincipal = new ToolStripMenuItem();
                    ToolStripMenuItem tsEditar = new ToolStripMenuItem();
                    ToolStripMenuItem tsEliminar = new ToolStripMenuItem();
                    ToolStripMenuItem tsRestaurar = new ToolStripMenuItem();
                    tsPrincipal.Image = Resource1.menuCajas_claro;
                    tsPrincipal.BackColor = Color.Transparent;
                    tsEditar.Text = "Editar";
                    tsEditar.Name = item.Descripcion.ToString();
                    tsEditar.Tag = item.Id_Producto1.ToString();

                    tsEliminar.Text = "Eliminar";
                    tsEliminar.Tag = item.Id_Producto1.ToString();

                    tsRestaurar.Text = "Restaurar";
                    tsRestaurar.Tag = item.Id_Producto1.ToString();
                    Menustrip.Items.Add(tsPrincipal);
                    if (item.Estado == "Eliminado")
                    {
                        tsPrincipal.DropDownItems.Add(tsRestaurar);
                    }
                    else
                    {
                        tsPrincipal.DropDownItems.Add(tsEditar);
                        tsPrincipal.DropDownItems.Add(tsEliminar);
                    }
                    //b.BringToFront();
                    p2.Controls.Add(Menustrip);
                    //p1.Controls.Add(b);
                    p1.Controls.Add(lblprecio);
                    if (item.Estado_imagen != "Vacio")
                    {
                        p1.Controls.Add(b);
                        p1.Controls.Add(ImgColorOverlayProducto);
                        b.Parent = ImgColorOverlayProducto;
                        b.TextAlign = ContentAlignment.BottomCenter;
                        b.Dock = DockStyle.Bottom;
                        b.ForeColor = Color.DarkRed;
                        b.BringToFront();
                    }
                    else
                    {
                        b.BackColor = Color.Transparent;
                        b.ForeColor = Color.White;
                        b.ForeColor = Color.FromArgb(0, 103, 192);
                        p1.Controls.Add(b);
                    }
                    p1.Controls.Add(p2);
                    IProductosView.PanelProductos.Controls.Add(p1);
                    ImgColorOverlayProducto.Click  += ImgColorOverlayProducto_Click;
                    tsEditar.Click += TsEditarProducto_Click;
                    tsEliminar.Click += TsEliminarProducto_Click;
                    tsRestaurar.Click += TsRestaurarProducto_Click;
                }
            }
        }
        private void ImgColorOverlayProducto_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((CImageColorOverlay)sender).Name);
            IProductosView.EstadoProducto = ((CImageColorOverlay)sender).Tag.ToString();
            if (IProductosView.EstadoProducto != "Eliminado")
            {
                DibujarProductos();
                HabilitarPanelVisorProductos();
                SeleccionarAndDesSeleccionarGrupos();
            }
            else
            {
                IProductosView.objDialogResult = MessageBox.Show("¿Desea restaurar este grupo?",
                                                                 "Grupo eliminado",
                                                                 MessageBoxButtons.OKCancel,
                                                                 MessageBoxIcon.Question);
                if (IProductosView.objDialogResult == DialogResult.OK)
                {
                    RestaurarGrupos();
                }
            }
        }
        private void DibujarGrupos()
        {
            IProductosView.PanelGrupo.Controls.Clear();
            var ListBuscarPorGrupos = IGrupoProductosModel.ListGrupoDeProductosModel(IProductosView.BuscarGrupo);
            if (ListBuscarPorGrupos != null)
            {
                foreach (var item in ListBuscarPorGrupos)
                {
                    Label lblGrupo = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox pbIcono = new PictureBox();
                    CImageColorOverlay ImgColorOverlayGrupoProducto = new CImageColorOverlay();

                    lblGrupo.Text = item.Grupo;
                    lblGrupo.Name = item.Idline.ToString();
                    lblGrupo.Tag = item.Estado;

                    lblGrupo.Size = new Size(119, 25);
                    lblGrupo.Font = new Font("Microsoft Sans Serif", 13);
                    lblGrupo.ForeColor = Color.White;
                    lblGrupo.Dock = DockStyle.Fill;
                    lblGrupo.TextAlign = ContentAlignment.MiddleCenter;
                    lblGrupo.Cursor = Cursors.Hand;

                    p1.Size = new Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.Name = item.Idline.ToString();
                    ImgColorOverlayGrupoProducto.Customizable = true;
                    ImgColorOverlayGrupoProducto.AccessibleName = FondoColorImage;

                    if (item.Estado == "Eliminado" && item.Estado_de_icono=="Lleno" && item.Icono != null)
                    {
                        ImgColorOverlayGrupoProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayGrupoProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayGrupoProducto.Size = new Size(140, 76);
                        ImgColorOverlayGrupoProducto.Dock = DockStyle.Top;
                        ImgColorOverlayGrupoProducto.Image = BinaryToImage(item.Icono);
                        ImgColorOverlayGrupoProducto.OverlayColor = Color.Red;
                        ImgColorOverlayGrupoProducto.Opacity = 20;
                        ImgColorOverlayGrupoProducto.Tag = item.Estado;
                        lblGrupo.BackColor = Color.Red;
                        p1.BackColor = Color.Red;
                        p2.BackColor = Color.Red;
                        lblGrupo.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    }
                    if (item.Estado == "Eliminado" && item.Estado_de_icono == "Vacio" && item.Icono == null)
                    {
                        p1.BackColor = Color.Red;
                        p2.BackColor = Color.Red;
                        ImgColorOverlayGrupoProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayGrupoProducto.Size = new Size(140, 76);
                        ImgColorOverlayGrupoProducto.Dock = DockStyle.Top;
                        ImgColorOverlayGrupoProducto.Image = null;
                        ImgColorOverlayGrupoProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayGrupoProducto.OverlayColor = Color.Red;
                        ImgColorOverlayGrupoProducto.Opacity = 50;
                        ImgColorOverlayGrupoProducto.Tag = item.Estado;
                        lblGrupo.BackColor = Color.Red;
                        lblGrupo.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    }
                    if (item.Estado == "Activo" && item.Estado_de_icono == "Lleno" && item.Icono !=null)
                    {
                        ImgColorOverlayGrupoProducto.BackColor = Color.FromArgb(239, 244, 249);
                        ImgColorOverlayGrupoProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayGrupoProducto.Size = new Size(140, 76);
                        ImgColorOverlayGrupoProducto.Dock = DockStyle.Top;
                        ImgColorOverlayGrupoProducto.Image = BinaryToImage(item.Icono);
                        ImgColorOverlayGrupoProducto.Opacity = 0;
                        ImgColorOverlayGrupoProducto.Tag = item.Estado;
                        p1.BackColor = Color.FromArgb(0, 103, 192);
                        p2.BackColor = Color.FromArgb(0, 103, 192);
                        lblGrupo.BackColor = Color.FromArgb(0, 103, 192);
                    }
                    if (item.Estado == "Activo" && item.Estado_de_icono == "Vacio" && item.Icono == null)
                    {
                        ImgColorOverlayGrupoProducto.ImageMode = ImageLayout.Stretch;
                        ImgColorOverlayGrupoProducto.BackgroundImage = null;
                        ImgColorOverlayGrupoProducto.Opacity = 0;
                        ImgColorOverlayGrupoProducto.Size = new Size(140, 76);
                        ImgColorOverlayGrupoProducto.Dock = DockStyle.Top;
                        ImgColorOverlayGrupoProducto.Tag = item.Estado;
                        p2.BackColor = Color.FromArgb(0, 103, 192);
                        lblGrupo.BackColor = Color.FromArgb(0, 103, 192);
                    }
                   
                    p2.Size = new Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BorderStyle = BorderStyle.None;
                    ImgColorOverlayGrupoProducto.Cursor = Cursors.Hand;
                    ImgColorOverlayGrupoProducto.Name = item.Idline.ToString();
                    ImgColorOverlayGrupoProducto.Tag = item.Estado;
                    MenuStrip Menustrip = new MenuStrip();
                    Menustrip.BackColor = Color.Transparent;
                    Menustrip.AutoSize = false;
                    Menustrip.Size = new Size(28, 24);
                    Menustrip.Dock = DockStyle.Right;
                    Menustrip.Name = item.Idline.ToString();
                    ToolStripMenuItem TsPrincipal = new ToolStripMenuItem();
                    ToolStripMenuItem TsEditar = new ToolStripMenuItem();
                    ToolStripMenuItem TsEliminar = new ToolStripMenuItem();
                    ToolStripMenuItem TsRestaurar = new ToolStripMenuItem();

                    TsPrincipal.Image = Resource1.menuCajas_claro;
                    TsPrincipal.BackColor = Color.Transparent;

                    TsEditar.Text = "Editar";
                    TsEditar.Name = item.Grupo;
                    TsEditar.Tag = Convert.ToInt32(item.Idline);

                    TsEliminar.Text = "Eliminar";
                    TsEliminar.Tag = item.Idline.ToString();

                    TsRestaurar.Text = "Restaurar";
                    TsRestaurar.Tag = item.Idline.ToString();

                    Menustrip.Items.Add(TsPrincipal);
                    if (item.Estado == "Eliminado")
                    {
                        TsPrincipal.DropDownItems.Add(TsRestaurar);
                    }
                    else
                    {
                        TsPrincipal.DropDownItems.Add(TsEditar);
                        TsPrincipal.DropDownItems.Add(TsEliminar);
                    }

                    p2.Controls.Add(Menustrip);
                    p1.Controls.Add(lblGrupo);
                    if (item.Estado_de_icono != "VACIO")
                    {
                        //p1.Controls.Add(pbIcono);
                        p1.Controls.Add(ImgColorOverlayGrupoProducto);
                    }

                    p1.Controls.Add(p2);
                    lblGrupo.BringToFront();
                    p2.SendToBack();
                    IProductosView.PanelGrupo.Controls.Add(p1);
                    lblGrupo.Click += new EventHandler(lblGrupo_Click);
                    ImgColorOverlayGrupoProducto.Click += new EventHandler(ImgColorOverlayGrupoProducto_Click);
                    pbIcono.Click += new EventHandler(pbIcono_Click);
                    TsEditar.Click += TsEditarGrupoProductos_Click;
                    TsEliminar.Click += TsEliminarGrupoProductos_Click;
                    TsRestaurar.Click += TsRestaurarGrupoProductos_Click;
                }
            }
        }
        private void ImgColorOverlayGrupoProducto_Click(object sender, EventArgs e)
        {
            FondoColorImage = "Pintado";
            IProductosView.Idline = Convert.ToInt32(((CImageColorOverlay)sender).Name);
            IProductosView.EstadoProducto = ((CImageColorOverlay)sender).Tag.ToString();
            ((CImageColorOverlay)sender).BackColor = Color.FromArgb(0, 103, 192);
            ((CImageColorOverlay)sender).OverlayColor = Color.FromArgb(0, 103, 192);
            ((CImageColorOverlay)sender).Opacity = 30;
            ((CImageColorOverlay)sender).AccessibleName = FondoColorImage;
            if (IProductosView.EstadoProducto != "Eliminado")
            {
                ListProductoModel = IProductosModel.MostrarProductosPorGrupos(IProductosView.Idline, IProductosView.Descripcion);
                if (ListProductoModel == null)
                {
                    DibujarProductos();
                    HabilitarPanelProductos();
                    IProductosView.ElegirGrupo.Text = "Sin Registros";
                    CentrarLabelEnPanel(IProductosView.ElegirGrupo);
                }
                else
                {
                    DibujarProductos();
                    HabilitarPanelProductos();
                }
            }
            else
            {
                HabilitarPanelBienvenida();
                IProductosView.ElegirGrupo.Text = "Eliminado";
                CentrarLabelEnPanel(IProductosView.ElegirGrupo);
            }
            SeleccionarAndDesSeleccionarGrupos();
        }
        private void SeleccionarAndDesSeleccionarGrupos()
        {
            //Sin Seleccionar
            foreach (Control item1 in IProductosView.PanelGrupo.Controls)
            {
                if (item1 is Panel)
                {
                    foreach (Control item2 in item1.Controls)
                    {
                        if (item2 is CImageColorOverlay)
                        {
                            CImageColorOverlay imgColorOverlayProducto = (CImageColorOverlay)item2;
                            if (imgColorOverlayProducto.AccessibleName == "Sin Fondo")
                            {
                                imgColorOverlayProducto.BackColor = Color.Transparent;
                                imgColorOverlayProducto.OverlayColor = Color.Transparent;
                                imgColorOverlayProducto.Opacity = 0;
                            }
                        }
                        
                    }
                    //foreach (Control item2 in item1.Controls)
                    //{
                    //    if (item2 is CImageColorOverlay)
                    //    {
                    //        CImageColorOverlay imgColorOverlayProducto = (CImageColorOverlay)item2;
                    //        if (ClickActivo == true)
                    //        {
                    //            imgColorOverlayProducto.BackColor = Color.FromArgb(0, 103, 192); ;
                    //            imgColorOverlayProducto.OverlayColor = Color.FromArgb(0, 103, 192); ;
                    //            imgColorOverlayProducto.Opacity = 30;
                    //        }
                    //        if (item2.Tag.ToString() == "Eliminado")
                    //        {
                    //            imgColorOverlayProducto.BackColor = Color.Transparent;
                    //            imgColorOverlayProducto.OverlayColor = Color.Transparent;
                    //            imgColorOverlayProducto.Opacity = 0;
                    //            break;
                    //        }
                    //    }

                    //}
                }
            }

            ////Seleccionado
            //foreach (Panel Panel1 in IProductosView.PanelGrupo.Controls)
            //{
            //    if (Panel1 is Panel)
            //    {
            //        if (Panel1.Name == Convert.ToString(IProductosView.Idline))
            //        {
            //            Panel1.BackColor = Color.FromArgb(0, 103, 192);
            //        }
            //    }
            //}
        }
        private void TsRestaurarGrupoProductos_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Restore;
            Accion = "Restaurar Grupo";
            color = ColorsAction.Negro;
            CambiarDePestañaACrudGrupos(Accion);
            CambiarColorBotonAccionGrupoProducto();
            objGrupoProductoModel = IGrupoProductosModel.GetById(IProductosView.Idline);
            FillInterfazViewGrupoProductos();
        }
        private void TsEliminarGrupoProductos_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Remove;
            Accion = "Eliminar Grupo";
            color = ColorsAction.Rojo;
            CambiarDePestañaACrudGrupos(Accion);
            CambiarColorBotonAccionGrupoProducto();
            objGrupoProductoModel = IGrupoProductosModel.GetById(IProductosView.Idline);
            FillInterfazViewGrupoProductos();
        }
        private void TsEditarGrupoProductos_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Edit;
            Accion = "Editar Grupo";
            color = ColorsAction.Azul;
            CambiarDePestañaACrudGrupos(Accion);
            CambiarColorBotonAccionGrupoProducto();
            objGrupoProductoModel = IGrupoProductosModel.GetById(IProductosView.Idline);
            FillInterfazViewGrupoProductos();
        }
        private void pbIcono_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((PictureBox)sender).Name);
            IProductosView.EstadoGrupoProducto = ((PictureBox)sender).Tag.ToString();
            
            if (IProductosView.EstadoGrupoProducto != "ELIMINADO")
            {
                DibujarProductos();
                HabilitarPanelVisorProductos();
                SeleccionarAndDesSeleccionarGrupos();
            }
            else
            {
                IProductosView.objDialogResult = MessageBox.Show("¿Desea restaurar este grupo?",
                                                                 "Grupo eliminado",
                                                                 MessageBoxButtons.OKCancel,
                                                                 MessageBoxIcon.Question);
                if (IProductosView.objDialogResult == DialogResult.OK)
                {
                    RestaurarGrupos();
                }
            }
        }
        public void RestaurarGrupos()
        {
            var result = IGrupoProductosModel.RestaurarGrupoDeProductos(IProductosView.Idline);
            if (result)
                DibujarGrupos();
        }
        private void lblGrupo_Click(object sender, EventArgs e)
        {
            IProductosView.Idline = Convert.ToInt32(((Label)sender).Name);
            IProductosView.EstadoProducto = ((Label)sender).Tag.ToString();
            if (IProductosView.EstadoProducto != "Eliminado")
            {
                ListProductoModel = IProductosModel.MostrarProductosPorGrupos(IProductosView.Idline, IProductosView.Descripcion);
                if (ListProductoModel == null)
                {
                    HabilitarPanelBienvenida();
                    IProductosView.ElegirGrupo.Text = "Sin Registros";
                    CentrarLabelEnPanel(IProductosView.ElegirGrupo);
                }
                else
                {
                    DibujarProductos();
                    HabilitarPanelVisorProductos();
                    SeleccionarAndDesSeleccionarGrupos();
                }
            }
            else
            {
                HabilitarPanelBienvenida();
                IProductosView.ElegirGrupo.Text = "Eliminado";
                CentrarLabelEnPanel(IProductosView.ElegirGrupo);
            }
        }
        private void TsRestaurarProducto_Click(object sender, EventArgs e)
        {
            IProductosView.Id_Producto1 = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Restore;
            Accion = "Restaurar Producto";
            color = ColorsAction.Negro;
            CambiarDePestañaACrudProductos(Accion);
            CambiarColorBotonAccionProducto();
            objProductoModel = IProductosModel.GetById(IProductosView.Id_Producto1);
            FillInterfazViewProductos();
        }
        private void TsEliminarProducto_Click(object sender, EventArgs e)
        {
            IProductosView.Id_Producto1 = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Remove;
            Accion = "Eliminar Producto";
            color = ColorsAction.Rojo;
            CambiarDePestañaACrudProductos(Accion);
            CambiarColorBotonAccionProducto();
            objProductoModel = IProductosModel.GetById(IProductosView.Id_Producto1);
            FillInterfazViewProductos();
        }
        private ProductosModel FillProductosModel()
        {
            objProductoModel.Id_Producto1 = IProductosView.Id_Producto1;
            objProductoModel.Descripcion = IProductosView.CtxtDescripcion.Text;
            if (IProductosView.Imagen != null)
            {
                ItemConverter.ImageToBinary(IProductosView.pictureImagen.Image);
                IProductosView.Estado_Imagen = "Lleno";
            }
            else
            {
                IProductosView.pictureImagen.Image = null;
                IProductosView.Estado_Imagen = "Vacio";
            }
            objProductoModel.Imagen = IProductosView.Imagen;
            objProductoModel.Id_grupo = IProductosView.Idline;
            objProductoModel.Precio_de_venta = IProductosView.Precio_de_venta;
            objProductoModel.Precio_de_compra = IProductosView.Precio_de_compra;
            objProductoModel.Estado_imagen = IProductosView.Estado_Imagen;
            objProductoModel.Idcolor = IProductosView.Idcolor;
            objProductoModel.Estado = IProductosView.EstadoProducto;
            objProductoModel.CodUm = string.Empty;
            objProductoModel.CodigoSunat = string.Empty;
            objProductoModel.Codigo = string.Empty;
            return objProductoModel;
        }
        private GrupoProductosModel FillGrupoProductoModel()
        {
            objGrupoProductoModel.Idline = IProductosView.Idline;
            objGrupoProductoModel.Grupo = IProductosView.Grupo;
            objGrupoProductoModel.Por_defecto = IProductosView.Por_defecto;
            if (IProductosView.Icono != null)
            {
                ItemConverter.ImageToBinary(IProductosView.pbIcono.Image);
                IProductosView.Estado_de_icono = "Lleno";
                objGrupoProductoModel.Icono = ItemConverter.ImageToBinary(IProductosView.pbIcono.Image);
            }
            else
            {
                IProductosView.pbIcono.Image = null;
                IProductosView.Estado_de_icono = "Vacio";
                objGrupoProductoModel.Icono = IProductosView.Icono;
            }
            objGrupoProductoModel.Estado = IProductosView.EstadoGrupoProducto;
            objGrupoProductoModel.Estado_de_icono = IProductosView.Estado_de_icono;
            objGrupoProductoModel.Idcolor = IProductosView.Idcolor;
            return objGrupoProductoModel;
        }
        private void FillInterfazViewProductos()
        {
            IProductosView.Id_Producto1 = objProductoModel.Id_Producto1;
            IProductosView.CtxtDescripcion.Text = objProductoModel.Descripcion.ToString();
            IProductosView.CtxtPrecioDeCompra.Text = objProductoModel.Precio_de_compra.ToString();
            IProductosView.CtxtPrecioDeVenta.Text = objProductoModel.Precio_de_venta.ToString();
            if (objProductoModel.Imagen != null)
            {
                IProductosView.pictureImagen.Image = ItemConverter.BinaryToImage(objProductoModel.Imagen);
                IProductosView.Imagen = objProductoModel.Imagen;
            }
            else
            {
                IProductosView.pictureImagen.Image = null;
                IProductosView.Imagen = objProductoModel.Imagen;
            }
            IProductosView.Idline = objProductoModel.Id_grupo;
            IProductosView.Idcolor = objProductoModel.Idcolor;
            IProductosView.Estado_Imagen = objProductoModel.Estado_imagen;
            IProductosView.btn_Producto_Color.BackColor = ColorTranslator.FromHtml(IColoresModel.ObtenerColorPorId(objProductoModel.Idcolor));
            IProductosView.EstadoProducto = objProductoModel.Estado;
            IProductosView.Idline = objProductoModel.Id_grupo;
        }
        private void FillInterfazViewGrupoProductos()
        {
            IProductosView.Idline = objGrupoProductoModel.Idline;
            IProductosView.grupo.Text = objGrupoProductoModel.Grupo;
            IProductosView.Por_defecto = objGrupoProductoModel.Por_defecto;
            if (objGrupoProductoModel.Icono != null)
            {
                IProductosView.pbIcono.Image = ItemConverter.BinaryToImage(objGrupoProductoModel.Icono);
                IProductosView.Icono = objGrupoProductoModel.Icono;
            }
            else
            {
                IProductosView.pbIcono.Image = null;
                IProductosView.Icono = objGrupoProductoModel.Icono;
            }
                
            IProductosView.btn_GrupoProducto_Color.BackColor = ColorTranslator.FromHtml(IColoresModel.ObtenerColorPorId(objGrupoProductoModel.Idcolor));
            IProductosView.EstadoGrupoProducto = objGrupoProductoModel.Estado;
            IProductosView.Estado_de_icono = objGrupoProductoModel.Estado_de_icono;
            IProductosView.Idcolor = objGrupoProductoModel.Idcolor;
        }
        private void TsEditarProducto_Click(object sender, EventArgs e)
        {
            IProductosView.Id_Producto1 = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction = TransactionAction.Edit;
            Accion = "Editar Producto";
            color = ColorsAction.Azul;
            CambiarDePestañaACrudProductos(Accion);
            CambiarColorBotonAccionProducto();
            objProductoModel = IProductosModel.GetById(IProductosView.Id_Producto1);
            FillInterfazViewProductos();
        }
        private void CambiarColorBotonAccionProducto()
        {
            switch (color)
            {
                case ColorsAction.Verde:
                    IProductosView.AccionBoton.BackgroundImage = Resource1.verde;
                    IProductosView.AccionBoton.Text = "Guardar";
                    break;
                case ColorsAction.Azul:
                    IProductosView.AccionBoton.BackgroundImage = Resource1.azul;
                    IProductosView.AccionBoton.Text = "Editar";
                    break;
                case ColorsAction.Rojo:
                    IProductosView.AccionBoton.BackgroundImage = Resource1.Rojo;
                    IProductosView.AccionBoton.Text = "Eliminar";
                    break;
                case ColorsAction.Negro:
                    IProductosView.AccionBoton.BackgroundImage = Resource1.negro;
                    IProductosView.AccionBoton.Text = "Restaurar";
                    break;
            }
        }
        private void CambiarColorBotonAccionGrupoProducto()
        {
            switch (color)
            {
                case ColorsAction.Verde:
                    IProductosView.AccionButonGrupoProducto.BackgroundImage = Resource1.verde;
                    IProductosView.AccionButonGrupoProducto.Text = "Guardar";
                    break;
                case ColorsAction.Azul:
                    IProductosView.AccionButonGrupoProducto.BackgroundImage = Resource1.azul;
                    IProductosView.AccionButonGrupoProducto.Text = "Editar";
                    break;
                case ColorsAction.Rojo:
                    IProductosView.AccionButonGrupoProducto.BackgroundImage = Resource1.Rojo;
                    IProductosView.AccionButonGrupoProducto.Text = "Eliminar";
                    break;
                case ColorsAction.Negro:
                    IProductosView.AccionButonGrupoProducto.BackgroundImage = Resource1.negro;
                    IProductosView.AccionButonGrupoProducto.Text = "Restaurar";
                    break;
            }
        }
        public void MostrarProductosColores() 
        {
            var ListColores = IColoresModel.MostrarColores();
            if (ListColores != null)
            {
                foreach (var item in ListColores)
                {
                    Button btnColor = new Button();
                    btnColor.Width = 30;
                    btnColor.Height = 30;
                    btnColor.FlatStyle = FlatStyle.Flat;
                    btnColor.BackColor = ColorTranslator.FromHtml(item.colorhtml.ToString());
                    btnColor.Name = item.colorhtml.ToString();
                    btnColor.Tag = item.Idcolor.ToString();
                    IProductosView.fpColores.Controls.Add(btnColor);
                    btnColor.Click += btnProductoColor_Click;
                }
            }
        }
        public void MostrarGrupoProductosColores()
        {
            var ListColores = IColoresModel.MostrarColores();
            if (ListColores != null)
            {
                foreach (var item in ListColores)
                {
                    Button btnColor = new Button();
                    btnColor.Width = 30;
                    btnColor.Height = 30;
                    btnColor.FlatStyle = FlatStyle.Flat;
                    btnColor.BackColor = ColorTranslator.FromHtml(item.colorhtml.ToString());
                    btnColor.Name = item.colorhtml.ToString();
                    btnColor.Tag = item.Idcolor.ToString();
                    IProductosView.flpGrupoDeColores.Controls.Add(btnColor);
                    btnColor.Click += btnGrupoProductoColor_Click;
                }
            }
        }
        private void btnGrupoProductoColor_Click(object sender, EventArgs e)
        {
            IProductosView.Idcolor = Convert.ToInt32(((Button)sender).Tag);
            IProductosView.GrupoProductoColorhtml= ((Button)sender).Name;
            IProductosView.btn_GrupoProducto_Color.BackColor = ColorTranslator.FromHtml(IProductosView.GrupoProductoColorhtml);
        }
        private void btnProductoColor_Click(object sender, EventArgs e)
        {
            IProductosView.Idcolor = Convert.ToInt32(((Button)sender).Tag);
            IProductosView.ProductoColorhtml = ((Button)sender).Name;
            IProductosView.btn_Producto_Color.BackColor = ColorTranslator.FromHtml(IProductosView.ProductoColorhtml);
        }
        private void LimpiarObjetosProductos()
        {
            IProductosView.Id_Producto1 = 0;
            IProductosView.CtxtDescripcion.Text = string.Empty;
            IProductosView.CtxtPrecioDeCompra.Text = string.Empty;
            IProductosView.CtxtPrecioDeVenta.Text = string.Empty;
            IProductosView.Imagen = null;
            IProductosView.pictureImagen.Image = null;
            IProductosView.Idline = 0;
            IProductosView.Idcolor = 0;
            IProductosView.Estado_Imagen = string.Empty;
            IProductosView.EstadoProducto = string.Empty;
        }
        private void LimpiarObjetosGrupoProductos()
        {
            IProductosView.Idline = 0;
            IProductosView.Grupo = string.Empty;
            IProductosView.Por_defecto = string.Empty;
            IProductosView.pbIcono.Image = null;


            IProductosView.Imagen = null;
            IProductosView.pictureImagen.Image = null;
            IProductosView.Idcolor = 0;
            IProductosView.Estado_Imagen = string.Empty;
            IProductosView.EstadoProducto = string.Empty;
        }
    }
}
