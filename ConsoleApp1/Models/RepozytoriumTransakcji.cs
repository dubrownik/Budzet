using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    public class RepozytoriumTransakcji
    {
        private string ścieżka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Transakcje.csv");     //ścieżka przy debugowaniu: ConsoleApp1\bin\Debug\net6.0.Transakcje.csv

        public List<Transakcja> listaTransakcji { get; set; } = new List<Transakcja>();

        public int Saldo
        {
            get => SumaTransakcji(listaTransakcji);
        }

        public float SaldoWZłotówkach
        {
            get => (float)Saldo / 100;
        }

        public List<Transakcja> Transakcje(Kategoria kategoria = null)
        {
            var transakcje = listaTransakcji;

            if (kategoria != null)
            {
                transakcje = transakcje.Where(t => t.Kategoria == kategoria).ToList();
            }

            return transakcje;
        }
        public static int SumaTransakcji(List<Transakcja> transakcje)
        {
            int suma = 0;
            foreach (Transakcja t in transakcje)
            {
                if (t.RodzajTransakcji == RodzajeTransakcji.Przychód)
                {
                    suma += t.KwotaWGroszach;
                }
                else if (t.RodzajTransakcji == RodzajeTransakcji.Wydatek)
                {
                    suma -= t.KwotaWGroszach;
                }
            }

            return suma;
        }

        public void Dodaj(Transakcja transakcja)
        {
            listaTransakcji.Add(transakcja);
            ZapiszDoPliku();
        }

        public void Usuń(Transakcja transakcja)
        {
            listaTransakcji.Remove(transakcja);
            ZapiszDoPliku();
        }

        public void WczytajZPliku()
        {
            if (!File.Exists(ścieżka))
            {
                File.Create(ścieżka);
                return;
            }

            var FileLines = File.ReadLines(ścieżka);

            foreach (var line in FileLines)
            {
                string[] values = line.Split(',');
                Transakcja transakcja = new Transakcja()
                {
                    KwotaWGroszach = int.Parse(values[0]),
                    RodzajTransakcji = Enum.Parse<RodzajeTransakcji>(values[1]),
                    IndexKategorii = int.Parse(values[2])
            };

                listaTransakcji.Add(transakcja);
            }
        }

        public void ZapiszDoPliku()
        {
            List<string> doPliku = new List<string>();
            
            foreach (var transakcja in listaTransakcji)
            {
                string kwotaWGroszach = transakcja.KwotaWGroszach.ToString();
                string rodzajTransakcji = transakcja.RodzajTransakcji.ToString();
                string indexKategorii = transakcja.IndexKategorii.ToString();
                doPliku.Add($"{kwotaWGroszach},{rodzajTransakcji},{indexKategorii}");
            }

            File.WriteAllLines(ścieżka, doPliku);
        }
    }
}


