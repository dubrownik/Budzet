using Budżecik.Models;

namespace Budżecik
{
    public static class Program
    {
        public static RepozytoriumTransakcji repozytoriumTransakcji = new RepozytoriumTransakcji();

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

                string wybór = Console.ReadLine();

                if (wybór == "1")
                {
                    transakcja.RodzajTransakcji = RodzajeTransakcji.Wydatek;
                    break;
                }
                if (wybór == "2")
                {
                    transakcja.RodzajTransakcji = RodzajeTransakcji.Przychód;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                }
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
    }
}
