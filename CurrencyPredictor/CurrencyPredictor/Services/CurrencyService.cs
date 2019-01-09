using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Services
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyService()
        {

        }

        public double GetPredictedCurrencyExchangeRate(string frCurrencyName, string toCurrencyName)
        {
            var exchangeRate = ExchangeRateService.Instance;
            var result = exchangeRate.GetAllExchangeRate();

            double[] xValues = new double[result.Count];
            double[] yValues = new double[result.Count];

            for (int i = 0; i < result.Count; i++)
            {
                xValues[i] = i + 1;
                yValues[i] = result[i].Rates[toCurrencyName];
            }

            var predictedRate = this.LinearRegression(xValues, yValues, 2);
            return predictedRate;

        }

        private double LinearRegression(double[] xValues, double[] yValues, double xValue)
        {
            if (xValues.Length != yValues.Length)
            {
                Console.WriteLine("Input values should be with the same length.");
                throw new Exception();
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

            slobB = (N * sumXY - (sumX * sumY)) / ((N * sumXX) - sumXX);
            interceptA = (sumY - (slobB * sumX)) / N;

            return interceptA + slobB * xValue;
        }
    }
}
