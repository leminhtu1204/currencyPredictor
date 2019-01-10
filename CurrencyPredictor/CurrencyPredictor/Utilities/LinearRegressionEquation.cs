using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Utilities
{
    public static class LinearRegressionEquation
    {
        public static double LinearRegression(double[] xValues, double[] yValues, double xValue)
        {
            if (xValues.Length == 0 || yValues.Length == 0)
            {
                throw new Exception("Invalid Input values");
            }

            if (xValues.Length != yValues.Length)
            {
                throw new Exception ("Input values should be with the same length.");
            }

            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXX = 0;
            double slobB = 0;
            double interceptA = 0;
            var N = xValues.Length;
            for (int i = 0; i < N; i++)
            {
                sumX += xValues[i];
                sumY += yValues[i];
                sumXY += xValues[i] * yValues[i];
                sumXX += xValues[i] * xValues[i];
            }

            slobB = ((N * sumXY) - (sumX * sumY)) / ((N * sumXX) - sumXX);
            interceptA = (sumY - (slobB * sumX)) / N;

            return interceptA + slobB * xValue;
        }
    }
}
