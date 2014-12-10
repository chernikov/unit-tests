using FileRate;
using NetRate;
using Rate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{

    public class CurrencyExchange
    {
        private IRate _rate;

        public CurrencyExchange(IRate rate)
        {
            _rate = rate;
        }

        public double Exchange(string from, string to, double sum)
        {
            if (sum == 0)
            {
                return 0;
            }
            if (sum < 0)
            {
                throw new ArgumentException("Sum must be positive");
            }
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentNullException("Currency is not valid");
            }
            if (from == to)
            {
                return sum;
            }
            var rate =  _rate.GetRate(from, to);
            return sum * rate;
        }
    }
}
