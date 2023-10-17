using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Utils
{
    /// <summary>
    /// Con esta clase estática puedes aclarar u oscurecer un color específico, basado en este ejemplo:
    /// <see cref="https://www.pvladov.com/2012/09/make-color-lighter-or-darker.html">Author: Pavel Vladov</see>/>
    /// </summary>
    /// <param name="color">"Un color para aclarar u oscurecer"</param>
    /// <param name="percentage">"El nivel para aclarar u oscurecer el color, el valor máximo es 100%"</param>
    /// <returns>Color</returns>
    ///
    public static class ColorEditor
    {
        public static Color Lighten(Color color, ushort percentage)
        {//Aclarar el color

            if (percentage <= 100) //el valor máximo es 100%
            {
                float correctionFactor = percentage / (float)100;//Convertir porcentaje a decimales

                float red = color.R; // Obtiene el componente rojo
                float green = color.G; // Obtiene el componente verde
                float blue = color.B; // Obtiene el componente azul

                red = (255 - red) * correctionFactor + red;//Establecer nuevo componente rojo
                green = (255 - green) * correctionFactor + green; //Establecer nuevo componente verde
                blue = (255 - blue) * correctionFactor + blue;//Establecer nuevo componente azul

                return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);//Devuelve el color aclarado
            }
            else
                return color;
        }
        public static Color Darken(Color color, ushort percentage)
        {//oscurecer el color

            if (percentage <= 100)
            {
                float correctionFactor = (percentage / (float)100) * -1;//Convertir el porcentaje en decimales negativos para producir colores oscuros
                correctionFactor = 1 + correctionFactor;//Sumar 1, ya que a veces sucede que el parámetro de color es negativo y arroja una excepción

                float red = color.R;
                float green = color.G;
                float blue = color.B;

                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;

                return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);//Devolver color oscurecido
            }
            else
                return color;
        }
    }
}
