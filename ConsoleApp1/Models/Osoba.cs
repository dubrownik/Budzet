using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    public class Osoba : ISerializowalne
    {
        public string Imię { get; set; }

        public void Deserializuj(string linijka)
        {
            Imię = linijka;
        }

        public string Serializuj()
        {
            return Imię;
        }
    }
}
