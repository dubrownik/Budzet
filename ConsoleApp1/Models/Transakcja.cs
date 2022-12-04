using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    public enum RodzajeTransakcji {Wydatek, Przychód};

    public class Transakcja
    {
        public int KwotaWGroszach { get; set; }
        public float KwotaWZłotych
        {
            get => KwotaWGroszach / 100;
            set => KwotaWGroszach = (int)(value * 100);
        }
        public RodzajeTransakcji RodzajTransakcji { get; set; }

        public int IndexKategorii { get; set; } = -1;
        public Kategoria Kategoria
        {
            get => Program.repozytoriumKategorii.Kategorie[IndexKategorii];
        }
    }
}
