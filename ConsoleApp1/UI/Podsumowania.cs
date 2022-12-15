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
            DateOnly? dataPoczątkowa = null;
            DateOnly? dataKońcowa = null;
            Kategoria kategoria = null;

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

            List<Transakcja> transakcje = Program.repozytoriumTransakcji.Transakcje(dataPoczątkowa, dataKońcowa, kategoria).OrderByDescending(t => t.DataTransakcji).ToList();
            WyświetlTransakcje(transakcje);

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WyświetlTransakcje(List<Transakcja> transakcje)
        {
            Console.WriteLine();
            Console.WriteLine("Kwota - Rodzaj transakcji, Kategoria, Data");
            Console.WriteLine();
            foreach (Transakcja transakcja in transakcje)
            {
                Console.WriteLine($"{transakcja.KwotaWGroszach} - {transakcja.RodzajTransakcji}, {transakcja.Kategoria}, {transakcja.DataTransakcji}");
            }
        }
    }
}
