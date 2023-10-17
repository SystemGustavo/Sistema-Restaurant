using ControlesPersonalizados.Controles;
using Presentation.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmAperturaDeCaja : Form,IAperturaDeCajaView
    {
        public string Monto { get; set; }
        public Form FrmAperturaCaja { get => GetInstance(); set => throw new NotImplementedException(); }
        public Panel pnlCaja { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CTextBox TextBox { get=>txtMonto; set=>txtMonto=value; }

        public event EventHandler botonOmitir;
        public event EventHandler formAperturaCaja;
        public event KeyPressEventHandler TextBoxKeyPress;
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
        public event EventHandler botonIniciar;
        public event EventHandler TextBox_TextChanged;
        public FrmAperturaDeCaja()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }
        public void AssociateAndRaiseViewEvents()
        {
            txtMonto.KeyPress += (s, e) =>
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
                else if (e.KeyChar == '.' && (~txtMonto.Text.IndexOf(".")) != 0)
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
            };

            btnIniciar.Click += delegate
            {
                botonIniciar?.Invoke(this, EventArgs.Empty);
            };

            btnOmitir.Click += delegate
            {
                botonOmitir?.Invoke(this, EventArgs.Empty);
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
        private static FrmAperturaDeCaja instance;
        public static FrmAperturaDeCaja GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmAperturaDeCaja();
                instance.Show();
            }
            else
                instance.Show();

            return instance;
        }

    }


}
