using SklepInternetowyMAUI.Classes;
using System.Threading.Tasks;

namespace SklepInternetowyMAUI
{
    public partial class MainPage : ContentPage
    {
        public List<Produkt> Produkty { get; set; }
        public MainPage()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("data_store.txt");
            Produkty = lines.Skip(1) // pomija nagłówek
                .Select(line =>
                {
                    var parts = line.Split(';');
                    return new Produkt
                    {
                        Id = int.Parse(parts[0]),
                        Nazwa = parts[1],
                        Obrazek = parts[2],
                        Cena = decimal.Parse(parts[3]),
                        Kategoria = parts[4],
                        DostepnaIlosc = int.Parse(parts[5]),
                    };
                })
                .ToList();

            BindingContext = this;
        }
        private async void OnZakupClicked(object sender, EventArgs e)
        {
            // Produkt powiązany z tym konkretnym przyciskiem do konkretnego produktu

            var produkt = (sender as Button)?.BindingContext as Produkt;

            if (produkt == null) return; // Jeśli nie ma takiego produktu 

            if (produkt.DostepnaIlosc > 0) // Jeśli liczba dostępnych sztuk produktu jest wieksza od zera
            {
                produkt.DostepnaIlosc--;
            }

            else 
            {
                await DisplayAlert("Brak produktu", $"Nie można kupić produktu {produkt.Nazwa}.",
                    "OK");
            }
        }

        private async void OnZwrocClicked(object sender, EventArgs e)
        {
            // Produkt powiązany z tym konkretnym przyciskiem do konkretnego produktu
            var produkt = (sender as Button)?.BindingContext as Produkt;

            produkt.DostepnaIlosc++;
        }
    }
}
