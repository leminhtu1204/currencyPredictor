using CurrencyPredictor.Configuration;
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
        private readonly IExchangeRateService exchangeRateService;
        public FreeOpenExchangeService(IExchangeRateService exchangeRateService)
        {
            this.exchangeRateService = exchangeRateService;
        }

        public double GetPredictedCurrencyExchangeRate(string frCurrencyName, string toCurrencyName)
        {
            var exchangeRates = exchangeRateService.GetAllExchangeRate();

            var xValues = new double[exchangeRates.Count];
            var yValues = new double[exchangeRates.Count];

            for (int i = 0; i < exchangeRates.Count; i++)
            {
                xValues[i] = i + 1;
                yValues[i] = exchangeRates[i].Rates[toCurrencyName];
            }

            var predictedRate = LinearRegressionEquation.LinearRegression(xValues, yValues, AppConfiguration.PredictorPeriod + 1); // 13 means 2017-1-1: need double check with requirement again
            return predictedRate;
        }
    }
}
