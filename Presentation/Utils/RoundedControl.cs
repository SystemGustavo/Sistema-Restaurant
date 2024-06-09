using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Utils
{
    public class RoundedControl
    {
        /// <summary>
        /// Esta clase estática se encarga de hacer controles con esquinas redondeados.
        /// Tiene 3 manera de hacerlo:
        /// -Aplicar el borde de radio solo a la Region del control.
        /// -Aplicar el borde de radio Region del control + Suavizado de contorno.
        /// -Aplicar el borde de radio Region del control + Suavizado de contorno + Dibujo de borde.
        /// </summary>
        ///

        #region -> Métodos públicos
        public static GraphicsPath GetRoundedGPath(Rectangle rect, float radius)
        {//Este método se encarga de crear la ruta redondeada de un rectangulo y radio especificado.
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        //REGION REDONDEADO
        public static void RegionOnly(Control control, int radius)
        {//Este método se encarga de aplicar una region redondeada a un control y radio especificado.
            //Las esquinas redondeadas no son suaves.

            if (radius >= 1) //Aplicar radio de borde (CONTROL REDONDEADO)
            {
                using (GraphicsPath roundPath = GetRoundedGPath(control.ClientRectangle, radius))//Obtener ruta de figura con esquinas redondeadas.
                {
                    control.Region = new Region(roundPath);//Aplicar ruta redondeada como nueva región.
                }
                control.Resize += (s, e) => //Si el control cambia de tamaño, actualizar la region redondeada.
                {
                    using (GraphicsPath newRoundPath = GetRoundedGPath(control.ClientRectangle, radius))
                    {
                        control.Region = new Region(newRoundPath);
                    }
                };
            }
            else //No aplicar radio de borde (CONTROL RECTANGULAR)
            {
                //Restablecer la region
                control.Region = new Region(control.ClientRectangle);
                control.Resize += (s, e) =>
                {
                    control.Region = new Region(control.ClientRectangle);
                };
            }

        }

        //REGION REDONDEADO + SUAVIZADO DE CONTORNO
        public static void RegionAndSmoothed(Control control, int radius, Graphics graph)
        {//Este método se encarga de aplicar una region redondeada y suavizar el contorno del control
            //para obtener esquinas redondeadas de alta calidad con borde suaves (No pixeleado).
            //Use este metodo desde el evento Paint del control.

            if (radius > 1)//Aplicar radio de borde (CONTROL REDONDEADO)
            {
                using (GraphicsPath roundPath = GetRoundedGPath(control.ClientRectangle, radius))//Obtener ruta de figura con esquinas redondeadas.
                using (Pen penSmoothing = new Pen(control.Parent.BackColor, 1))//Boligrafo para el suavizado del contorno, el color debe ser igual al color de fondo de su contenedor.
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    control.Region = new Region(roundPath);//Aplicar ruta redondeada como nueva región.
                    graph.DrawPath(penSmoothing, roundPath);//Dibujar la ruta redondeada para suavizar el contorno del control.
                }
            }
            else//No aplicar radio de borde (CONTROL RECTANGULAR)
            {
                control.Region = new Region(control.ClientRectangle);//Restablecer la region.
            }
        }

        //REGION REDONDEADO + SUAVIZADO DE CONTORNO + DIBUJO DE BORDE
        public static void RegionAndBorder(Control control, int radius, Graphics graph, Color borderColor, float borderSize)
        {//Este método se encarga de aplicar una region redondeada y suavizar el contorno del control 
            //para obtener esquinas redondeadas de alta calidad con borde suaves (No pixeleado), ademas de dibujar el borde del control.
            //Use este metodo desde el evento Paint del control.

            if (radius > 1)//Aplicar radio de borde (CONTROL REDONDEADO)
            {
                using (GraphicsPath roundPath = GetRoundedGPath(control.ClientRectangle, radius))//Obtener ruta de figura con esquinas redondeadas.
                using (Pen penSmoothing = new Pen(control.Parent.BackColor, borderSize + 1))//Boligrafo para el suavizado del contorno, el color debe ser igual al color de fondo de su contenedor.
                using (Pen penBorder = new Pen(borderColor, borderSize))//Boligrafo para dibujar el borde del control
                using (Matrix transform = new Matrix())//Matriz para escalar el objeto del grafico y dibujar el borde.
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    control.Region = new Region(roundPath);//Aplicar ruta redondeada como nueva región.
                    graph.DrawPath(penSmoothing, roundPath);//Dibujar la ruta redondeada para suavizar el contorno del control.

                    //Dibujar el borde redondeado del control.
                    //Para este proposito es necesario escalar las dimensiones de la ruta dentro del dibujo del suavizado anterior.
                    if (borderSize >= 1)
                    {
                        Rectangle rect = control.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;//Aplicar el escalado al objeto de graficos.
                        graph.DrawPath(penBorder, roundPath);//Dibujar el borde del control.
                    }
                }
            }
            else//No aplicar radio de borde (CONTROL RECTANGULAR)
            {
                control.Region = new Region(control.ClientRectangle);//Restablecer la region.
                if (borderSize >= 1)//Dibujar borde rectangular
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        graph.DrawRectangle(penBorder, 0, 0, control.Width - 0.5F, control.Height - 0.5F);
                    }
                }
            }
        }
        #endregion
    }
}
