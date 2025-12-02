using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SklepInternetowyMAUI.Classes
{
    public class Produkt : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Obrazek { get; set; }
        public decimal Cena { get; set; }
        public string Kategoria { get; set; }

        private int dostepnaIlosc;
        public int DostepnaIlosc
        {
            get => dostepnaIlosc;
            set
            {
                if (dostepnaIlosc != value)
                {
                    dostepnaIlosc = value;
                    OnPropertyChanged(nameof(DostepnaIlosc));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
