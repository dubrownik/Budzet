namespace Budżecik
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Saldo: ");

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
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj jeszcze raz.");
                        break;
                }
            }
        }
    }
}
