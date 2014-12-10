using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Test
{

    [TestFixture]
    public class CurrencyExchangeTests
    {
        [Test]
        public void Exchange_NoMoney_ZeroResult()
        {
            var currencyExchange = GetExchange();

            var result = currencyExchange.Exchange("", "", 0);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Exchange_EmptyCurrencyName_ExpectException()
        {
            var currencyExchange = GetExchange();
            Assert.Catch(typeof(ArgumentNullException),
                delegate
                {
                    currencyExchange.Exchange("", "", 1000);
                });
        }

        [Test]
        public void Exchange_SameCurrency_ReturnSameSum()
        {
            var currencyExchange = GetExchange();

            var result = currencyExchange.Exchange("USD", "USD", 1000);

            Assert.AreEqual(1000, result);
        }

        [TestCase(1, 17)]
        [TestCase(2, 34)]
        public void Exchange_UsdToUah_CorrectExpectedResult(double usd, double expected)
        {
            var currencyExchange = GetExchange();

            var result = currencyExchange.Exchange("USD", "UAH", usd);

            Assert.AreEqual(expected, result);
        }

        [TestCase("USD", "RUR", 1, 49.6875)]
        public void Exchange_SomeCurrencyToOtherCurrency_CorrectExpectedResult(string from, string to, double sum, double expected)
        {
            var currencyExchange = GetExchange();

            var result = currencyExchange.Exchange(from, to, sum);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Exchange_NegativeSum_AgrumentException()
        {
            var currencyExchange = GetExchange();

            Assert.Catch(typeof(ArgumentException),
                delegate
                {
                    currencyExchange.Exchange("UAH", "USD", -1);
                });
        }

        [TestCase(1, 17)]
        public void Exchange_UsdToUah_RaiseGetRate(double usd, double expected)
        {
            var mock = new MockExchangeRate();

            var rate = mock.Object;
            var currencyExchange = new CurrencyExchange(rate);

            var result = currencyExchange.Exchange("USD", "UAH", usd);

            mock.Verify(p => p.GetRate(It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.AreEqual(expected, result);
        }


        private static CurrencyExchange GetExchange()
        {
            var rate = new MockExchangeRate().Object;
            var currencyExchange = new CurrencyExchange(rate);
            return currencyExchange;
        }

    }
}
