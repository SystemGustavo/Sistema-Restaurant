using Common.Cache;
using ControlesPersonalizados.Controles;
using Domain.Contratos;
using Domain.Models;
using Presentation.Utils;
using Presentation.ViewModels;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class PuntoDeVentaPresenter : ItemConverter
    {
        private readonly IPuntoDeVentaView IPuntoDeVentaView;
        private readonly List<DetalleVentaViewModel> detalleVentaViewModel;
        private readonly IPuntoDeVentaModel IPuntoDeVentaModel;
        CImageColorOverlay imagenOpacity;

        int idGrupo;

        public PuntoDeVentaPresenter(IPuntoDeVentaView _IPuntoDeVentaView,PuntoDeVentaModel _PuntoDeVentaModel)
        {
            IPuntoDeVentaView = _IPuntoDeVentaView;
            IPuntoDeVentaModel = _PuntoDeVentaModel;
            detalleVentaViewModel = new List<DetalleVentaViewModel>();
            IPuntoDeVentaModel = _PuntoDeVentaModel;
            //IPuntoDeVentaView.SetDetalleVentasList(detalleVentaViewModel);

            IPuntoDeVentaView.EventFrmPuntoDeVentaLoad += FrmPuntoDeVenta_Load;
            IPuntoDeVentaView.EventTimerFechaHora += TiempoFechaHora_Tick;



            IPuntoDeVentaView.EventBoton1Sol += btn1Sol_Click;
            IPuntoDeVentaView.EventBoton5Soles += btn5Soles_Click;
            IPuntoDeVentaView.EventBoton10Soles += btn10Soles_Click;
            IPuntoDeVentaView.EventBoton20Soles += btn20Soles_Click;
            IPuntoDeVentaView.EventBoton50Soles += btn50Soles_Click;
            IPuntoDeVentaView.EventBoton100Soles += btn100Soles_Click;
            IPuntoDeVentaView.EventBotonExacto += btnExacto_Click;

            IPuntoDeVentaView.EventBotonCobrar += btnCobrar_Click;

            AgregarDetalleVentas();
        }

        private void AgregarDetalleVentas()
        {
            IPuntoDeVentaView.fpanelDetalleVentas.Controls.Clear();
            var DatosDetalleVentasVM = new List<DatosDetalleVentasVM>();
            var mostrarDetalleVenta = IPuntoDeVentaModel.MostrarDetalleVenta(1, 2);
            if (mostrarDetalleVenta != null)
            {
                foreach (var item in mostrarDetalleVenta)
                {

                    Button btnEliminar = new Button();
                    Label lblCantidad = new Label();
                    Label lblProducto = new Label();
                    Label lblImporte = new Label();
                    Panel pnl1 = new Panel();
                    Panel pnlContenedor = new Panel();
                    Panel pnlEstado = new Panel();

                    DatosDetalleVentasVM.Add(new DatosDetalleVentasVM
                    {
                        IdDetalleVenta = item.idDetalleVenta,
                        Cantidad = item.Cantidad,
                        Importe = item.TotalAPagar,
                        Descripcion = item.Descripcion,
                        PrecioUnitario = item.PrecioUnitario,
                        Estado = item.Estado
                    });


                    //Diseño del BotonEliminar
                    btnEliminar.Text = "Borrar";
                    btnEliminar.Tag = DatosDetalleVentasVM;
                    btnEliminar.Size = new Size(55, 51);
                    btnEliminar.Font = new Font("Microsoft Sans Serif", 9);
                    btnEliminar.BackColor = Color.Transparent;
                    btnEliminar.ForeColor = Color.White;
                    btnEliminar.Dock = DockStyle.Left;
                    btnEliminar.TextAlign = ContentAlignment.MiddleCenter;
                    btnEliminar.Cursor = Cursors.Hand;
                    btnEliminar.BackgroundImage = Resource1.Rojo;
                    btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
                    btnEliminar.FlatStyle = FlatStyle.Flat;
                    btnEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    btnEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btnEliminar.FlatAppearance.BorderSize = 0;

                    //Diseño de la Etiqueta Cantidad
                    lblCantidad.Text = item.Cantidad.ToString();
                    lblCantidad.Tag = DatosDetalleVentasVM;
                    lblCantidad.Size = new Size(127, 25);
                    lblCantidad.Font = new Font("Microsoft Sans Serif", 11);
                    lblCantidad.BackColor = Color.Transparent;
                    lblCantidad.Dock = DockStyle.Top;
                    lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
                    lblCantidad.Cursor = Cursors.Hand;

                    //Diseño de la Etiqueta Producto
                    lblProducto.Text = item.Descripcion.ToString();
                    lblProducto.Tag = DatosDetalleVentasVM;
                    lblProducto.Size = new Size(158, 51);
                    lblProducto.Font = new Font("Microsoft Sans Serif", 11);
                    lblProducto.BackColor = Color.Transparent;
                    lblProducto.Dock = DockStyle.Fill;
                    lblProducto.TextAlign = ContentAlignment.MiddleCenter;
                    lblProducto.Cursor = Cursors.Hand;

                    //Diseño de la Etiqueta Importe
                    lblImporte.Text = item.PrecioUnitario.ToString();
                    lblImporte.Tag = DatosDetalleVentasVM;
                    lblImporte.Size = new Size(127, 51);
                    lblImporte.Font = new Font("Microsoft Sans Serif", 11);
                    lblImporte.BackColor = Color.Transparent;
                    lblImporte.Dock = DockStyle.Right;
                    lblImporte.TextAlign = ContentAlignment.MiddleCenter;
                    lblImporte.Cursor = Cursors.Hand;

                    //Diseño del Panel 1
                    pnl1.Size = new Size(467, 51);
                    pnl1.BorderStyle = BorderStyle.None;
                    pnl1.BackColor = Color.Transparent;
                    pnl1.Tag = DatosDetalleVentasVM;
                    pnl1.Dock = DockStyle.Top;

                    //Diseño del Panel Estado
                    pnlEstado.Size = new Size(127, 25);
                    pnlEstado.BorderStyle = BorderStyle.None;
                    pnlEstado.BackColor = Color.Transparent;
                    pnlEstado.Tag = DatosDetalleVentasVM;
                    pnlEstado.Dock = DockStyle.Left;

                    //Diseño del Panel Contenedor
                    pnlContenedor.Size = new Size(467, 52);
                    pnlContenedor.BorderStyle = BorderStyle.None;
                    pnlContenedor.BackColor = Color.Transparent;
                    pnlContenedor.Tag = DatosDetalleVentasVM.ToString();

                    //Agrega paneles al flowLayoutPanel Detalle Ventas
                    pnlEstado.Controls.Add(lblCantidad);
                    pnl1.Controls.Add(btnEliminar);
                    pnl1.Controls.Add(lblProducto);
                    pnl1.Controls.Add(lblImporte);
                    pnl1.Controls.Add(pnlEstado);
                    pnlContenedor.Controls.Add(pnl1);

                    IPuntoDeVentaView.fpanelDetalleVentas.Controls.Add(pnlContenedor);

                }
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.FormCobros = new FrmCobros();
            IPuntoDeVentaView.FormCobros.ShowDialog();
          
        }

        private void btn20Soles_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 20;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void btnExacto_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn100Soles_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 100;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void btn50Soles_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 50;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void btn10Soles_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 10;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void btn5Soles_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 5;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void btn1Sol_Click(object sender, EventArgs e)
        {
            IPuntoDeVentaView.acumuladorDinero += 1;
            IPuntoDeVentaView.lblAcumulador.Text = IPuntoDeVentaView.acumuladorDinero.ToString();
        }

        private void TiempoFechaHora_Tick(object sender, EventArgs e)
        {
            IPuntoDeVentaView.fecha = DateTime.Now.ToShortDateString();
            IPuntoDeVentaView.hora = DateTime.Now.ToString("hh:mm:ss");
        }

        private void FrmPuntoDeVenta_Load(object sender, EventArgs e)
        {
            int idGrupo = 1;
            int desde = 1;
            int hasta = 6;
            
            DibujarGrupoDeProductos(desde, hasta);
            DiseñoMostrarDetalleVenta();
            //DibujarProductosPorGrupo(idGrupo, desde, hasta);
        }

        private void DibujarProductosPorGrupo(int idGrupo,int desde,int hasta)
        {
            IPuntoDeVentaView.fpanelListProductos.Controls.Clear();
            try
            {
                var ListBuscarPorGrupos = IPuntoDeVentaModel.PaginarProductosPorGrupo(idGrupo, desde, hasta);
                if (ListBuscarPorGrupos != null)
                {
                    foreach (var item in ListBuscarPorGrupos)
                    {
                        Panel PanelContenedor = new Panel();
                        Panel PanelSuperiorDelContenedor = new Panel();
                        Panel PanelInferiorDelContenedor = new Panel();
                        Label lblPrecioProducto = new Label();
                        Label lblNombreProducto = new Label();
                        PictureBox ImagenDentroDelPanelSuperior = new PictureBox();

                        //traer datos desde la base de datos
                        List<string> datosBD = new List<string>();
                        datosBD.Add(item.Id_Producto.ToString());
                        datosBD.Add(item.Precio_de_venta.ToString());
                        datosBD.Add(item.Precio_de_compra.ToString());
                        datosBD.Add(item.Moneda.ToString());
                        datosBD.Add(item.Descripcion.ToString());

                        //Diseño PrecioProducto
                        //lblPrecioProducto.Dock = DockStyle.Fill;
                        lblPrecioProducto.Text = datosBD[3]+datosBD[1];
                        lblPrecioProducto.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        lblPrecioProducto.BackColor = Color.Red;
                        lblPrecioProducto.ForeColor = Color.White;
                        lblPrecioProducto.Location = new Point(0, 0);
                        lblPrecioProducto.Size = new Size(65, 18);
                        lblPrecioProducto.Cursor = Cursors.Hand;
                        lblPrecioProducto.Tag = datosBD;

                        //Diseño precio del NombreProducto
                        lblNombreProducto.Text = datosBD[4];
                        lblNombreProducto.Dock = DockStyle.Fill;
                        lblNombreProducto.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                        lblNombreProducto.TextAlign = ContentAlignment.MiddleCenter;
                        lblNombreProducto.BackColor = Color.Blue;
                        lblNombreProducto.ForeColor = Color.White;
                        lblNombreProducto.Location = new Point(0, 0);
                        lblNombreProducto.Cursor = Cursors.Hand;
                        lblNombreProducto.Tag = datosBD;

                        //Diseño del ImagenDentroDelPanelSuperior
                        ImagenDentroDelPanelSuperior.Dock = DockStyle.Fill;
                        ImagenDentroDelPanelSuperior.Size = new Size(160, 135);
                        ImagenDentroDelPanelSuperior.SizeMode = PictureBoxSizeMode.StretchImage;
                        ImagenDentroDelPanelSuperior.Tag = datosBD;


                        //Diseño del PanelSuperiorDelContenedor
                        PanelSuperiorDelContenedor.Dock = DockStyle.Fill;
                        PanelSuperiorDelContenedor.Controls.Add(lblPrecioProducto);

                        //Diseño del PanelInferiorDelContenedor
                        PanelInferiorDelContenedor.Dock = DockStyle.Bottom;
                        PanelInferiorDelContenedor.Size = new Size(160, 26);
                        PanelInferiorDelContenedor.Controls.Add(lblNombreProducto);


                        if (item.Estado_imagen != "Vacio")
                        {
                            ImagenDentroDelPanelSuperior.Image = BinaryToImage(item.Imagen);
                            PanelSuperiorDelContenedor.Controls.Add(ImagenDentroDelPanelSuperior);
                        }

                        //Diseño del PanelContenedor
                        PanelContenedor.Size = new Size(120, 120);
                        PanelContenedor.Controls.Add(PanelSuperiorDelContenedor);
                        PanelContenedor.Controls.Add(PanelInferiorDelContenedor);


                        IPuntoDeVentaView.fpanelListProductos.Controls.Add(PanelContenedor);
                        ImagenDentroDelPanelSuperior.Click += ImagenDentroDelPanelSuperior_Click;
                        lblNombreProducto.Click += lblNombreProducto_Click;
                        lblPrecioProducto.Click += lblPrecioProducto_Click;
                    }
                }
                else
                {
                    MessageBox.Show("No hay Productos");
                }
                
            }
            catch (Exception)
            {

            }
        }

        private void DibujarGrupoDeProductos(int desde, int hasta)
        {
            IPuntoDeVentaView.fpanelListGrupos.Controls.Clear();
            try
            {
                var ListGrupoProductos = IPuntoDeVentaModel.PaginarGrupoProductos(desde, hasta);
                if (ListGrupoProductos != null)
                {
                    foreach (var item in ListGrupoProductos)
                    {
                        List<string> datosPictureBox = new List<string>();
                        datosPictureBox.Add(item.Id_Producto.ToString());
                        datosPictureBox.Add(item.Precio_de_venta.ToString());
                        datosPictureBox.Add(item.Precio_de_compra.ToString());
                        

                        Panel PanelContenedor = new Panel();
                        CPanel PanelContenedorSuperior = new CPanel();
                        Panel PanelContenedorInferior = new Panel();

                        TableLayoutPanel tbGrupoProductos = new TableLayoutPanel();
                        CImageColorOverlay pbImagen = new CImageColorOverlay();
                        Label lblNombreGrupo = new Label();
                        Label etiquetaSinImagen = new Label();

                        //Diseño de EtiquetaSinImagen
                        etiquetaSinImagen.Text = "Sin Imagen";
                        etiquetaSinImagen.Dock = DockStyle.Fill;
                        etiquetaSinImagen.TextAlign = ContentAlignment.MiddleCenter;
                        etiquetaSinImagen.BorderStyle = BorderStyle.FixedSingle;
                        etiquetaSinImagen.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

                        //Diseño del NombreGrupo
                        lblNombreGrupo.Text = item.Grupo;
                        lblNombreGrupo.Name = item.IdLine.ToString();
                        lblNombreGrupo.Cursor = Cursors.Hand;
                        lblNombreGrupo.BackColor = Color.Blue;
                        lblNombreGrupo.ForeColor = Color.White;
                        lblNombreGrupo.Location = new Point(0, 0);
                        //lblNombreGrupo.Size = new Size(65, 18);
                        lblNombreGrupo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        lblNombreGrupo.TextAlign = ContentAlignment.MiddleCenter;
                        lblNombreGrupo.Dock = DockStyle.Fill;

                        //Diseño de la Imagen
                        pbImagen.Name = item.IdLine.ToString();
                        pbImagen.Tag = datosPictureBox;
                        //pbImagen.a = item.Precio_de_venta;
                        pbImagen.Dock = DockStyle.Fill;
                        pbImagen.BackgroundImageLayout = ImageLayout.Stretch;
                        pbImagen.Customizable = true;
                        pbImagen.Opacity = 0;


                        //Diseño del PanelContenedorSup
                        PanelContenedorSuperior.Dock = DockStyle.Fill;
                        PanelContenedorSuperior.BackColor = Color.Transparent;
                        PanelContenedorSuperior.Size = new Size(110, 80);
                        PanelContenedorSuperior.Name = "PanelContenedorSuperior";

                        //Diseño del PanelInferiorDelContenedor
                        PanelContenedorInferior.Name = "PanelContenedorInferior";
                        PanelContenedorInferior.Dock = DockStyle.Bottom;
                        PanelContenedorInferior.Size = new Size(40, 20);

                        if (item.Estado_imagen != "Vacio")
                        {
                            pbImagen.Image = BinaryToImage(item.Imagen);
                            PanelContenedorSuperior.Controls.Add(pbImagen);
                            PanelContenedorInferior.Controls.Add(lblNombreGrupo);
                        }
                        else
                        {
                            PanelContenedor.Controls.Add(etiquetaSinImagen);
                            PanelContenedorInferior.Controls.Add(lblNombreGrupo);
                        }


                        PanelContenedor.Size = new Size(150, 100);
                        PanelContenedor.Name = "PanelContenedor";
                        PanelContenedor.Controls.Add(PanelContenedorSuperior);
                        PanelContenedor.Controls.Add(PanelContenedorInferior);
                        IPuntoDeVentaView.fpanelListGrupos.Controls.Add(PanelContenedor);

                        lblNombreGrupo.Click += new EventHandler(lblNombreGrupo_Click);
                        pbImagen.Click += new EventHandler(pbImagen_Click);
                    }
                }
               
            }
            catch (Exception)
            {

            }
        }

        private void SeleccionarAndDeseleccionarGrupo()
        {
            try
            {
                foreach (Control control1 in IPuntoDeVentaView.fpanelListGrupos.Controls)
                {
                    if (control1 is Panel) //Si Es PanelContenedor
                    {
                        foreach (Control control2 in control1.Controls)
                        {
                            if (control2.Name=="PanelContenedorSuperior")
                            {

                            }

                            if (control2.Name == "PanelContenedorInferior")
                            {
                                Control lbl =  control2.Controls[0];
                            }
                            //foreach (Control control in control2.Controls)
                            //{
                            //    if (control is CImageColorOverlay)
                            //    {
                            //        imagenOpacity =  (CImageColorOverlay)control;
                            //        imagenOpacity.Opacity = 50;
                            //    }
                            //    if (control is Panel)
                            //    {
                            //        foreach (Panel controls in control2.Controls)
                            //        {
                            //            if (controls is Label)
                            //            {
                            //                control.BackColor = Color.Red;
                            //            }
                            //        }
                            //    }
                            //}
                            //if (control2.Name=="PanelContenedorSuperior")
                            //{
                            //    //Control controlImagen = control2.Controls[0];
                            //    //((CImageColorOverlay)controlImagen).Opacity = 50;
                            //}
                            //break;
                           
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            DibujarProductosPorGrupo(idGrupo, 1, 5);
            SeleccionarAndDeseleccionarGrupo();
        }

        private void InsertarVenta()
        {
            throw new NotImplementedException();
        }

        //public static void RemoveRowTableLayout(System.Windows.Forms.TableLayoutPanel tableLayoutPanel, int rowNumber)
        //{

        //    var controlesTotal = Enumerable.Range(0, tableLayoutPanel.ColumnCount).Select(x => new Tuple(tableLayoutPanel.GetControlFromPosition(x, rowNumber), x)).ToArray;

        //    for (index = 0; index <= controlesTotal.Length - 1; index++)
        //    {
        //        dynamic item = controlesTotal(index);

        //        if ((item.Item1 != null))
        //        {
        //            tableLayoutPanel.Controls.Remove(item.Item1);
        //        }
        //    }

        //    foreach (Control control in tableLayoutPanel.Controls)
        //    {
        //        int row = tableLayoutPanel.GetRow(control);
        //        if (row > rowNumber)
        //        {
        //            tableLayoutPanel.SetRow(control, row - 1);
        //        }
        //    }

        //    tableLayoutPanel.RowStyles.RemoveAt(rowNumber);
        //    tableLayoutPanel.RowCount = tableLayoutPanel.RowCount - 1;

        //}


        private void DiseñoMostrarDetalleVenta()
        {
           
        }

        private void lblNombreGrupo_Click(object sender, EventArgs e)
        {
            idGrupo = Convert.ToInt32(((Label)sender).Name);
            DibujarProductosPorGrupo(idGrupo,1,5);
            SeleccionarAndDeseleccionarGrupo();
        }

        private void lblPrecioProducto_Click(object sender, EventArgs e)
        {
            List<string> datos= (List<string>)((Label)sender).Tag;
            PuntoDeVentaCache.IdProducto = Convert.ToInt32(datos[0]);
            PuntoDeVentaCache.PrecioDeVenta = Convert.ToDouble(datos[1]);
            PuntoDeVentaCache.PrecioDeCompra = Convert.ToDouble(datos[2]);
            InsertarVenta();
        }

        private void lblNombreProducto_Click(object sender, EventArgs e)
        {
            List<string> datos = (List<string>)((Label)sender).Tag;
            PuntoDeVentaCache.IdProducto = Convert.ToInt32(datos[0]);
            PuntoDeVentaCache.PrecioDeVenta = Convert.ToDouble(datos[1]);
            PuntoDeVentaCache.PrecioDeCompra = Convert.ToDouble(datos[2]);
            InsertarVenta();
        }

        private void ImagenDentroDelPanelSuperior_Click(object sender, EventArgs e)
        {
            List<string> datos = (List<string>)((PictureBox)sender).Tag;
            PuntoDeVentaCache.IdProducto = Convert.ToInt32(datos[0]);
            PuntoDeVentaCache.PrecioDeVenta = Convert.ToDouble(datos[1]);
            PuntoDeVentaCache.PrecioDeCompra = Convert.ToDouble(datos[2]);
            InsertarVenta();
        }
    }
}
