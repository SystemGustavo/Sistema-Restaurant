using ControlesPersonalizados.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public interface IEmpresaView
    {
        string notas { get; set; }
        CPanel panelImpuesto { get; set; }
        CComboBox cbpaises { get; set; }
        CComboBox cbmonedas { get; set; }
        CComboBox cbImpuesto { get; set; }
        CComboBox cbImpuestoValue { get; set; }
        CRadioButton rbSi { get; set; }
        CRadioButton rbNo { get; set; }
        CRadioButton rbnotageneral { get; set; }
        CRadioButton rbnotapedido { get; set; }
       
        event EventHandler FormLoad;
        event EventHandler cbPaisSelectedIndexChanged;
        event EventHandler rbSiCheckedChanged;
        event EventHandler rbNoCheckedChanged;
        event EventHandler tsbFolderClick;
        event EventHandler btnSiguienteClick;
    }
}
