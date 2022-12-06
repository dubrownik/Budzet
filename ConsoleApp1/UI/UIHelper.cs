using System;
using System.Collections.Generic;
using System.Text;

namespace Budżecik.UI
{
    public static class UIHelper
    {
        public static T WybierzZListy<T>(List<T> lista, string napis = null)
        {
            int index = -1;
            while (true)
            {
                if (napis != null)
                    Console.WriteLine(napis);

                for (int i = 0; i < lista.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {lista[i].ToString()}");
                }
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();
                if (wybór == "0")
                {
                    MainMenu.Menu();
                }
                else if (int.TryParse(wybór, out int wybranaLiczba))
                {
                    index = wybranaLiczba - 1;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                if (index < 0 || index > lista.Count() - 1)
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                break;
            }

            return lista[index];
        }
        public static int WybierzIndexZListy<T>(List<T> lista, string napis = null)
        {
            int index = -1;
            while (true)
            {
                if (napis != null)
                    Console.WriteLine(napis);

                for (int i = 0; i < lista.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {lista[i].ToString()}");
                }
                Console.WriteLine("0. Powrót do menu");

                string wybór = Console.ReadLine();
                if (wybór == "0")
                {
                    MainMenu.Menu();
                }
                else if (int.TryParse(wybór, out int wybranaLiczba))
                {
                    index = wybranaLiczba - 1;
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                if (index < 0 || index > lista.Count() - 1)
                {
                    Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                    continue;
                }

                break;
            }

            return index;
        }


        public static DateOnly PodajDatę()
        {
            Console.WriteLine("Podaj datę");
            int dzień = PodajInt("Dzień:", false, 1, 36);
            int miesiąc = PodajInt("Miesiąc:", false, 1, 12);
            int rok = PodajInt("Rok:", false, 1950, 2100);
            return new DateOnly(rok, miesiąc, dzień);
        }


        public static int PodajInt()
        {
            int liczba = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out liczba))
                {
                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę całkowitą");
                }
            }
        }
        public static int PodajInt(int min, int? max = null)
        {
            int liczba = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out liczba))
                {
                    if (liczba < min)
                    {
                        Console.WriteLine($"Podaj większą od {min}");
                        continue;
                    }
                    if (max != null)
                    {
                        if (liczba > max)
                        {
                            Console.WriteLine($"Podaj mniejszą od {max}");
                            continue;
                        }
                    }

                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę");
                }
            }
        }
        public static int PodajInt(string napis, bool nastepnaLinia)
        {
            int liczba = 0;
            while (true)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                if (int.TryParse(Console.ReadLine(), out liczba))
                {
                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę całkowitą");
                }
            }
        }
        public static int PodajInt(string napis, bool nastepnaLinia, int? min = null, int? max = null)
        {
            int liczba = 0;
            while (true)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                if (int.TryParse(Console.ReadLine(), out liczba))
                {
                    if (min != null)
                    {
                        if (liczba < min)
                        {
                            Console.WriteLine($"Podaj większą od {min}");
                            continue;
                        }
                    }
                    if (max != null)
                    {
                        if (liczba > max)
                        {
                            Console.WriteLine($"Podaj mniejszą od {max}");
                            continue;
                        }
                    }

                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę");
                }
            }
        }


        public static float PodajFloat()
        {
            float liczba = 0;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out liczba))
                {
                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę całkowitą");
                }
            }
        }
        public static float PodajFloat(float min, float? max = null)
        {
            float liczba = 0;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out liczba))
                {
                    if (liczba < min)
                    {
                        Console.WriteLine($"Podaj większą od {min}");
                        continue;
                    }
                    if (max != null)
                    {
                        if (liczba > max)
                        {
                            Console.WriteLine($"Podaj mniejszą od {max}");
                            continue;
                        }
                    }

                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę");
                }
            }
        }
        public static float PodajFloat(string napis, bool nastepnaLinia)
        {
            float liczba = 0;
            while (true)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                if (float.TryParse(Console.ReadLine(), out liczba))
                {
                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę całkowitą");
                }
            }
        }
        public static float PodajFloat(string napis, bool nastepnaLinia, float? min = null, float? max = null)
        {
            float liczba = 0;
            while (true)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                if (float.TryParse(Console.ReadLine(), out liczba))
                {
                    if (min != null)
                    {
                        if (liczba < min)
                        {
                            Console.WriteLine($"Podaj większą od {min}");
                            continue;
                        }
                    }
                    if (max != null)
                    {
                        if (liczba > max)
                        {
                            Console.WriteLine($"Podaj mniejszą od {max}");
                            continue;
                        }
                    }

                    return liczba;
                }
                else
                {
                    Console.WriteLine("Podaj liczbę");
                }
            }
        }


        public static string PodajString()
        {
            string input = null;
            while (input == null || input.Count() == 0)
            {
                input = Console.ReadLine();
            }
            return input;
        }
        public static string PodajString(string napis, bool nastepnaLinia)
        {
            string input = null;
            while (input == null || input.Count() == 0)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                input = Console.ReadLine();
            }
            return input;
        }
        public static string PodajString(int min)
        {
            string input = null;
            while (input == null || input.Count() < min)
            {
                Console.WriteLine($"Wpisz wiecej niz {min} znakow");
                input = Console.ReadLine();
            }
            return input;
        }
        public static string PodajString(int min, string napis, bool nastepnaLinia)
        {
            string input = null;
            while (input == null || input.Count() < min)
            {
                if (nastepnaLinia)
                {
                    Console.WriteLine(napis);
                }
                else
                {
                    Console.Write(napis);
                }
                input = Console.ReadLine();

                if (input != null && input.Count() < min)
                {
                    Console.WriteLine($"Wpisz wiecej niz {min} znakow");
                }
            }
            return input;
        }
    }
}
