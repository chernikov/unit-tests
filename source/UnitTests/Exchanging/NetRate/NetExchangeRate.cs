using Rate.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetRate
{
    public class NetExchangeRate : IRate
    {

        private Connector _connector;


        public NetExchangeRate()
        {
            _connector = new Connector();
        }


        public double GetRate(string from, string to)
        {
            try
            {
                var response = _connector.GetResource("https://www.liqpay.com/exchanges/exchanges.cgi", RequestMethodType.Get, null, 100000);
                XmlDocument xm = new XmlDocument();
                xm.LoadXml(response);
                var value = xm["rates"][from][to].InnerText;
                return double.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}