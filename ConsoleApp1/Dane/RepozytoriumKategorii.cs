using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Models;

namespace Budżecik.Dane
{
    public class RepozytoriumKategorii : Repozytorium<Kategoria>
    {
        protected override string ścieżka { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kategorie.csv");     //ścieżka przy debugowaniu: ConsoleApp1\bin\Debug\net6.0.Kategorie.csv

        public List<Kategoria> Kategorie = new List<Kategoria>()
        {
            new Kategoria("Mieszkanie i rachunki"),
            new Kategoria("Transport"),
            new Kategoria("Jedzenie"),
            new Kategoria("Przychód"),
            new Kategoria("Inne")
        };
    }
}
