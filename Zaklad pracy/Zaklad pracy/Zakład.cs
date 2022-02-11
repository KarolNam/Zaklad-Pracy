using System;
using System.Collections.Generic;

namespace Zaklad_pracy
{
    class Zakład
    {
        static void Main(string[] args)
        {
            Serwis serwis = new Serwis();
            while (true)
            {
                string wybor = PokazMenu();
                if (wybor == "1")
                {
                    PokazListePracownikow(serwis.Pracownicy);
                }
                else if (wybor == "2")
                {
                    Console.Clear();
                    Console.Write("PROSZĘ PODAĆ ID PRACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIE: ");
                    int numerpracownika = int.Parse(Console.ReadLine());
                    Pracownik pracownik = serwis.ZnajdzPracownika(numerpracownika);
                    if (pracownik == null)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("BRAK PRACOWNIKA O PODANYM ID");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("PROSZĘ PODAĆ ID PRACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIE: ");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        serwis.ZnajdzPracownika(numerpracownika);
                        Console.Clear();
                        Console.WriteLine("WYLICZANIE WYNAGRODZENIA PRACOWNIKA");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("DANE PRACOWNIKA: ");
                        Console.WriteLine($"IMIE I NAZWISKO: {pracownik.Daneosobowe}");
                        Console.WriteLine($"WIEK: {pracownik.Wiek} LAT");
                        Console.WriteLine($"STANOWISKO: {pracownik.Stanowisko}");
                        if (pracownik.Stanowisko is "pracownik fizyczny")
                        {
                            Console.WriteLine($"STAWKA GODZINOWA: {pracownik.Godzinowa}");
                        }
                        else
                        {
                            Console.WriteLine($"PENSJA STAŁA: {pracownik.Pensja}");
                        }
                        Console.Write("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX.20): ");
                        int liczbadni = int.Parse(Console.ReadLine());
                        Pracownik.LiczbaDni = liczbadni;
                        if (liczbadni < 20)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {pracownik.WynagrodzenieBrutto * 0.8m} zł");
                            if (pracownik.Wiek < 26)
                            {
                                Console.WriteLine("BRAK PODATKU");
                            }
                            else
                            {
                                Console.WriteLine($"POTRĄCONY PODATEK (18%): {pracownik.Podatek} zł");
                            }
                            Console.WriteLine($"DO WYPŁATY: {pracownik.WynagrodzenieNetto * 0.8m} zł");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(1); ;
                        }
                        else
                            Console.Clear();
                            Console.Write("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA: ");
                        int premia = int.Parse(Console.ReadLine());
                        Pracownik.Premia = premia;
                        if (premia < 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NIEPRAWIDŁOWE DANE. NIE MOŻNA WYLICZYĆ WYNAGRODZENIA");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {pracownik.WynagrodzenieBrutto} zł");
                            if (pracownik.Wiek < 26)
                            {
                            Console.WriteLine("BRAK PODATKU");
                            }
                            else
                            {
                            Console.WriteLine($"POTRĄCONY PODATEK (18%): {pracownik.Podatek} zł");
                            }
                            Console.WriteLine($"DO WYPŁATY: {pracownik.WynagrodzenieNetto} zł");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(1);
                    }

                }
                else
                    return;
            }
        }
        static void PokazListePracownikow(List<Pracownik> Pracownicy)
        {
            Console.Clear();
            Console.WriteLine("ID | IMIĘ I NAZWISKO | DATA UR. | STANOWISKO");
            foreach (var pracownik in Pracownicy)
            {
                Console.WriteLine($"{pracownik.Id} | {pracownik.Daneosobowe} | {pracownik.Dataurodzenia.ToShortDateString()} | {pracownik.Stanowisko}");
            }
        }

        static string PokazMenu()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.Write("WYBIERZ 1, 2 LUB 3:");
            return Console.ReadLine();
        }
    }
}

