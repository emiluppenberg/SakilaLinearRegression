
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
                Console.Write("Total rentals per cost\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Press 2 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Total rentals per film length\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  Press 3 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Total rentals per rating\n");
                Console.ForegroundColor = ConsoleColor.White;

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        return "per-cost";
                    case '2':
                        return "per-film-length";
                    case '3':
                        return "per-film-rating";
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

                Console.Write("  CustomerId: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return customerId;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("  Invalid input");
                Thread.Sleep(1000);
            }
        }
    }
}