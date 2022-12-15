using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Models;

namespace Budżecik.Dane
{
    public class RepozytoriumTransakcji : Repozytorium<Transakcja>
    {
        protected override string ścieżka { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Transakcje.csv");     //ścieżka przy debugowaniu: ConsoleApp1\bin\Debug\net6.0.Transakcje.csv

        public int ObliczSaldo() => SumaTransakcji(Lista);

        public float ObliczSaldoWZłotówkach() => (float)ObliczSaldo() / 100;

        public List<Transakcja> Transakcje(DateOnly? dataPoczątkowa = null, DateOnly? dataKońcowa = null, Kategoria kategoria = null)
        {
            var transakcje = Lista;

            if (dataPoczątkowa != null)
            {
                transakcje = transakcje.Where(t => t.DataTransakcji >= dataPoczątkowa).ToList();
            }
            if (dataKońcowa != null)
            {
                transakcje = transakcje.Where(t => t.DataTransakcji <= dataKońcowa).ToList();
            }
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
    }
}


