using Microsoft.EntityFrameworkCore;

namespace SakilaLinearRegression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SakilaDbContext();

            while (true)
            {
                Console.Clear();

                var array = new string[20, 10] {
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " }
            };

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine(" X: Cost per rental\n Y: Rental per cost");
                Console.Write(" Enter CustomerId: ");
                int customerIdInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                var payments = context.payment
                    .Where(p => p.customer_id == customerIdInput)
                    .ToList();

                var xValues = new double[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var yValues = new double[10];

                for (int i = 0; i < yValues.Length; i++)
                {
                    foreach (var p in payments)
                    {
                        if (i == 0 && p.amount == 0.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 1 && p.amount == 1.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 2 && p.amount == 2.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 3 && p.amount == 3.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 4 && p.amount == 4.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 5 && p.amount == 5.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 6 && p.amount == 6.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 7 && p.amount == 7.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 8 && p.amount == 8.99M)
                        {
                            yValues[i]++;
                        }
                        if (i == 9 && p.amount == 9.99M)
                        {
                            yValues[i]++;
                        }
                    }
                }

                var slope = LeastSquares(yValues, xValues);

                for (int i = 0; i < slope.Length; i++)
                {
                    array[Convert.ToInt32(slope[i]), Convert.ToInt32(xValues[i])] = " / ";
                }

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int x = 0; x < xValues.Length; x++)
                        {
                            for (int y = 0; y < yValues.Length; y++)
                            {
                                if (x == y && xValues[x] == j && yValues[y] == i)
                                {
                                    if (array[i, j] == " % ")
                                    {
                                        xValues[x] = 20;
                                        yValues[y] = 20;
                                    }
                                    if (array[i, j] == " / ")
                                    {
                                        array[i, j] = $" %{x+1} ";
                                        xValues[x] = 20;
                                        yValues[y] = 20;
                                    }
                                    else
                                    {
                                        array[i, j] = $" {x+1} ";
                                        xValues[x] = 20;
                                        yValues[y] = 20;
                                    }
                                }
                            }
                        }
                    }
                }

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
                        if (array[i, j] == " / ")
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
                        if (!int.TryParse(array[i, j], out int result2) && array[i, j] != " / ")
                        {
                            Console.Write(array[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($" X: Cost per rental\n Y: Rental per cost\n CustomerID: {customerIdInput}");

                Console.ReadKey();
            }
        }

        static double[] LeastSquares(double[] yValues, double[] xValues)
        {
            double xSigma = 0;

            foreach (var x in xValues)
            {
                xSigma += x;
            }

            double ySigma = 0;

            foreach (var y in yValues)
            {
                ySigma += y;
            }

            double xySigma = 0;

            for (int i = 0; i < xValues.Length; i++)
            {
                xySigma += xValues[i] * yValues[i];
            }

            double xSigmaSqr = 0;

            foreach (var x in xValues)
            {
                xSigmaSqr += x * x;
            }

            double n = xValues.Length;

            double m = ((n * xySigma) - (xSigma * ySigma)) / ((n * xSigmaSqr) - (xSigma * xSigma));

            double b = (ySigma - (m * xSigma)) / n;

            var slope = new double[xValues.Length];

            for (int i = 0; i < xValues.Length; i++)
            {
                slope[i] = (m * xValues[i]) + b;
                slope[i] = Math.Round(slope[i]);

                if (slope[i] > 19)
                {
                    slope[i] = 19;
                }
                if (slope[i] < 0)
                {
                    slope[i] = 0;
                }
            }

            return slope;
        }
    }
}
