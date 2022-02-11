using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaklad_pracy
{
    class Pracownik
    {
        public Pracownik(int id, string daneosobowe, DateTime dataurodzenia, string stanowisko, decimal godzinowa, decimal pensja)
        {
            Id = id;
            Daneosobowe = daneosobowe;
            Dataurodzenia = dataurodzenia;
            Stanowisko = stanowisko;
            Godzinowa = godzinowa;
            Pensja = pensja;
        }
        public int Id { get; set; }
        public string Daneosobowe { get; set; }
        public DateTime Dataurodzenia { get; set; }
        public string Stanowisko { get; set; }
        public decimal Godzinowa { get; set; }
        public decimal Pensja { get; set; }
        public int Wiek
        {
            get { return DateTime.Now.Year - Dataurodzenia.Year; }
        }
        
        public static int LiczbaDni { get; set; }
        public static int Premia { get; set; }
        public decimal WynagrodzenieBrutto
        {
            get
            {
                if (Stanowisko is "pracownik fizyczny")
                    return Godzinowa * 8 * LiczbaDni + Premia;
                else
                    return Pensja + Premia;

            }
        }
        public decimal WynagrodzenieNetto
        {
            get
            {
                if (Stanowisko is "pracownik fizyczny")
                    return Godzinowa * 8 * LiczbaDni - Podatek + Premia;
                else
                    return Pensja - Podatek + Premia;
            }
        }
        public decimal Podatek
        {
            get { return Wiek <= 26 ? 0 : Math.Round (WynagrodzenieBrutto * 0.18m, 2); }
        }
    }
}
