using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Permisos
    {
        public int IdPermiso { get; set; }
        public int IdModulo { get; set; }
        public int IdUsuario { get; set; }
        public Modulos modulos {get;set;}
        public Usuarios usuarios {get;set;}

    }
}
