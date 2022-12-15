using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    public enum RodzajeTransakcji { Wydatek, Przychód };

    public class Transakcja : ISerializowalne
    {
        public int KwotaWGroszach { get; set; }
        public float KwotaWZłotych
        {
            get => KwotaWGroszach / 100;
            set => KwotaWGroszach = (int)(value * 100);
        }
        public RodzajeTransakcji RodzajTransakcji { get; set; }
        public DateOnly DataTransakcji { get; set; }

        public int IndexKategorii { get; set; } = -1;
        public Kategoria Kategoria
        {
            get => Program.repozytoriumKategorii.Kategorie[IndexKategorii];
        }

        public void Deserializuj(string linijka)
        {
            string[] values = linijka.Split(',');

            KwotaWGroszach = int.Parse(values[0]);
            RodzajTransakcji = Enum.Parse<RodzajeTransakcji>(values[1]);
            DataTransakcji = DateOnly.Parse(values[2]);
            IndexKategorii = int.Parse(values[3]);
        }

        public string Serializuj()
        {
            string kwotaWGroszach = KwotaWGroszach.ToString();
            string rodzajTransakcji = RodzajTransakcji.ToString();
            string dataTransakcji = DataTransakcji.ToString();
            string indexKategorii = IndexKategorii.ToString();
            return $"{kwotaWGroszach},{rodzajTransakcji},{dataTransakcji},{indexKategorii}";
        }
    }
}
