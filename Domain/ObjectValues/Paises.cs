using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class Paises
    {
        public string Pais { get; set; }
        public string Moneda { get; set; }

        public List<Paises> PaisesGetAll()
        {
            List<Paises> listPaises = new List<Paises>();
            listPaises.Add(new Paises { Pais = "<< Seleccione un Pais >>", Moneda = "" });
            listPaises.Add(new Paises { Pais = "Mexico", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Costa Rica", Moneda = "₡" });
            listPaises.Add(new Paises { Pais = "Guatemala", Moneda = "Q" });
            listPaises.Add(new Paises { Pais = "Honduras", Moneda = "L" });
            listPaises.Add(new Paises { Pais = "Nicaragua", Moneda = "C$" });
            listPaises.Add(new Paises { Pais = "Panamá", Moneda = "B/." });
            listPaises.Add(new Paises { Pais = "Cuba", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Puerto Rico", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "República Dominicana", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Argentina", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Bolivia", Moneda = "Bs." });
            listPaises.Add(new Paises { Pais = "Chile", Moneda = "$." });
            listPaises.Add(new Paises { Pais = "Colombia", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Ecuador", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Paraguay", Moneda = "₲" });
            listPaises.Add(new Paises { Pais = "Perú", Moneda = "S/." });
            listPaises.Add(new Paises { Pais = "Uruguay", Moneda = "$" });
            listPaises.Add(new Paises { Pais = "Venezuela", Moneda = "Bs F" });
            listPaises.Add(new Paises { Pais = "España", Moneda = "€" });
            return listPaises;
        }
    }
}
