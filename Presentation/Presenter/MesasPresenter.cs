using Domain.Models;
using Presentation.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Presenter
{
    public class MesasPresenter
    {
        private MesasModel MesasModel;
        private SalonesModel SalonesModel;
        private IDiseñoPrincipal IDiseñoPrincipal;

        public MesasPresenter(IDiseñoPrincipal _IDiseñoPrincipal,
                              MesasModel _MesasModel,
                              SalonesModel _SalonesModel)
        {
            MesasModel = _MesasModel;
            SalonesModel = _SalonesModel;
            IDiseñoPrincipal = _IDiseñoPrincipal;

            //Subscribe event handler methods to view events
            this.IDiseñoPrincipal.AgregarSalon += AgregarSalon;
         

           
            DibujarSalones();
        }

        private void AgregarSalon(object sender, EventArgs e)
        {
            //IDiseñoPrincipal.Form = new FrmSalones();
            //IDiseñoPrincipal.Form.StartPosition = FormStartPosition.CenterScreen;
            //IDiseñoPrincipal.Form.FormClosed += new FormClosedEventHandler(CerrarFormularioSalon);
            //IDiseñoPrincipal.Form.ShowDialog();
        }

        private void CerrarFormularioSalon(object sender, FormClosedEventArgs e)
        {
            DibujarSalones();
        }

        private void DibujarMesas()
        {
            //IDiseñoPrincipal.FPanelMesas.Controls.Clear();
            //foreach (var item in MesasModel.MostrarMesasPorSalones(Convert.ToInt32(IDiseñoPrincipal.idSalon)))
            //{

            //    IDiseñoPrincipal.Boton = new Button();
            //    IDiseñoPrincipal.Panel1 = new Panel();

            //    //IDiseñoPrincipal.Panel1.BackgroundImage = Properties.Resources.mesa_vacia;
            //    IDiseñoPrincipal.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            //    IDiseñoPrincipal.Panel1.Cursor = Cursors.Hand;
            //    IDiseñoPrincipal.Panel1.Size = new Size(120, 140);
            //    IDiseñoPrincipal.Boton.Size = new Size(120, 140);

            //    IDiseñoPrincipal.Boton.Text = item.Mesa.ToString();
            //    IDiseñoPrincipal.Boton.Name = item.IdMesa.ToString();

            //    if (IDiseñoPrincipal.Boton.Text != "NULO")
            //    {
            //        IDiseñoPrincipal.Boton.BackColor = Color.Transparent;
            //        IDiseñoPrincipal.Boton.BackgroundImage = Properties.Resources.verde;
            //        IDiseñoPrincipal.Boton.BackgroundImageLayout = ImageLayout.Zoom;
            //        IDiseñoPrincipal.Boton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //        IDiseñoPrincipal.Boton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            //        IDiseñoPrincipal.Boton.Font = new Font("Microsoft Sans Serif", 50);
            //        IDiseñoPrincipal.Boton.FlatStyle = FlatStyle.Flat;
            //        IDiseñoPrincipal.Boton.FlatAppearance.BorderSize = 0;
            //        IDiseñoPrincipal.Boton.ForeColor = Color.White;
            //        IDiseñoPrincipal.Panel1.Controls.Add(IDiseñoPrincipal.Boton);
            //        IDiseñoPrincipal.FPanelMesas.Controls.Add(IDiseñoPrincipal.Panel1);
            //    }
            //    //else
            //    //{

            //    }

            //}

        }

        private void miEvento(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DibujarSalones()
        {
            IDiseñoPrincipal.FPanelSalones.Controls.Clear();
            foreach (var item in SalonesModel.ListSalones())
            {
                IDiseñoPrincipal.Boton = new Button();
                IDiseñoPrincipal.Panel1 = new Panel();
                IDiseñoPrincipal.Panel2 = new Panel();

                IDiseñoPrincipal.Boton.Text = item.Salon.ToString();
                IDiseñoPrincipal.Boton.Name = item.IdSalon.ToString();
                IDiseñoPrincipal.Boton.Tag = item.Estado.ToString();
                IDiseñoPrincipal.Boton.Dock = DockStyle.Fill;
                IDiseñoPrincipal.Boton.BackColor = Color.Transparent;
                IDiseñoPrincipal.Boton.ForeColor = Color.White;
                IDiseñoPrincipal.Boton.Font = new Font("Microsoft Sans Serif", 12);
                IDiseñoPrincipal.Boton.FlatStyle = FlatStyle.Flat;
                IDiseñoPrincipal.Boton.FlatAppearance.BorderSize = 0;
                IDiseñoPrincipal.Boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                IDiseñoPrincipal.Boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);

                IDiseñoPrincipal.Boton.TextAlign = ContentAlignment.MiddleLeft;
                IDiseñoPrincipal.Boton.Tag = item.Estado.ToString();

                IDiseñoPrincipal.Panel1.Size = new Size(244, 58);
                IDiseñoPrincipal.Panel1.Name = item.IdSalon.ToString();

                IDiseñoPrincipal.Panel2.Size = new Size(3, 58);
                IDiseñoPrincipal.Panel2.Dock = DockStyle.Left;
                IDiseñoPrincipal.Panel2.BackColor = Color.Transparent;
                IDiseñoPrincipal.Panel2.Name = item.IdSalon.ToString();

                IDiseñoPrincipal.Panel1.Controls.Add(IDiseñoPrincipal.Boton);
                IDiseñoPrincipal.Panel1.Controls.Add(IDiseñoPrincipal.Panel2);
                IDiseñoPrincipal.FPanelSalones.Controls.Add(IDiseñoPrincipal.Panel1);


                IDiseñoPrincipal.Boton.BringToFront();
                IDiseñoPrincipal.Panel2.SendToBack();

                IDiseñoPrincipal.Boton.Click += new EventHandler(EventoBotonDinamico);
            }
        }

        private void EventoBotonDinamico(object sender, EventArgs e)
        {
            string nombre = ((Button)sender).Name;
            IDiseñoPrincipal.idSalon = ((Button)sender).Name;
            DibujarMesas();
            foreach (Control Panel1 in IDiseñoPrincipal.FPanelSalones.Controls)
            {
                if (Panel1 is Panel)
                {
                    foreach (Control Panel2 in Panel1.Controls)
                    {
                        if (Panel2 is Panel)
                        {
                            Panel1.BackColor = Color.Transparent;
                            Panel2.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            foreach (Control Panel1 in IDiseñoPrincipal.FPanelSalones.Controls)
            {
                if (Panel1 is Panel)
                {
                    foreach (Control Panel2 in Panel1.Controls)
                    {
                        if (Panel2 is Panel)
                        {
                            if (Panel2.Name == nombre)
                            {
                                Panel2.BackColor = Color.Orange;
                                Panel1.BackColor = Color.FromArgb(43, 43, 43);
                                break;
                            }
                        }
                    }
                }
            }

        }
    }
}
