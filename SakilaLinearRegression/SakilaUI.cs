
namespace SakilaLinearRegression
{
    internal class SakilaUI
    {
        public string Menu(string[,] array)
        {
            while (true)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine(
                    "Press 1 - Total rentals per cost\n" +
                    "Press 2 - Total rentals per film length\n" +
                    "Press 3 - Total rentals per film rating\n");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        return "per cost";
                    case '2':
                        return "per film length";
                    case '3':
                        return "per film rating";
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        internal int InputCustomerId(string[,] array)
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.Write(" Enter CustomerId: ");

                if (int.TryParse(Console.ReadLine(), out int customerId))
                {
                    return customerId;
                }

                Console.Clear();
                Console.WriteLine("Invalid input");
                Thread.Sleep(1000);
            }
        }
    }
}