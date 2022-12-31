using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.UI
{
    public class Osoby
    {
        public static void ZarządzanieOsobami()
        {
            while (true)
            {
                Console.WriteLine("1. Dodaj osobę");
                Console.WriteLine("2. Zmień limity wydatków");
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();

                if (wybór == "0")
                {
                    return;
                }
                else if (wybór == "1") 
                {
                    DodajOsobę();
                }
                else if (wybór == "2")
                {
                    ZmieńLimityWydatków();
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                }
            }
        }

        public static void DodajOsobę()
        {
            Console.WriteLine("Podaj imię");
            string imię = UIHelper.PodajString();
            Osoba osoba = new Osoba(imię);
            while (true)
            {
                try
                {
                    Program.repozytoriumOsób.Dodaj(osoba);
                    break;
                }
                catch (IOException e)
                {
                    UIHelper.BłądPrzyWczytywaniuDanychZPliku(e);
                }
            }
        }

        public static void ZmieńLimityWydatków()
        {
            WyświetlLimityTransakcji();
            Console.WriteLine();

            int indexOsoby = UIHelper.WybierzIndexZListy<Osoba>(Program.repozytoriumOsób.Lista, "Wybierz osobę");
            while (true)
            {
                try
                {
                    Program.repozytoriumOsób.Lista[indexOsoby].LimitWZłotych = UIHelper.PodajFloat("Podaj kwotę", true, 0);
                    Program.repozytoriumOsób.ZapiszDoPliku();
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
            foreach (var osoba in Program.repozytoriumOsób.Lista)
            {
                Console.WriteLine($"{osoba.Imię} - {osoba.LimitWZłotych}");
            }
        }
    }
}
