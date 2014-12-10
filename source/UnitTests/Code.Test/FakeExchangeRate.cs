using Rate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Test
{
    public class FakeExchangeRate : IRate
    {
        private class RateItem
        {
            public string From { get; set; }

            public string To { get; set; }

            public double Rate { get; set; }
        }

        private List<RateItem> _list;

        public FakeExchangeRate()
        {
            _list = new List<RateItem>();

            //_list.Add(new RateItem { From = "EUR", To = "RUR", Rate = 60.6250 });
            //_list.Add(new RateItem { From = "EUR", To = "UAH", Rate = 21.0000 });
            //_list.Add(new RateItem { From = "EUR", To = "USD", Rate = 1.1412 });

            //_list.Add(new RateItem { From = "RUR", To = "EUR", Rate = 0.0138 });
            //_list.Add(new RateItem { From = "RUR", To = "UAH", Rate = 0.3200 });
            //_list.Add(new RateItem { From = "RUR", To = "USD", Rate = 0.0171 });

            //_list.Add(new RateItem { From = "UAH", To = "RUR", Rate = 3.4483 });
            //_list.Add(new RateItem { From = "UAH", To = "EUR", Rate = 0.0515 });
            //_list.Add(new RateItem { From = "UAH", To = "USD", Rate = 0.0629 });

            _list.Add(new RateItem { From = "USD", To = "RUR", Rate = 49.6875 });
            _list.Add(new RateItem { From = "USD", To = "UAH", Rate = 17.0000 });
            _list.Add(new RateItem { From = "USD", To = "EUR", Rate = 0.7571 });
        }

        public double GetRate(string from, string to)
        {
            var rateItem = _list.FirstOrDefault(p => p.From == from && p.To == to);

            if (rateItem != null)
            {
                return rateItem.Rate;
            }
            throw new ArgumentException("Can't find currencies");
        }
    }
}
