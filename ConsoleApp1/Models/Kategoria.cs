using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budżecik.Dane;

namespace Budżecik.Models
{
    public class Kategoria : ISerializowalne
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
            if (RepozytoriumTransakcji.SumaTransakcji(Program.repozytoriumTransakcji.Transakcje(dataPoczątkowa: DateHelper.PoczątekTegoMiesiąca, kategoria: this)) < LimitWGroszach * -1)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return NazwaKategorii;
        }

        public string Serializuj()
        {
            return NazwaKategorii + "," + LimitWGroszach;
        }

        public void Deserializuj(string linijka)
        {
            string[] values = linijka.Split(',');

            int? limitWGroszach = string.IsNullOrEmpty(values[1]) ? null : int.Parse(values[1]);

            NazwaKategorii = values[0];
            LimitWGroszach = limitWGroszach;
        }
    }
}
