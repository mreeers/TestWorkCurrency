using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TestApp.Models;

namespace TestApp.BLL
{
    public class CbrService
    {
        public Currency Get()
        {
            ServiceReferenceCbr.DailyInfoSoapClient client = new ServiceReferenceCbr.DailyInfoSoapClient();
            var data = client.AllDataInfoXML();
            Currency currency = new Currency();

            foreach (XmlElement el in data.SelectNodes("MainIndicatorsVR/Currency"))
            {
                foreach(XmlElement curs in el)
                {
                    if (curs.Name == "USD")
                        currency.USD = ConvertDecimalCustom(curs.InnerText);
                    else
                        currency.EUR = ConvertDecimalCustom(curs.InnerText);
                }
            }

            return currency;
        }

        private decimal ConvertDecimalCustom(string value)
        {
            decimal val = Convert.ToDecimal(value.Replace(".", ","));
            return val;
        }
    }
}
