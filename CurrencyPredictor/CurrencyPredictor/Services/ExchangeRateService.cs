using CurrencyPredictor.Configuration;
using CurrencyPredictor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Services
{
    public class ExchangeRateService: IExchangeRateService
    {
        private List<CurrencyExchangeModel> rates = new List<CurrencyExchangeModel>();
        public ExchangeRateService()
        {
            this.GetExchangeRatesByBaseCurrency();
        }

        public List<CurrencyExchangeModel> GetAllExchangeRate()
        {
            return this.rates;
        }

        private void GetExchangeRatesByBaseCurrency()
        {
            var date = AppConfiguration.startDate;
            var appId = AppConfiguration.AppID;
            var baseCurrency = AppConfiguration.DefaultBaseCurrency;
            var i = 0;

            while (i < AppConfiguration.PredictorPeriod)
            {
                var url = AppConfiguration.GetAppUrlByDate(date.AddMonths(i).ToString("yyyy-MM-dd"), baseCurrency);
                var result = this.GetCurrency(url).Result;

                if (result == null)
                {
                    this.rates = null;
                    break;
                }

                this.rates.Add(result);
                i++;
            }
        }

        private async Task<CurrencyExchangeModel> GetCurrency(string appUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(appUrl);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var result = responseMessage.Content.ReadAsStringAsync().Result;

                        var jsonObj = JsonConvert.DeserializeObject<CurrencyExchangeModel>(result);

                        return jsonObj;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
