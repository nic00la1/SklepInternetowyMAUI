using SklepInternetowyMAUI.Classes;

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
    }
}
