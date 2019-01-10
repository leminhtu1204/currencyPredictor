using CurrencyPredictor.Model;
using CurrencyPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Services
{
    public class FreeOpenExchangeService : IOpenExchangeRateService
    {
        public FreeOpenExchangeService()
        {

        }

        public double GetPredictedCurrencyExchangeRate(string frCurrencyName, string toCurrencyName)
        {
            var exchangeRates = this.GetCurrencyExchangeRates();

            var xValues = new double[exchangeRates.Count];
            var yValues = new double[exchangeRates.Count];

            for (int i = 0; i < exchangeRates.Count; i++)
            {
                xValues[i] = i + 1;
                yValues[i] = exchangeRates[i].Rates[toCurrencyName];
            }

            var predictedRate = LinearRegressionEquation.LinearRegression(xValues, yValues, 1);
            return predictedRate;
        }

        private List<CurrencyExchangeModel> GetCurrencyExchangeRates()
        {
            var exchangeRateInstance = ExchangeRateService.Instance;

            if (exchangeRateInstance == null)
            {
                Console.WriteLine("cannot init exchange rates data");
                throw new Exception();
            }

            var exchangeRates = exchangeRateInstance.GetAllExchangeRate();
            return exchangeRates;
        }
    }
}
