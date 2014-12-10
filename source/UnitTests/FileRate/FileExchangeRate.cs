using Rate.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileRate
{
    public class FileExchangeRate : IRate
    {
        private string _filename = "rate.xml";

        public double GetRate(string from, string to)
        {
            try
            {
                using (var sr = new StreamReader(_filename))
                {
                    var response = sr.ReadToEnd();
                    XmlDocument xm = new XmlDocument();
                    xm.LoadXml(response);
                    var value = xm["rates"][from][to].InnerText;
                    return double.Parse(value, CultureInfo.InvariantCulture);
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}
