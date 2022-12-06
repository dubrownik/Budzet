using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Dane;

namespace Budżecik.Models
{
    public class Kategoria
    {
        public Kategoria() { }
        public Kategoria(string nazwaKategorii)
        {
            NazwaKategorii = nazwaKategorii;
        }
        public string NazwaKategorii { get; set; }
        public int? LimitWGroszach { get; set; }

        public float? LimitWZotych
        {
            get => LimitWGroszach / 100;
            set => LimitWGroszach = (int)(value * 100);
        }

        public bool LimitPrzekroczony()
        {
            if (RepozytoriumTransakcji.SumaTransakcji(Program.repozytoriumTransakcji.Transakcje(kategoria: this)) < LimitWGroszach * -1)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return NazwaKategorii;
        }
    }
}
