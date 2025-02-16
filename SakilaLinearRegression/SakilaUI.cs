
namespace SakilaLinearRegression
{
    internal class SakilaUI
    {
        public string Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Press 1 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Total rentals per film price\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Press 2 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Total rentals per film rating\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Press 0 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Exit program\n");
                Console.ForegroundColor = ConsoleColor.White;

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        return "per-cost";
                    case '2':
                        return "per-film-rating";
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("  Invalid input");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        internal int InputCustomerId()
        {
            while (true)
            {
                Console.Clear();

                Console.Write("  (Enter a number between 1-599) CustomerID: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (int.TryParse(Console.ReadLine(), out int customerId))
                {
                    if (customerId > 0 && customerId < 600)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        return customerId;
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("  Invalid input");
                Thread.Sleep(1000);
            }
        }
    }
}