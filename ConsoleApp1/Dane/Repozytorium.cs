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

        public List<T> lista { get; set; } = new List<T>();

        public void Dodaj(T item)
        {
            lista.Add(item);
            ZapiszDoPliku();
        }

        public void Usuń(T item)
        {
            lista.Remove(item);
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
                lista.Add(nowaWartosc);
            }
        }

        public void ZapiszDoPliku()
        {
            List<string> doPliku = new List<string>();

            foreach (var item in lista)
            {
                item.Serializuj();
            }

            File.WriteAllLines(ścieżka, doPliku);
        }
    }
}
