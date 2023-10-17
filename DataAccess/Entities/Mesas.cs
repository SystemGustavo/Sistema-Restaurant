using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Mesas
    {
        public int IdMesa { get; set; }
        public string Mesa { get; set; }
        public int IdSalon { get; set; }
        public string EstadoVida { get; set; }
        public string EstadoDisponibilidad { get; set; }

        public Salones Salon { get; set; }
    }
}
