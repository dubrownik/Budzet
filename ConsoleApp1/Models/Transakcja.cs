using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.Models
{
    internal class Transakcja
    {
        public int KwotaWGroszach;

        public float KwotaWZłotych
        {
            get => KwotaWGroszach / 100;
            set => KwotaWGroszach = (int)value * 100;
        }
    }
}
