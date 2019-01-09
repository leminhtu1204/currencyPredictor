using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPredictor.Model
{
    public class CurrencyExchangeModel
    {
        public int TimeStamp { get; set; }
        public string Base { get; set; }

        public Dictionary<string, double> Rates { get; set; }
    }
}
