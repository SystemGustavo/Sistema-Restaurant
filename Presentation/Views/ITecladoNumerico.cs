using ControlesPersonalizados.Controles;
using System;

namespace Presentation.Views
{
    public interface ITecladoNumerico
    {
        CTextBox TextBox { get; set; }

        event EventHandler boton1;
        event EventHandler boton2;
        event EventHandler boton3;
        event EventHandler boton4;
        event EventHandler boton5;
        event EventHandler boton6;
        event EventHandler boton7;
        event EventHandler boton8;
        event EventHandler boton9;
        event EventHandler boton0;
        event EventHandler botonBorrar;
        event EventHandler botonBorrarDerecha;
        event EventHandler botonIniciar;
        event EventHandler TextBox_TextChanged;
    }
}
