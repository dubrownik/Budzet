using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Dane
{
    public abstract class Repozytorium<T> where T : ISerializowalne, new()
    {
        protected abstract string ścieżka { get; set; }

        public List<T> Lista { get; set; } = new List<T>();

        public void Dodaj(T item)
        {
            Lista.Add(item);
            ZapiszDoPliku();
        }

        public void Usuń(T item)
        {
            Lista.Remove(item);
            ZapiszDoPliku();
        }

        public void WczytajZPliku()
        {
            if (!File.Exists(ścieżka))
            {
                File.Create(ścieżka);
                return;
            }

            var FileLines = File.ReadLines(ścieżka);

            foreach (var line in FileLines)
            {
                var nowaWartosc = new T();
                nowaWartosc.Deserializuj(line);
                Lista.Add(nowaWartosc);
            }
        }

        public void ZapiszDoPliku()
        {
            List<string> doPliku = new List<string>();

            foreach (var item in Lista)
            {
                item.Serializuj();
            }

            File.WriteAllLines(ścieżka, doPliku);
        }
    }
}
