using Rate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRate
{
    public class DbExchangeRate : IRate
    {
        private RateContext _db;

        public DbExchangeRate()
        {
            _db = new RateContext();
        }

        public double GetRate(string from, string to)
        {
            try
            {
                var entity = _db.DbRateItems.FirstOrDefault(p => p.From == from && p.To == to);
                if (entity != null)
                {
                    return entity.Rate;
                }
                throw new Exception("Rates not found");
            }
            catch
            {
                throw;
            }
        }
    }
}
