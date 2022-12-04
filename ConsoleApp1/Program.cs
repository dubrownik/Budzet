using Budżecik.Models;
using System.Reflection.Metadata.Ecma335;

namespace Budżecik
{
    public static class Program
    {
        public static RepozytoriumTransakcji repozytoriumTransakcji = new RepozytoriumTransakcji();
        public static RepozytoriumKategorii repozytoriumKategorii = new RepozytoriumKategorii();

        public static void Main()
        {
            WczytajDaneZPlików();

            while (true)
            {
                Console.Write("Saldo: ");
                Console.WriteLine(repozytoriumTransakcji.SaldoWZłotówkach);
                
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Wprowadź transakcję");
                Console.WriteLine("2. Zarządzaj kategoriami");
                Console.WriteLine("3. Zarządzaj osobami");
                Console.WriteLine("4. Podsumowanie");
                Console.WriteLine("0. Koniec");
                string wybór = Console.ReadLine();

                switch (wybór)
                {
                    case "1":
                        WprowadźTransakcję();
                        break;
                    case "2":
                        ZarządzanieKategoriami();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        break;
                }
            }
        }

        private static void WprowadźTransakcję()
        {
            Transakcja transakcja = new Transakcja();

            while (true)
            {
                Console.WriteLine("Wybierz rodzaj transakcji");
                Console.WriteLine("1. Wydatek");
                Console.WriteLine("2. Przychód");
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();

                switch (wybór)
                {
                    case "0":
                        return;
                    case "1":
                        transakcja.RodzajTransakcji = RodzajeTransakcji.Wydatek;
                        break;
                    case "2":
                        transakcja.RodzajTransakcji = RodzajeTransakcji.Przychód;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        continue;
                }

                break;
            }

            int indexKategorii = -1;
            while (true)
            {
                Console.WriteLine("Wybierz kategorię");

                for (int i = 0; i < repozytoriumKategorii.Kategorie.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {repozytoriumKategorii.Kategorie[i].NazwaKategorii}");
                }
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();
                if (wybór == "0")
                {
                    return;
                }
                if (int.TryParse(wybór, out int wybranaLiczba))
                {
                    indexKategorii = wybranaLiczba - 1;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                if (indexKategorii < 0 || indexKategorii > repozytoriumKategorii.Kategorie.Count() - 1)
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                transakcja.IndexKategorii = indexKategorii;

                break;
            }

            while (true)
            {
                Console.WriteLine("Podaj kwotę:");
                string wpisanaKwota = Console.ReadLine();
                if (float.TryParse(wpisanaKwota, out float result) && result > 0)
                {
                    transakcja.KwotaWZłotych = result;
                    break;
                }
            }

            // TODO sprawdzanie, czy limity zostały przekroczone

            while (true)
            {
                try
                {
                    repozytoriumTransakcji.Dodaj(transakcja);
                    break;
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Błąd przy zapisywaniu danych do pliku: \n{e.Message}");
                    Console.WriteLine("1. Spróbuj ponownie");
                    Console.WriteLine("2. Wyjście do menu");
                    string wybór = Console.ReadLine();
                    if (wybór == "2")
                    {
                        return;
                    }
                }
            }
        }

        private static void WczytajDaneZPlików()
        {
            while (true)
            {
                try
                {
                    repozytoriumTransakcji.WczytajZPliku();
                    repozytoriumKategorii.WczytajZPliku();
                    break;
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Błąd przy wczytywaniu danych z pliku: \n{e.Message}");
                    Console.WriteLine("1. Spróbuj ponownie");
                    Console.WriteLine("2. Wyjście");
                    string wybór = Console.ReadLine();
                    if (wybór == "2")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void ZarządzanieKategoriami()
        {
            while (true)
            {
                Console.WriteLine("1. Zmień limity transakcji");
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();

                if (wybór == "0")
                {
                    return;
                }
                if (wybór == "1")
                {
                    ZmieńLimityKategorii();
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                }
            }
        }

        private static void ZmieńLimityKategorii()
        {
            int indexKategorii = -1;
            while (true)
            {
                Console.WriteLine("Wybierz kategorię");

                for (int i = 0; i < repozytoriumKategorii.Kategorie.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {repozytoriumKategorii.Kategorie[i].NazwaKategorii} - {repozytoriumKategorii.Kategorie[i].LimitWZotych}");
                }
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();
                if (wybór == "0")
                {
                    return;
                }
                if (int.TryParse(wybór, out int wybranaLiczba) )
                {
                    indexKategorii = wybranaLiczba - 1;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                if (indexKategorii < 0 || indexKategorii > repozytoriumKategorii.Kategorie.Count() - 1)
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.WriteLine("Podaj kwotę");
                string wpisanaKwota = Console.ReadLine();
                if (float.TryParse(wpisanaKwota, out float kwotaWZłotych))
                {
                    repozytoriumKategorii.Kategorie[indexKategorii].LimitWZotych = kwotaWZłotych;
                    repozytoriumKategorii.ZapiszDoPliku();
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                }
            }
        }
    }
}
