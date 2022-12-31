using Budżecik.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    public class Osoba : ISerializowalne
    {
        public Osoba() { }
        public Osoba(string imię)
        {
            Imię = imię;
        }

        public string Imię { get; set; }
        public int? LimitWGroszach { get; set; }
        public float? LimitWZłotych
        {
            get => LimitWGroszach / 100;
            set => LimitWGroszach = (int)(value * 100);
        }

        public void Deserializuj(string linijka)
        {
            string[] values = linijka.Split(',');

            int? limitWGroszach = string.IsNullOrEmpty(values[1]) ? null : int.Parse(values[1]);

            Imię = values[0];
            LimitWGroszach = limitWGroszach;
        }

        public string Serializuj()
        {
            return Imię + "," + LimitWGroszach;
        }


        public override string ToString()
        {
            return Imię;
        }

        public bool LimitPrzekroczony()
        {
            if (RepozytoriumTransakcji.SumaWydatków(Program.repozytoriumTransakcji.Transakcje(dataPoczątkowa: DateHelper.PoczątekTegoMiesiąca, osoba: this)) > LimitWGroszach)
            {
                return true;
            }

            return false;
        }
    }
}
