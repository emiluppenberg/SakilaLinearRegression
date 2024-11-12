


namespace SakilaLinearRegression
{
    internal class SakilaHelper
    {
        public double[] ValuesPerCostX(List<decimal> customerRentals)
        {
            var groupedRentals = customerRentals.GroupBy(r => r)
                .ToDictionary(g => g.Key, g => g.Count());

            var xValues = new double[groupedRentals.Count];

            for (int i = 0; i < xValues.Length; i++)
            {
                xValues[i] = i;
            }

            return xValues;
        }

        public double[] ValuesPerCostY(List<decimal> customerRentals)
        {
            var groupedRentals = customerRentals.GroupBy(r => r)
                .OrderBy(r => r)
                .ToDictionary(g => g.Key, g => g.Count());

            var yValues = new double[groupedRentals.Count];

            for (int i = 0; i < yValues.Length; i++)
            {
                for (int j = 0; j < groupedRentals.Count; j++)
                {
                    yValues[i] += groupedRentals[j];
                }
            }

            return yValues;
        }

        public double[] ValuesRequestX(List<decimal> customerRentals, string request)
        {
            switch (request)
            {
                case "per cost":
                    return ValuesPerCostX(customerRentals);
                default:
                    throw new Exception();
            }
        }

        public double[] ValuesRequestY(List<decimal> customerRentals, string request)
        {
            switch (request)
            {
                case "per cost":
                    return ValuesPerCostY(customerRentals);
                default:
                    throw new Exception();
            }
        }
    }
}