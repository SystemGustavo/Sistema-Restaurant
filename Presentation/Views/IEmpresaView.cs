using ControlesPersonalizados.Controles;
using Domain.Models;
using Domain.Repository;
using System;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IEmpresaView
    {
        string nombreEmpresa { get; set; }
        byte[] Logo { get; set; }
        string Impuesto { get; set; }
        double? Porcentaje_impuesto { get; set; }
        string Moneda { get; set; }
        string Trabajas_con_impuestos { get; set; }
        string Carpeta_para_copias_de_seguridad { get; set; }
        DateTime Ultima_fecha_de_copia_de_date { get; set; }
        string Pais { get; set; }
        string Tiponotas { get; set; }
        CCircularPictureBox imagen { get; set; }
        CPanel panelImpuesto { get; set; }
        CComboBox cbpaises { get; set; }
        CComboBox cbmonedas { get; set; }
        CComboBox cbImpuesto { get; set; }
        CComboBox cbImpuestoValue { get; set; }
        CRadioButton rbSi { get; set; }
        CRadioButton rbNo { get; set; }
        CRadioButton rbnotageneral { get; set; }
        CRadioButton rbnotapedido { get; set; }
        FolderBrowserDialog fbd { get; set; }

        event EventHandler FormLoad;
        event EventHandler cbPaisSelectedIndexChanged;
        event EventHandler rbSiCheckedChanged;
        event EventHandler rbNoCheckedChanged;
        event EventHandler btnAccionClick;
        event EventHandler EventClickImagen;
        event EventHandler EventLabelClick;
    }
}
