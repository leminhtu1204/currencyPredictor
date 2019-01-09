using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Configuration
{
    public static class AppConfiguration
    {
        public static readonly string AppID = "7bc9569a17f54f1f85dc622d816a839b";

        public static string DefaultBaseCurrency = "USD";

        public static int PredictorPeriod = 12;

        public static DateTime startDate = new DateTime(2016, 01, 01);

        public static string GetAppUrlByDate(string date, string baseCurrency)
        {
            return string.Format("https://openexchangerates.org/api/historical/{0}.json?app_id={1}&base={2}&prettyprint=1", date, AppID, baseCurrency);
        }
    }
}
