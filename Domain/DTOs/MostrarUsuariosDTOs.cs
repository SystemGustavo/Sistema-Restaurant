using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MostrarUsuariosDTOs
    {
        public int idUsuario { get; set; }
        public string Login { get; set; }
        public byte[] Icono { get; set; }
    }
}
