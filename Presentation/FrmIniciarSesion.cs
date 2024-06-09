using ControlesPersonalizados.Controles;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmIniciarSesion : Form,IIniciarSesionView
    {
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public CTextBox TextBox { get => txtContraseña; set => txtContraseña=value; }
        public Panel PanelVisorUsuarios { get => PanelVisorDeUsuarios; set => PanelVisorDeUsuarios=value; }
        public Panel PanelVisorContraseña { get => PanelContraseña; set => PanelContraseña=value; }
        public Form FormIniciarSesion { get => this; set => FormIniciarSesion=value; }
        public FlowLayoutPanel FlowPanelMostradorUsuario { get => PanelMostradorUsuarios; set => PanelMostradorUsuarios=value; }

        public event EventHandler boton1;
        public event EventHandler boton2;
        public event EventHandler boton3;
        public event EventHandler boton4;
        public event EventHandler boton5;
        public event EventHandler boton6;
        public event EventHandler boton7;
        public event EventHandler boton8;
        public event EventHandler boton9;
        public event EventHandler boton0;
        public event EventHandler botonBorrar;
        public event EventHandler botonBorrarDerecha;
        public event EventHandler load;
        public event EventHandler botonIniciar;
        public event EventHandler TextBox_TextChanged;
        public event EventHandler botonCambiarDeUsuario;

        public FrmIniciarSesion()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }


        private void AssociateAndRaiseViewEvents()
        {
            btnIniciarSesion.Click += delegate
            {
                botonIniciar?.Invoke(this, EventArgs.Empty);
            };

            btnborrar.Click += delegate
            {
                botonBorrar?.Invoke(this, EventArgs.Empty);
            };

            btnborrarderecha.Click += delegate
            {
                botonBorrarDerecha?.Invoke(this, EventArgs.Empty);
            };

            btnCambiarUsuario.Click += delegate
            {
                botonCambiarDeUsuario?.Invoke(this, EventArgs.Empty);
            };

            this.Load += delegate
            {
                load?.Invoke(this, EventArgs.Empty);
            };

            txtContraseña.onTextChanged += (s, e) =>
            {
                TextBox_TextChanged?.Invoke(this, EventArgs.Empty);
            };


            //boton 1
            btn1.Click += delegate
            {
                boton1?.Invoke(this, EventArgs.Empty);
            };

            //boton 2
            btn2.Click += delegate
            {
                boton2?.Invoke(this, EventArgs.Empty);
            };

            //boton 3
            btn3.Click += delegate
            {
                boton3?.Invoke(this, EventArgs.Empty);
            };

            //boton 4
            btn4.Click += delegate
            {
                boton4?.Invoke(this, EventArgs.Empty);
            };

            //boton 5
            btn5.Click += delegate
            {
                boton5?.Invoke(this, EventArgs.Empty);
            };

            //boton 6
            btn6.Click += delegate
            {
                boton6?.Invoke(this, EventArgs.Empty);
            };

            //boton 7
            btn7.Click += delegate
            {
                boton7?.Invoke(this, EventArgs.Empty);
            };

            //boton 8
            btn8.Click += delegate
            {
                boton8?.Invoke(this, EventArgs.Empty);
            };

            //boton 9
            btn9.Click += delegate
            {
                boton9?.Invoke(this, EventArgs.Empty);
            };

            //boton 0
            btn0.Click += delegate
            {
                boton0?.Invoke(this, EventArgs.Empty);
            };


        }

        //Patron Singleton
        private static FrmIniciarSesion instance;
        public static FrmIniciarSesion GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmIniciarSesion();
                instance.Show();
            }
            else
                instance.Show();
            return instance;
        }
        
    }
}
