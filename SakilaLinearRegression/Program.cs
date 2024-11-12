using Microsoft.EntityFrameworkCore;

namespace SakilaLinearRegression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SakilaDbContext();
            var ui = new SakilaUI();
            var helper = new SakilaHelper();

            while (true)
            {
                string request = ui.Menu();

                int customerId = ui.InputCustomerId();

                double[] xValues;
                double[] yValues;

                if (request == "per-cost")
                {
                    var customerRentals = context.DataPerCost(customerId);
                    xValues = helper.ValuesPerCostX(customerRentals);
                    yValues = helper.ValuesPerCostY(customerRentals);
                    var dictionaryRentals = customerRentals
                        .GroupBy(r => r)
                        .OrderBy(g => g.Key)
                        .ToDictionary(g => g.Key, g => g.Count());

                    int ySize = dictionaryRentals.Max(r => r.Value);
                    string[,] array = helper.CreateArray(ySize, xValues.Length);

                    var slope = helper.LeastSquares(yValues, xValues);

                    for (int i = 0; i < slope.Length; i++)
                    {
                        array[(array.GetLength(0) - 1) - Convert.ToInt32(slope[i]), Convert.ToInt32(xValues[i]) - 1] = "  /  ";
                    }

                    // Write data to array
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            for (int x = 0; x < xValues.Length; x++)
                            {
                                for (int y = 0; y < yValues.Length; y++)
                                {
                                    if (x == y && xValues[x] - 1 == j && yValues[y] == array.GetLength(0) - i)
                                    {
                                        if (array[i, j].Contains('%'))
                                        {
                                            xValues[x] = xValues.Length + 1;
                                            yValues[y] = yValues.Length + 1;
                                        }
                                        if (array[i, j].Contains('/'))
                                        {
                                            array[i, j] = $"  %{yValues[y]}  ";
                                            xValues[x] = xValues.Length + 1;
                                            yValues[y] = yValues.Length + 1;
                                        }
                                        else
                                        {
                                            array[i, j] = $"  {yValues[y]}  ";
                                            if (yValues[y] > 9)
                                            {
                                                array[i, j] = $"  {yValues[y]} ";
                                            }
                                            xValues[x] = xValues.Length + 1;
                                            yValues[y] = yValues.Length + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Display array
                    Console.WriteLine("\n  X: Cost per rental\n  Y: Rentals per cost");
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (int.TryParse(array[i, j], out int result1))
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(array[i, j]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (array[i, j].Contains('/'))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(array[i, j]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (array[i, j].Contains('%'))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                array[i, j] = array[i, j].Replace("%", "");
                                Console.Write(array[i, j]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (!int.TryParse(array[i, j], out int result2) && !array[i, j].Contains('/'))
                            {
                                Console.Write(array[i, j]);
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(helper.StringRequest(customerRentals));

                }
                if (request == "per-film-length")
                {
                }
                else
                {
                }


                Console.ReadKey();
            }
        }
    }
}
