using Moq;
using Rate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Test
{
    public class MockExchangeRate : Mock<IRate>
    {
        public MockExchangeRate()
        {

            this.Setup(p => p.GetRate("USD", "RUR")).Returns(49.6875);
            this.Setup(p => p.GetRate("USD", "UAH")).Returns(17);
            //this.Setup(p => p.GetRate(It.IsAny<string>(), It.IsAny<string>())).Returns(17);
        }
    }
}
