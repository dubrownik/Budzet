using Budżecik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budżecik.UI
{
    public static class MainMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.Write("Saldo: ");
                Console.WriteLine(Program.repozytoriumTransakcji.ObliczSaldoWZłotówkach());

                Console.WriteLine("Menu:");
                Console.WriteLine("1. Wprowadź transakcję");
                Console.WriteLine("2. Zarządzaj kategoriami");
                Console.WriteLine("3. Zarządzaj osobami");
                Console.WriteLine("4. Podsumowanie");
                Console.WriteLine("0. Koniec");
                string wybór = Console.ReadLine();

                switch (wybór)
                {
                    case "1":
                        Transakcje.WprowadźTransakcję();
                        break;
                    case "2":
                        Kategorie.ZarządzanieKategoriami();
                        break;
                    case "3":
                        break;
                    case "4":
                        Podsumowania.Podsumowanie();
                        break;
                    case "0":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        break;
                }
            }
        }
    }
}
