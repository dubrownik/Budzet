using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik
{
    public static class MoneyHelper
    {
        public static float PrzeliczNaZłotówki(this int kwotaWGroszach)
        {
            return (float)kwotaWGroszach / 100;
        }

        public static int PrzeliczNaGrosze(this float kwotaWZłotych)
        {
            return (int)kwotaWZłotych * 100;
        }
    }
}
