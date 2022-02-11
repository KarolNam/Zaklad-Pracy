using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaklad_pracy
{
    class Serwis
    {
        public Serwis()
        {
            UtworzPracownikow();
        }
        private void UtworzPracownikow()
        {
            Pracownicy = new List<Pracownik>();
            Pracownicy.Add(new Pracownik(1, "Jan Nowak", new DateTime(2002, 3, 4), "pracownik fizyczny", 18.5m, 0));
            Pracownicy.Add(new Pracownik(2, "Agnieszka Kowalska", new DateTime(1973, 12, 15), "urzędnik", 0, 2800));
            Pracownicy.Add(new Pracownik(3, "Robert Lewandowski", new DateTime(1980, 5, 23), "pracownik fizyczny", 29.0m, 0));
            Pracownicy.Add(new Pracownik(4, "Zofia Plucińska", new DateTime(1998, 11, 2), "urzędnik", 0, 4750));
            Pracownicy.Add(new Pracownik(5, "Grzegorz Braun", new DateTime(1960, 1, 29), "pracownik fizyczny", 48.0m, 0));
        }
        public List<Pracownik> Pracownicy { get; set; }
        public Pracownik aktualny { get; set; }
        public Pracownik ZnajdzPracownika(int id)
        {
            var pracownik = Pracownicy.FirstOrDefault(p => p.Id == id);
            if (pracownik != null)
            {
                aktualny = pracownik;
                return pracownik;
            }
            else
                return null;

        }
    }
}
