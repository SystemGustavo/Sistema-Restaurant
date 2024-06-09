using Common;
using Common.Bases;
using ControlesPersonalizados.Controles;
using Domain.Models;
using Presentation.Helpers;
using Presentation.Utils;
using Presentation.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class UsuariosPresenter
    {
        private readonly IUsuariosView IUsuariosView;
        private readonly UsuariosModel UsuariosModel;
        private readonly ModulosModel ModulosModel;
        private readonly CajasModel CajasModel;
        private readonly InicioDeSesionModel InicioDeSesionModel;
        private readonly PermisosModel PermisosModel;
        private readonly BindingSource usuariosBindingSource;
        private readonly BindingSource modulosBindingSource;
        private IEnumerable GetAllUsuarios;
        private IEnumerable GetAllModulos;
        private TransactionAction transaction { get; set; }
        private ColorsAction color { get; set; }
        private int IdUsuario { get; set; }
        private string LastRecord { get; set; }
        private Image defaultPhoto = Resource1.userProfile;

        public UsuariosPresenter(IUsuariosView iUsuariosView,
                                 UsuariosModel usuariosModel,
                                 ModulosModel modulosModel,
                                 PermisosModel permisosModel,
                                 InicioDeSesionModel iniciosesionModel,
                                 CajasModel cajasModel)
        {
            IUsuariosView = iUsuariosView;
            UsuariosModel = usuariosModel;
            PermisosModel = permisosModel;
            InicioDeSesionModel = iniciosesionModel;
            ModulosModel = modulosModel;
            CajasModel = cajasModel;
            usuariosBindingSource = new BindingSource();
            modulosBindingSource = new BindingSource();

            IUsuariosView.SetUsuariosListBindingSource(usuariosBindingSource);
            IUsuariosView.SetModulosListBindingSource(modulosBindingSource);
            IUsuariosView.EventAccion += btnAccion;
            IUsuariosView.EventCancelar += btnCancelar;
            IUsuariosView.EventAgregarNuevo += btnAgregarNuevo;
            IUsuariosView.EventEditar += btnEditar;
            IUsuariosView.EventEliminar += btnEliminar;
            IUsuariosView.EventVerDetalles += btnVerDetalles;
            IUsuariosView.EventClickImagen += pbImagen_Click;
            IUsuariosView.EventSelectedIndexChanged += cbxRol_OnSelectedIndexChanged;
            IUsuariosView.EventOnTextChanged += txtBuscarUsuario_OnTextChanged;
            IUsuariosView.EventKeyPressContraseña += txtContraseña_KeyPress;

            ListarUsuarios();
            ListarModulos();
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtBuscarUsuario_OnTextChanged(object sender, EventArgs e)
        {
            GetAllUsuarios = UsuariosModel.BuscarUsuarios(IUsuariosView.buscarUsuario);
            usuariosBindingSource.DataSource = GetAllUsuarios;
        }
        private void pbImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    IUsuariosView.Imagen.Image = new Bitmap(openFile.FileName);
                }
            }
        }
        private void btnCancelar(object sender, EventArgs e)
        {
            IUsuariosView.TabControl.TabPages.Remove(IUsuariosView.PestañaDetalleDeUsuarios);
            IUsuariosView.TabControl.TabPages.Add(IUsuariosView.PestañaListaDeUsuarios);
            IUsuariosView.PestañaDetalleDeUsuarios.Text = "ListaDeUsuarios";
            LimpiarControles();
        }
        private void cbxRol_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarRoles();
        }
        private UsuariosModel FillUsuariosModel()
        {
            UsuariosModel.Nombre = IUsuariosView.Nombre;
            UsuariosModel.Login = IUsuariosView.Login;
            UsuariosModel.Password = IUsuariosView.Password;
            if (IUsuariosView.Imagen.Image == defaultPhoto)
                UsuariosModel.Icono = null;
            else
                UsuariosModel.Icono = ItemConverter.ImageToBinary(IUsuariosView.Imagen.Image);
            UsuariosModel.Correo = IUsuariosView.Correo;
            UsuariosModel.Rol = IUsuariosView.Rol;
            return UsuariosModel;
        }
        private void btnAccion(object sender, EventArgs e)
        {
            try {
                UsuariosModel objUsuariosModel = new UsuariosModel();
                var objModeloDeUsuario = FillUsuariosModel();
                var objDataValidation = new DataValidation(objModeloDeUsuario);
                if (objDataValidation.Result){
                    switch (transaction)
                    {
                        case TransactionAction.Add:
                            objUsuariosModel.InsertarUsuario(objModeloDeUsuario);
                            IdUsuario = objUsuariosModel.ObtenerIdUsuario(objModeloDeUsuario.Login);
                            InsertarPermisos();
                            LastRecord = objModeloDeUsuario.Login;
                            MessageBox.Show("Usuario Registrado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case TransactionAction.Edit:
                            objUsuariosModel.ActualizarUsuario(objModeloDeUsuario);
                            PermisosModel.EliminarPermiso(IdUsuario);
                            InsertarPermisos();
                            LastRecord = objModeloDeUsuario.Login;
                            MessageBox.Show("Usuario Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case TransactionAction.Remove:
                            objUsuariosModel.EliminarUsuario(IdUsuario);
                            LastRecord = "";
                            MessageBox.Show("Usuario Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }else{
                    MessageBox.Show(objDataValidation.ErrorMessage, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch (Exception ex){
                LastRecord = null;
                var message = ExceptionManager.GetMessage(ex);
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertarPermisos()
        {
            List<PermisosModel> objListPermisos = new List<PermisosModel>();
            foreach (DataGridViewRow row in IUsuariosView.dgvPermisos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);
                if (marcado)
                {
                    objListPermisos.Add(new PermisosModel
                    {
                        IdModulo = idModulo,
                        IdUsuario = IdUsuario
                    });
                }
            }
            PermisosModel.AddRange(objListPermisos);
        }
        private void ValidarRoles()
        {
            int idCajaSerial = CajasModel.MostrarIdCajaSerial(Bases.Obtener_serialPC());
            int IdUsuarioSesion = InicioDeSesionModel.MostrarIdEstadoDeSesion(idCajaSerial);
            var ListMostrarPermisosDTO = PermisosModel.mostrarPermisos(IdUsuarioSesion);

            foreach (var item in ListMostrarPermisosDTO)
            {
                foreach (DataGridViewRow rowModulos in IUsuariosView.dgvPermisos.Rows)
                {
                    string modulo = (rowModulos.Cells["Modulo"].Value).ToString();
                    if (IUsuariosView.cbxRoles == "Cajero")
                    {
                        if (modulo == "Cobrar" || modulo == "Cerrar caja" || modulo == "Ingreso / Salida de dinero")
                        {
                            rowModulos.Cells[0].Value = true;
                            rowModulos.Cells[0].ReadOnly = true;
                        }
                        if (modulo == "Administrar")
                        {
                            rowModulos.Cells[0].Value = false;
                            rowModulos.Cells[0].ReadOnly = true;
                        }
                    }
                    if (IUsuariosView.cbxRoles == "Mozo")
                    {
                        if (modulo == "Para llevar" || modulo == "Ver cuentas" || modulo == "Cocina" || modulo == "Cambio de mesa")
                        {
                            rowModulos.Cells[0].Value = true;
                            rowModulos.Cells[0].ReadOnly = true;
                        }
                        if (modulo == "Administrar" || modulo == "Cobrar" || modulo == "Cerrar caja" || modulo == "Ingreso / Salida de dinero")
                        {
                            rowModulos.Cells[0].Value = false;
                            rowModulos.Cells[0].ReadOnly = true;
                        }
                    }
                    if (IUsuariosView.cbxRoles == "Administrador")
                    {
                        rowModulos.Cells[0].Value = true;
                        rowModulos.Cells[0].ReadOnly = true;
                    }
                }
            }
        }
        private void ListarModulos()
        {
            GetAllModulos = ModulosModel.GetAllModulos();
            modulosBindingSource.DataSource = GetAllModulos;
        }
        private void ListarUsuarios()
        {
            GetAllUsuarios= UsuariosModel.GetAllUsuarios();
            usuariosBindingSource.DataSource = GetAllUsuarios;
        }
        private void btnVerDetalles(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeshabilitarControles()
        {
            foreach (Control item in IUsuariosView.PestañaDetalleDeUsuarios.Controls)
            {
                if (item is CTextBox || item is CComboBox)
                {
                    item.Enabled = false;
                }
            }
        }
        private void HabilitarControles()
        {
            foreach (Control item in IUsuariosView.PestañaDetalleDeUsuarios.Controls)
            {
                if (item is CTextBox || item is CComboBox)
                {
                    item.Enabled = true;
                }
            }
        }
        private void LimpiarControles()
        {
            IUsuariosView.Nombre = String.Empty;
            IUsuariosView.Login = String.Empty;
            IUsuariosView.Password = String.Empty;
            IUsuariosView.Correo = String.Empty;
            IUsuariosView.Rol = String.Empty;
            IUsuariosView.Estado = String.Empty;
        }
        private void btnAgregarNuevo(object sender, EventArgs e)
        {
            transaction = TransactionAction.Add;
            string Accion = "Agregar Nuevo Usuario";
            color = ColorsAction.Verde;
            CambiarDePestaña(Accion);
            CambiarImagenBotonAccion();
            HabilitarControles();
            LimpiarControles();
        }
        private void btnEditar(object sender, EventArgs e)
        {
            transaction = TransactionAction.Edit;
            string Accion = "Editar Usuario";
            color = ColorsAction.Azul;
            CambiarDePestaña(Accion);
            CambiarImagenBotonAccion();
            PasarDatos_DatagridView_A_Controles();
            ValidarRoles();
            HabilitarControles();

        }
        private void btnEliminar(object sender, EventArgs e)
        {
            transaction = TransactionAction.Remove;
            string Accion = "Eliminar Usuario";
            color = ColorsAction.Rojo;
            CambiarDePestaña(Accion);
            CambiarImagenBotonAccion();
            PasarDatos_DatagridView_A_Controles();
            ValidarRoles();
            DeshabilitarControles();
        }
        private void PasarDatos_DatagridView_A_Controles()
        {
            if (IUsuariosView.DGVUsuarios.SelectedCells.Count > 1)
            {
                IdUsuario = Convert.ToInt32(IUsuariosView.DGVUsuarios.SelectedCells[0].Value);
                IUsuariosView.Nombre= IUsuariosView.DGVUsuarios.SelectedCells[1].Value.ToString();
                IUsuariosView.Login= IUsuariosView.DGVUsuarios.SelectedCells[2].Value.ToString();
                IUsuariosView.Password= IUsuariosView.DGVUsuarios.SelectedCells[3].Value.ToString();
                IUsuariosView.Correo= IUsuariosView.DGVUsuarios.SelectedCells[4].Value.ToString();
                IUsuariosView.Rol= IUsuariosView.DGVUsuarios.SelectedCells[5].Value.ToString();
                IUsuariosView.Estado= IUsuariosView.DGVUsuarios.SelectedCells[6].Value.ToString();
             }
        }
        private void CambiarDePestaña(string accion)
        {
            IUsuariosView.TabControl.TabPages.Remove(IUsuariosView.PestañaListaDeUsuarios);
            IUsuariosView.TabControl.TabPages.Add(IUsuariosView.PestañaDetalleDeUsuarios);
            IUsuariosView.PestañaDetalleDeUsuarios.Text = accion;
        }
        private void CambiarImagenBotonAccion()
        {
            switch (color)
            {
                case ColorsAction.Verde:
                    IUsuariosView.AccionBoton.BackgroundImage = Resource1.verde;
                    IUsuariosView.AccionBoton.Text = "Guardar";
                    break;
                case ColorsAction.Azul:
                    IUsuariosView.AccionBoton.BackgroundImage = Resource1.azul;
                    IUsuariosView.AccionBoton.Text = "Editar";
                    break;
               case ColorsAction.Rojo:
                    IUsuariosView.AccionBoton.BackgroundImage = Resource1.Rojo;
                    IUsuariosView.AccionBoton.Text = "Eliminar";
                    break;
            }
        }
    }
}
