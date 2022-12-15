using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Models;
using System.Linq;

namespace Budżecik.Dane
{
    public class RepozytoriumKategorii : Repozytorium<Kategoria>
    {
        protected override string ścieżka { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kategorie.csv");     //ścieżka przy debugowaniu: ConsoleApp1\bin\Debug\net6.0.Kategorie.csv

        public RepozytoriumKategorii()
        {
            if (!Lista.Any())
            {
                Lista.Add(new Kategoria("Mieszkanie i rachunki"));
                Lista.Add(new Kategoria("Transport"));
                Lista.Add(new Kategoria("Jedzenie"));
                Lista.Add(new Kategoria("Przychód"));
                Lista.Add(new Kategoria("Inne"));
            }
        }
    }
}
