using Budżecik.Dane;
using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.UI
{
    public static class Podsumowania
    {
        public static void Podsumowanie()
        {
            Console.WriteLine("1. Transakcje");
            Console.WriteLine("2. Limity wydatków");

            int wybór = UIHelper.PodajInt(1, 2);

            switch (wybór)
            {
                case 1:
                    PodsumowanieTransakcji();
                    break;
                case 2:
                    PodsumowanieLimitówWydatków();
                    break;
            }
        }

        private static void PodsumowanieTransakcji()
        {
            DateOnly? dataPoczątkowa = null;
            DateOnly? dataKońcowa = null;
            Kategoria kategoria = null;
            Osoba osoba = null;

            while (true)
            {
                Console.WriteLine("Wybierz zakres czasu:");
                Console.WriteLine("1. Nieograniczony");
                Console.WriteLine("2. Ten miesiąc");
                Console.WriteLine("3. Ten rok");
                Console.WriteLine("4. Poprzedni miesiąc");
                Console.WriteLine("5. Poprzedni rok");
                Console.WriteLine("6. Wybierz własny zakres");
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();

                switch (wybór)
                {
                    case "0":
                        return;
                    case "1":
                        break;
                    case "2":
                        dataPoczątkowa = DateHelper.PoczątekTegoMiesiąca;
                        dataKońcowa = DateHelper.KoniecTegoMiesiąca;
                        break;
                    case "3":
                        dataPoczątkowa = DateHelper.PoczątekTegoRoku;
                        dataKońcowa = DateHelper.KoniecTegoRoku;
                        break;
                    case "4":
                        dataPoczątkowa = DateHelper.PoczątekPoprzedniegoMiesiąca;
                        dataKońcowa = DateHelper.KoniecPoprzedniegoMiesiąca;
                        break;
                    case "5":
                        dataPoczątkowa = DateHelper.PoczątekPoprzedniegoRoku;
                        dataKońcowa = DateHelper.KoniecPoprzedniegoRoku;
                        break;
                    case "6":
                        dataPoczątkowa = UIHelper.PodajDatę("Podaj datę początkową");
                        dataKońcowa = UIHelper.PodajDatę("Podaj datę końcową");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        continue;
                }

                break;
            }

            while (true)
            {
                Console.WriteLine("Czy chcesz wybrać kategorię");
                Console.WriteLine("1. Tak - Wybierz kategorię");
                Console.WriteLine("2. Nie - Wszystkie kategorie");
                string wybór = Console.ReadLine();
                switch (wybór)
                {
                    case "1":
                        kategoria = UIHelper.WybierzZListy(Program.repozytoriumKategorii.Lista, "Wybierz kategorię:");
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        continue;
                }

                break;
            }

            while (true)
            {
                Console.WriteLine("Czy chcesz wybrać osobę");
                Console.WriteLine("1. Tak - Wybierz osobę");
                Console.WriteLine("2. Nie - Wszystkie osoby");
                string wybór = Console.ReadLine();
                switch (wybór)
                {
                    case "1":
                        osoba = UIHelper.WybierzZListy(Program.repozytoriumOsób.Lista, "Wybierz osobę:");
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        continue;
                }

                break;
            }

            List<Transakcja> transakcje = Program.repozytoriumTransakcji.Transakcje(dataPoczątkowa, dataKońcowa, kategoria, osoba).OrderByDescending(t => t.DataTransakcji).ToList();

            Console.WriteLine();
            float sumaTransakcji = RepozytoriumTransakcji.SumaTransakcji(transakcje).PrzeliczNaZłotówki();
            if (sumaTransakcji > 0)
            {
                Console.WriteLine("Suma: " + "+" + sumaTransakcji);
            }
            else
            {
                Console.WriteLine("Suma: " + sumaTransakcji);
            }
            Console.WriteLine();
            WyświetlTransakcje(transakcje);

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WyświetlTransakcje(List<Transakcja> transakcje)
        {
            Console.WriteLine("Kwota - Rodzaj transakcji, Kategoria, Osoba, Data");

            foreach (Transakcja transakcja in transakcje)
            {
                //Console.WriteLine($"{transakcja.KwotaWZłotych} - {transakcja.RodzajTransakcji}, {transakcja.Kategoria}, {transakcja.Osoba} {transakcja.DataTransakcji}");
                if (transakcja.RodzajTransakcji == RodzajeTransakcji.Przychód)
                {
                    Console.WriteLine($"+{transakcja.KwotaWZłotych} - {transakcja.Kategoria}, {transakcja.Osoba}, {transakcja.DataTransakcji}");
                }
                else if (transakcja.RodzajTransakcji == RodzajeTransakcji.Wydatek)
                {
                    Console.WriteLine($"-{transakcja.KwotaWZłotych} - {transakcja.Kategoria}, {transakcja.Osoba}, {transakcja.DataTransakcji}");
                }
            }
        }

        private static void PodsumowanieLimitówWydatków()
        {
            foreach (Kategoria kategoria in Program.repozytoriumKategorii.Lista)
            {
                if (kategoria.LimitWZłotych != null)
                {
                    int sumaWydatków = RepozytoriumTransakcji.SumaWydatków(Program.repozytoriumTransakcji.Transakcje(kategoria: kategoria));
                    Console.WriteLine($"{kategoria.NazwaKategorii} - {sumaWydatków.PrzeliczNaZłotówki()}/ {kategoria.LimitWZłotych}");
                }
            }

            Console.WriteLine();

            foreach (Osoba osoba in Program.repozytoriumOsób.Lista)
            {
                if (osoba.LimitWZłotych != null)
                {
                    int sumaWydatków = RepozytoriumTransakcji.SumaWydatków(Program.repozytoriumTransakcji.Transakcje(osoba: osoba));
                    Console.WriteLine($"{osoba.Imię} - {sumaWydatków.PrzeliczNaZłotówki()}/ {osoba.LimitWZłotych}");
                }
            }

            Console.WriteLine();
        }
    }
}
