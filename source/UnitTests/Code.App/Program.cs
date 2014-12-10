using NetRate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var rate = new NetExchangeRate();
            var _currencyExchange = new CurrencyExchange(rate);
            var from = "EUR";
            var to = "RUR";
            var sum = 100;

            var result = _currencyExchange.Exchange(from, to, sum);
            Console.WriteLine("from: {0} to: {1} sum: {2:F} result: {3:F}", from, to, sum, result);

            Console.ReadKey();


        }
    }
}
