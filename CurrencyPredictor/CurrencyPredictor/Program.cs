using CurrencyPredictor.Configuration;
using CurrencyPredictor.Services;
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
            while (true)
            {
                try
                {
                    Console.WriteLine("Please input the target currency name");
                    string targetCurrencyStr = Console.ReadLine();
                    IOpenExchangeRateService service = new FreeOpenExchangeService();
                    var predictedRate = service.GetPredictedCurrencyExchangeRate("", targetCurrencyStr);
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
