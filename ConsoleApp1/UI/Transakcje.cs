using Budżecik.Dane;
using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.UI
{
    public static class Transakcje
    {
        public static void WprowadźTransakcję()
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

            transakcja.IndexKategorii = UIHelper.WybierzIndexZListy(Program.repozytoriumKategorii.Lista, "Wybierz kategorię");
            transakcja.IndexOsoby = UIHelper.WybierzIndexZListy(Program.repozytoriumOsób.Lista, "Wybierz osobę");

            while (true)
            {
                Console.WriteLine("Wybierz datę transakcji");
                Console.WriteLine("1. Dzisiaj");
                Console.WriteLine("2. Podaj datę");
                Console.WriteLine("0. Powrót do menu");
                string wybór = Console.ReadLine();
                if (wybór == "0")
                {
                    return;
                }
                else if (wybór == "1")
                {
                    transakcja.DataTransakcji = DateOnly.FromDateTime(DateTime.Now);
                }
                else if (wybór == "2")
                {
                    transakcja.DataTransakcji = UIHelper.PodajPrzeszłąDatę("Podaj datę transakcji");
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                break;
            }

            transakcja.KwotaWZłotych = UIHelper.PodajFloat("Podaj kwotę:", true, 0);

            while (true)
            {
                try
                {
                    Program.repozytoriumTransakcji.Dodaj(transakcja);
                    break;
                }
                catch (IOException e)
                {
                    UIHelper.BłądPrzyZapisywaniuDanychDoPliku(e);
                }
            }

            if (transakcja.RodzajTransakcji == RodzajeTransakcji.Wydatek)
            {
                if (transakcja.Kategoria.LimitPrzekroczony())
                {
                    Console.WriteLine($"Limit wydatków kategorii {transakcja.Kategoria.NazwaKategorii} został przekroczony: {RepozytoriumTransakcji.SumaWydatków(Program.repozytoriumTransakcji.Transakcje(kategoria: transakcja.Kategoria)).PrzeliczNaZłotówki()}/ {transakcja.Kategoria.LimitWZłotych}");
                }
                if (transakcja.Osoba.LimitPrzekroczony())
                {
                    Console.WriteLine($"Limit wydatków osoby {transakcja.Osoba.Imię} został przekroczony: {RepozytoriumTransakcji.SumaWydatków(Program.repozytoriumTransakcji.Transakcje(osoba: transakcja.Osoba)).PrzeliczNaZłotówki()}/ {transakcja.Osoba.LimitWZłotych}");
                }
            }
        }

    }
}
