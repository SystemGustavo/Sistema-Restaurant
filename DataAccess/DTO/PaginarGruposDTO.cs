using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PaginarGrupoProductosDTO
    {
        public int IdLine { get; set; }
        public string Grupo { get; set; }
        public byte[] Icono { get; set; }
        public string Estado_de_icono { get; set; }
        public string Estado { get; set; }
    }
}
