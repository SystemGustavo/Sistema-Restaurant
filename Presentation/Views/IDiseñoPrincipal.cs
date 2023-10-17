using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views
{
    public interface IDiseñoPrincipal:IDibujarMesas,IDibujarSalones
    {
        string idSalon { get; set; }
    }
}
