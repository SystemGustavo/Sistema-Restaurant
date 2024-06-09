using Common.Bases;
using Common.Cache;
using Domain.Models;
using Presentation.Utils;
using Presentation.Views;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class IniciarSesionPresenter:ControlsGeneric
    {
        private IIniciarSesionView IIniciarSesionView;
        private UsuariosModel UsuariosModel;
        private MovimientoDeCajaModel MovimientoCajaModel;
        private CajasModel CajasModel;
        private InicioDeSesionModel InicioDeSesionModel;

        public IniciarSesionPresenter(IIniciarSesionView IIniciarSesion,
                                      UsuariosModel UsuarioModel,
                                      MovimientoDeCajaModel MovimientosDeCajaModel,
                                      CajasModel CajasModel,
                                      InicioDeSesionModel InicioDeSesionModel)
        {
            this.IIniciarSesionView = IIniciarSesion;
            this.UsuariosModel = UsuarioModel;
            this.MovimientoCajaModel = MovimientosDeCajaModel;
            this.CajasModel = CajasModel;
            this.InicioDeSesionModel = InicioDeSesionModel;

            //Subscribe event handler methods to view events
            IIniciarSesionView.boton1 += Boton1;
            IIniciarSesionView.boton2 += Boton2;
            IIniciarSesionView.boton3 += Boton3;
            IIniciarSesionView.boton4 += Boton4;
            IIniciarSesionView.boton5 += Boton5;
            IIniciarSesionView.boton6 += Boton6;
            IIniciarSesionView.boton7 += Boton7;
            IIniciarSesionView.boton8 += Boton8;
            IIniciarSesionView.boton9 += Boton9;
            IIniciarSesionView.boton0 += Boton0;

            IIniciarSesionView.botonBorrar += BotonBorrar;
            IIniciarSesionView.botonBorrarDerecha += BotonBorrarAlaDerecha;
            IIniciarSesionView.load += FrmIniciarSesion_Load;
            IIniciarSesionView.botonCambiarDeUsuario += btnCambiarDeUsuario;
            IIniciarSesionView.TextBox_TextChanged += txtContraseña_TextChanged;

            DibujarUsuarios();

        }

        private void btnCambiarDeUsuario(object sender, EventArgs e)
        {
            IIniciarSesionView.PanelVisorContraseña.Visible = false;
            CentrarPanel(IIniciarSesionView.FormIniciarSesion, IIniciarSesionView.PanelVisorUsuarios);
            IIniciarSesionView.PanelVisorUsuarios.Visible = true;
            Console.Beep(2200, 1000);
        }

        private void FrmIniciarSesion_Load(object sender, EventArgs e)
        {
            IIniciarSesionView.PanelVisorUsuarios.Visible = true;
            CentrarPanel(IIniciarSesionView.FormIniciarSesion, IIniciarSesionView.PanelVisorContraseña);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarUsuarios();
        }

        public void ValidarUsuarios()
        {
            UsuariosModel.IniciarSesion(IIniciarSesionView.usuario, IIniciarSesionView.contraseña);
            if(UsuariosModel != null){
                if (UsuarioCache.Position == Position.Administrador || UsuarioCache.Position == Position.Cajero)
                    ValidarAperturaDeCaja();
                else
                    ValidarRoles();
            }
        }

        public void ValidarRoles()
        {
            if (UsuarioCache.Position == Position.Administrador || UsuarioCache.Position == Position.Cajero){
                if (CajaCache.EstadoAperturaDeCaja=="Nuevo"){
                    //Mostrar Inicio de Sesion ...!!
                    ValidarEstadoDeSesion();
                    IIniciarSesionView.FormIniciarSesion.Dispose();
                    FrmAperturaDeCaja frmAperturaDeCaja = new FrmAperturaDeCaja();
                    frmAperturaDeCaja.ShowDialog();
                }else{
                    // Pasar Visor de Mesas aki faltaa ..!!!
                }
            }else{
                //Pasar Visor de Mesas aki faltaa ..!!! 
            }
        }

        public void ValidarEstadoDeSesion()
        {
            CajasModel.MostrarIdCajaSerial(Bases.Obtener_serialPC());
            int idEstadoSesion = InicioDeSesionModel.MostrarIdEstadoDeSesion(CajaCache.idCaja);
            if (idEstadoSesion > 0)
                InicioDeSesionModel.Update(new InicioDeSesionModel(UsuarioCache.idUsuario, idEstadoSesion));
            else
                InicioDeSesionModel.Add(new InicioDeSesionModel(CajaCache.idCaja, idEstadoSesion));
        }

        public void ValidarAperturaDeCaja() {
            MovimientoCajaModel.MovimientoDeCajaPorSerial(Bases.Obtener_serialPC());
            if (CajaCache.UsuarioInicioCaja != null){
                MovimientoCajaModel.MovimientoDeCajaPorIdUsuario(UsuarioCache.idUsuario, Bases.Obtener_serialPC());
                if (CajaCache.idMovimientoCaja == 0)
                {
                    if (UsuarioCache.Position == Position.Administrador)
                    {
                        MessageBox.Show("Todos los Registros seran con el Usuario: " + CajaCache.UsuarioInicioCaja + "* ,Inicia sesion con el Usuario " + CajaCache.UsuarioInicioCaja + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CajaCache.EstadoAperturaDeCaja = "Aperturada";
                        ValidarRoles();
                    }else
                        MessageBox.Show("Para poder continuar con el Turno de *" + CajaCache.UsuarioInicioCaja + "* ,Inicia sesion con el Usuario " + CajaCache.UsuarioInicioCaja + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else{
                    CajaCache.EstadoAperturaDeCaja = "Aperturada";
                    ValidarRoles();
                }
            }else
                ValidarCaja();
        }

        public void ValidarCaja()
        {
            CajasModel.MostrarIdCajaSerial(Bases.Obtener_serialPC());
            if (CajaCache.idCaja != 0)
            {
                MovimientoCajaModel.InsertarMovimientoDeCaja(CajaCache.idCaja, UsuarioCache.idUsuario);
                //AKI FALTA EDITAR MOVIMIENTO DE CAJA ..!!  editarIdmovCajaVentas();
                CajaCache.EstadoAperturaDeCaja = "Nuevo";
                ValidarRoles();
            }
        }

        private void DibujarUsuarios()
        {
            IIniciarSesionView.FlowPanelMostradorUsuario.Controls.Clear();

            foreach (var item in UsuariosModel.MostrarUsuarios())
            {
                Label lblNombreUsuario = new Label();
                Panel PnlContenedorUsuario = new Panel();
                PictureBox pbImagen = new PictureBox();

                lblNombreUsuario.Text = item.Login.ToString();
                lblNombreUsuario.Name = item.IdUsuario.ToString();
                lblNombreUsuario.Size = new Size(175, 25);
                lblNombreUsuario.Font = new Font("Microsoft Sans Serif", 13);
                lblNombreUsuario.BackColor = Color.Transparent;
                lblNombreUsuario.ForeColor = Color.White;
                lblNombreUsuario.Dock = DockStyle.Bottom;
                lblNombreUsuario.TextAlign = ContentAlignment.MiddleCenter;
                lblNombreUsuario.Cursor = Cursors.Hand;


                pbImagen.Size = new Size(155, 167);
                pbImagen.BorderStyle = BorderStyle.None;
                pbImagen.BackColor = Color.FromArgb(20, 20, 20);

                pbImagen.BackgroundImage = null;
                pbImagen.Image = ItemConverter.BinaryToImage(item.Icono);
                pbImagen.Dock = DockStyle.Fill;
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                pbImagen.Tag = item.Login.ToString();
                pbImagen.Cursor = Cursors.Hand;

                PnlContenedorUsuario.Controls.Add(lblNombreUsuario);
                PnlContenedorUsuario.Controls.Add(pbImagen);
                pbImagen.BringToFront();
                IIniciarSesionView.FlowPanelMostradorUsuario.Controls.Add(PnlContenedorUsuario);
                lblNombreUsuario.Click += EventoClickLabel;
                pbImagen.Click += EventoClickPictureBox;
            }
        }
        private void VerPanelContraseña()
        {
            IIniciarSesionView.PanelVisorUsuarios.Visible = false;
            IIniciarSesionView.PanelVisorContraseña.Visible = true;
            CentrarPanel(IIniciarSesionView.FormIniciarSesion, IIniciarSesionView.PanelVisorContraseña);
        }
        private void EventoClickPictureBox(object sender, EventArgs e)
        {
            IIniciarSesionView.usuario = ((PictureBox)sender).Tag.ToString();
            VerPanelContraseña();
        }
        private void EventoClickLabel(object sender, EventArgs e)
        {
            IIniciarSesionView.usuario = ((Label)sender).Text.ToString();
            VerPanelContraseña();
        }
        private void BotonBorrarAlaDerecha(object sender, EventArgs e)
        {
            int contador = IIniciarSesionView.contraseña.Count();
            if (contador > 0)
                IIniciarSesionView.contraseña = IIniciarSesionView.contraseña.Substring(0, IIniciarSesionView.contraseña.Count() - 1);
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void BotonBorrar(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña = string.Empty;
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton9(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "9";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton8(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "8";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton7(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "7";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton6(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "6";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton5(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "5";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton4(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "4";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton3(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "3";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton2(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "2";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton1(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "1";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }
        private void Boton0(object sender, EventArgs e)
        {
            IIniciarSesionView.contraseña += "0";
            IIniciarSesionView.TextBox.Text = IIniciarSesionView.contraseña;
            Console.Beep(2200, 1000);
        }

    }
}
