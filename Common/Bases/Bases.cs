using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Common.Bases
{
    public class Bases
    {
        public static string Obtener_serialPC()
        {
            ManagementObject serialPC = new ManagementObject("Win32_PhysicalMedia='\\\\.\\PHYSICALDRIVE0'");
            string serial = serialPC.Properties["SerialNumber"].Value.ToString().Trim();
            return serial;
        }

    }
}
