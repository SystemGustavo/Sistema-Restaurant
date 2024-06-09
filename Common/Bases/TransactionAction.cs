using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum TransactionAction
    {
        Add = 1,
        Edit = 2,
        Remove = 3,
        View = 4,
        Special = 5,
        Cancel= 6,
        Restore = 7
    }
}
