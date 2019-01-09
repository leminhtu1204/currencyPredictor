using CurrencyPredictor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Services
{
    public interface IExchangeRateService
    {
        List<CurrencyExchangeModel> GetAllExchangeRate();
    }
}
