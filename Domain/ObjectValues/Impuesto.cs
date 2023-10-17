using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class Impuesto
    {
        public List<string> Impuestos()
        {
            List<string> listImpuesto = new List<string>();
            listImpuesto.Add("Igv");
            listImpuesto.Add("Iva");
            return listImpuesto;
        }

        public List<int> ValoresImpuestos()
        {
            List<int> listValoresImpuesto = new List<int>();
            listValoresImpuesto.Add(18);
            listValoresImpuesto.Add(21);
            listValoresImpuesto.Add(5);
            listValoresImpuesto.Add(4);
            return listValoresImpuesto;
        }
    }
}
