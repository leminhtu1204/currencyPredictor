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
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please input the target currency name");
                    string str = Console.ReadLine();
                    CurrencyService service = new CurrencyService();
                    var predictedRate = service.GetPredictedCurrencyExchangeRate("", str);
                    Console.WriteLine("result is :" + predictedRate);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}
