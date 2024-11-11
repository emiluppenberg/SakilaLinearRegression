namespace SakilaLinearRegression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                var array = new string[20, 20] {
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " },
                { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " }
            };

                //var xValues = new double[10] { 0, 3, 6, 10, 9, 11, 14, 17, 18, 19 };
                //var yValues = new double[10] { 19, 16, 3, 17, 10, 6, 9, 14, 2, 10 };

                var xValues = new double[5];
                var yValues = new double[5];

                for (int i = 0; i < xValues.Length; i++)
                {
                    Console.Write($"Enter X{i},Y{i}: ");
                    var input = Console.ReadLine();
                    var inputValues = input.Split(',');
                    xValues[i] = Convert.ToDouble(inputValues[0]);
                    yValues[i] = Convert.ToDouble(inputValues[1]);
                }

                Console.WriteLine(" ----------------------------------------------------------");

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
                                        array[i, j] = $" %{x} ";
                                        xValues[x] = 20;
                                        yValues[y] = 20;
                                    }
                                    else
                                    {
                                        array[i, j] = $" {x} ";
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
