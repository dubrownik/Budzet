using Budżecik.Dane;
using Budżecik.UI;
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

            MainMenu.Menu();
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
    }
}
