using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class GrupoProductos
    {
        public int Idline { get; set; }
        public string Grupo { get; set; }
        public string Por_defecto { get; set; }
        public byte[] Icono { get; set; }
        public string Estado { get; set; }
        public string Estado_de_icono { get; set; }
        public int Idcolor { get; set; }
    }
}
