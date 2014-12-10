using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Common
{
    public interface IRate
    {
        double GetRate(string from, string to);
    }
}
