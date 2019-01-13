using CurrencyPredictor.Configuration;
using CurrencyPredictor.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor
{
    class Program
    {
        public Program()
        {

        }
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<IExchangeRateService, ExchangeRateService>(Lifestyle.Singleton);
            var service = container.GetInstance<FreeOpenExchangeService>();
            var baseCurrency = "USD";
            while (true)
            {
                try
                {
                    Console.WriteLine("Current base currency is +" + baseCurrency);
                    Console.WriteLine("Please input the target currency name");
                    string targetCurrencyStr = Console.ReadLine();
                    var predictedRate = service.GetPredictedCurrencyExchangeRate(baseCurrency, targetCurrencyStr);
                    Console.WriteLine("The predicted currency exchange from USD to " + targetCurrencyStr + " for 15/1/2017 is " + predictedRate);
                    Console.WriteLine("########################################################################");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}
