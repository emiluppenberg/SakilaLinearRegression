


namespace SakilaLinearRegression
{
    internal class SakilaHelper
    {
        public double[] ValuesPerDataX<T>(List<T> customerRentals)
        {
            var groupedRentals = customerRentals
                .GroupBy(r => r)
                .ToDictionary(g => g.Key, g => g.Count());

            var xValues = new double[groupedRentals.Count];

            for (int i = 0; i < xValues.Length; i++)
            {
                xValues[i] = i + 1;
            }

            return xValues;
        }

        public double[] ValuesPerDataY<T>(List<T> customerRentals)
        {
            var dictionaryRentals = customerRentals
                .GroupBy(r => r)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            var listRentals = dictionaryRentals.ToList();
            var yValues = new double[listRentals.Count];

            for (int i = 0; i < yValues.Length; i++)
            {
                yValues[i] += listRentals[i].Value;
            }

            return yValues;
        }

        public string[,] CreateArray(int yValuesLength, int xValuesLength)
        {
            var array = new string[yValuesLength, xValuesLength];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = "  -  ";
                }
            }

            return array;
        }

        public double[] LeastSquares(double[] yValues, double[] xValues)
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

                if (slope[i] > slope.Length)
                {
                    slope[i] = slope.Length;
                }
                if (slope[i] < 0)
                {
                    slope[i] = 0;
                }
            }

            return slope;
        }

        public string StringRequest<T>(List<T> customerRentals)
        {
            var dictionaryRentals = customerRentals
                .GroupBy(r => r)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            var listRentals = dictionaryRentals.ToList();

            if (listRentals.Any(r => r.Key.GetType() == typeof(decimal)))
            {
                return string.Join(' ', listRentals.Select(
                    r => Convert.ToInt32(r.Key) > 9
                    ? $" {Convert.ToInt32(r.Key)}$".Replace(",99", "")
                    : $"  {Convert.ToInt32(r.Key)}$".Replace(",99", "")));
            }
            if (listRentals.Any(r => r.Key.GetType() == typeof(string)))
            {
                return string.Join(' ', listRentals.Select(
                    r => r.Key.ToString().Count() > 1
                    ? $" {r.Key.ToString().Replace("-", "")}"
                    : $"  {r.Key.ToString().Replace("-", "")}"));
            }
            else
            {
                throw new Exception();
            }
        }

    }
}