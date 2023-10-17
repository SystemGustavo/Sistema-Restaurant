using ControlesPersonalizados.Controles;
using System;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IUsuariosView
    {
        int IdUsuario { get; set; }
        string Nombre { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        byte[] Icon { get; set; }
        string Correo { get; set; }
        string Rol { get; set; }
        string Estado { get; set; }

        CDataGridView dgvPermisos { get; set; }
        CDataGridView DGVUsuarios{ get; set; }
        CCircularPictureBox Imagen { get; set; }
        Button AccionBoton { get; set; }
    
        TabPage PestañaListaDeUsuarios { get; set; }
        TabPage PestañaDetalleDeUsuarios { get; set; }
        TabControl TabControl { get; set; }
        string cbxRoles { get; set; }
        string buscarUsuario { get; set; }

        //Events
        event EventHandler EventAgregarNuevo;
        event EventHandler EventCancelar;
        event EventHandler EventAccion;
        event EventHandler EventEditar;
        event EventHandler EventEliminar;
        event EventHandler EventVerDetalles;
        event EventHandler EventSelectedIndexChanged;
        event EventHandler EventClickImagen;
        event EventHandler EventOnTextChanged;

        void SetUsuariosListBindingSource(BindingSource usuariosList);
        void SetModulosListBindingSource(BindingSource modulosList);
    }
}
