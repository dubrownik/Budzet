using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Dane
{
    public class RepozytoriumOsób : Repozytorium<Osoba>
    {
        protected override string ścieżka { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Osoby.csv");
    }
}
