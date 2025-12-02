using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepInternetowyMAUI.Classes
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Obrazek { get; set; }
        public decimal Cena { get; set; }
        public string Kategoria { get; set; }
        public int DostepnaIlosc { get; set; }
    }
}
