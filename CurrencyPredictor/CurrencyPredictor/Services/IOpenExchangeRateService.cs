using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Services
{
   public interface IOpenExchangeRateService
    {
        double GetPredictedCurrencyExchangeRate(string frCurrencyName, string toCurrencyName);
    }
}
