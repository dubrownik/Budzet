using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Models;

namespace Budżecik.Dane
{
    public class RepozytoriumKategorii
    {
        private string ścieżka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kategorie.csv");     //ścieżka przy debugowaniu: ConsoleApp1\bin\Debug\net6.0.Kategorie.csv

        public List<Kategoria> Kategorie = new List<Kategoria>()
        {
            new Kategoria("Mieszkanie i rachunki"),
            new Kategoria("Transport"),
            new Kategoria("Jedzenie"),
            new Kategoria("Przychód"),
            new Kategoria("Inne")
        };

        public void WczytajZPliku()
        {
            if (!File.Exists(ścieżka))
            {
                File.Create(ścieżka);
                return;
            }

            var FileLines = File.ReadLines(ścieżka).ToList();

            for (int i = 0; i < FileLines.Count(); i++)
            {
                string[] values = FileLines[i].Split(',');

                int? limitWGroszach = string.IsNullOrEmpty(values[1]) ? null : int.Parse(values[1]);

                Kategoria kategoria = new Kategoria()
                {
                    NazwaKategorii = values[0],
                    LimitWGroszach = limitWGroszach
                };

                Kategorie[i] = kategoria;
            }
        }

        public void ZapiszDoPliku()
        {
            List<string> doPliku = new List<string>();

            foreach (var kategoria in Kategorie)
            {
                string nazwaKategorii = kategoria.NazwaKategorii;
                int? limitWGroszach = kategoria.LimitWGroszach;
                doPliku.Add($"{nazwaKategorii},{limitWGroszach}");
            }

            File.WriteAllLines(ścieżka, doPliku);
        }
    }
}
