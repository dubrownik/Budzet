using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.UI
{
    public static class Kategorie
    {
        public static void ZarządzanieKategoriami()
        {
            while (true)
            {
                Console.WriteLine("1. Zmień limity wydatków");
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();

                if (wybór == "0")
                {
                    return;
                }
                else if (wybór == "1")
                {
                    ZmieńLimityWydatków();
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                }
            }
        }

        private static void ZmieńLimityWydatków()
        {
            WyświetlLimityTransakcji();
            Console.WriteLine();
            int indexKategorii = UIHelper.WybierzIndexZListy(Program.repozytoriumKategorii.Lista, "Wybierz kategorię");

            while (true)
            {
                try
                {
                    Program.repozytoriumKategorii.Lista[indexKategorii].LimitWZłotych = UIHelper.PodajFloat("Podaj kwotę", true, 0);
                    Program.repozytoriumKategorii.ZapiszDoPliku();
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

        private static void WyświetlLimityTransakcji()
        {
            Console.WriteLine("Limity wydatków:");
            foreach (var kategoria in Program.repozytoriumKategorii.Lista)
            {
                Console.WriteLine($"{kategoria.NazwaKategorii} - {kategoria.LimitWZłotych}");
            }
        }
    }
}
