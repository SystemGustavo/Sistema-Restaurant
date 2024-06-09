using ControlesPersonalizados.Controles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Utils
{
    public abstract class ControlsGeneric
    {
        protected void ImagenClick(CCircularPictureBox cpbImagen)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (openFile.ShowDialog() == DialogResult.OK)
                    cpbImagen.Image = new Bitmap(openFile.FileName);
            }
        }

        protected void CentrarPanel(Form form, Panel Panel)
        {
            int panelX = (form.ClientSize.Width - Panel.Width) / 2;
            int panelY = (form.ClientSize.Height - Panel.Height) / 2;
            Panel.Location = new Point(panelX, panelY);
        }


    }
}
