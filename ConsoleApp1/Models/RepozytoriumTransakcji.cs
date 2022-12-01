using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    internal class RepozytoriumTransakcji
    {
        public string Ścieżka = "C:\\Users\\Karolina Aleksandra\\Downloads\\RejestrOsobK26\\Plik.csv";
        // TODO: poprawić ścieżkę


        private List<Transakcja> listaTransakcji = new List<Transakcja>();



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
            var FileLines = File.ReadLines(Ścieżka);

            foreach (var line in FileLines)
            {
                Transakcja transakcja = new Transakcja()
                {
                    // TODO: Dodaj nowe rzeczy do pliku i obsługa błędów
                    KwotaWGroszach = int.Parse(line) 
                };

                listaTransakcji.Add(transakcja);
            }
        }

        public void ZapiszDoPliku()
        {
            List<string> doPliku = new List<string>();
            
            foreach (var transakcja in listaTransakcji)
            {
                string WhateverIDontCareLegit = transakcja.KwotaWGroszach.ToString();
                doPliku.Add(WhateverIDontCareLegit);
            }

            File.WriteAllLines(Ścieżka, doPliku);
        }
    }
}


