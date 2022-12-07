using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik
{
    public static class DateHelper
    {
        public static DateOnly PoczątekTegoMiesiąca
        {
            get => new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, DateOnly.FromDateTime(DateTime.Now).Month, 1);
        }

        public static DateOnly KoniecTegoMiesiąca
        {
            get
            {
                int rok = DateOnly.FromDateTime(DateTime.Now).Year;
                int miesiąc = DateOnly.FromDateTime(DateTime.Now).Month;
                return new DateOnly(rok, miesiąc, DateTime.DaysInMonth(rok, miesiąc));
            }
        }

        public static DateOnly PoczątekPoprzedniegoMiesiąca
        {
            get
            {
                DateOnly data = new DateOnly();
                if (DateTime.Now.Month != 1)
                {
                    data = new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, DateOnly.FromDateTime(DateTime.Now).Month - 1, 1);
                }
                else
                {
                    data = new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year - 1, 12, 1);
                }
                return data;
            }
        }

        public static DateOnly KoniecPoprzedniegoMiesiąca
        {
            get
            {
                DateOnly data = new DateOnly();
                int obecnyRok = DateOnly.FromDateTime(DateTime.Now).Year;
                int obecnyMiesiąc = DateOnly.FromDateTime(DateTime.Now).Month;
                if (DateTime.Now.Month != 1)
                {
                    data = new DateOnly(obecnyRok, obecnyMiesiąc - 1, DateTime.DaysInMonth(obecnyRok, obecnyMiesiąc - 1));
                }
                else
                {
                    data = new DateOnly(obecnyRok - 1, 12, DateTime.DaysInMonth(obecnyRok - 1, 12));
                }
                return data;
            }
        }


        public static DateOnly PoczątekTegoRoku
        {
            get => new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, 1, 1);
        }

        public static DateOnly KoniecTegoRoku
        {
            get
            {
                int rok = DateOnly.FromDateTime(DateTime.Now).Year;
                int miesiąc = DateOnly.FromDateTime(DateTime.Now).Month;
                return new DateOnly(rok, 12, 31);
            }
        }

        public static DateOnly PoczątekPoprzedniegoRoku
        {
            get => new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year - 1, 1, 1);
        }

        public static DateOnly KoniecPoprzedniegoRoku
        {
            get
            {
                int obecnyRok = DateOnly.FromDateTime(DateTime.Now).Year;
                int obecnyMiesiąc = DateOnly.FromDateTime(DateTime.Now).Month;
                return new DateOnly(obecnyRok - 1, 12, 31);
            }
        }
    }
}
