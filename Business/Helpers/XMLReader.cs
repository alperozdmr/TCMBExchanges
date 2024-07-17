using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Helpers
{
    public class XMLReader
    {
        public async static Task<List<ExchangeRates>> GetExchanges()
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var currencyData = await FetchCurrencyDataAsync(url);

            return currencyData.ToList();
        }
        private async static Task<List<ExchangeRates>> FetchCurrencyDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var xmlContent = await response.Content.ReadAsStringAsync();
                    return ParseCurrencyData(xmlContent);
                }
            }
            return null;
        }
        public static List<ExchangeRates> ParseCurrencyData(string xmlContent)
        {
            XDocument doc = XDocument.Parse(xmlContent);
            var currencies = doc.Descendants("Currency")
                                .Take(12)
                                .Select(c => new ExchangeRates
                                {
                                    CurrencyCode = c.Attribute("CurrencyCode")?.Value,
                                    Unit = (int?)c.Element("Unit") ?? 0,
                                    Isim = c.Element("Isim")?.Value,
                                    CurrencyName = c.Element("CurrencyName")?.Value,
                                    ForexBuying = (decimal?)c.Element("ForexBuying") ?? 0,
                                    ForexSelling = (decimal?)c.Element("ForexSelling") ?? 0,
                                    BanknoteBuying = (decimal?)c.Element("BanknoteBuying") ?? 0,
                                    BanknoteSelling = (decimal?)c.Element("BanknoteSelling") ?? 0,


                                }).ToList();

            return currencies;
        }
    }
}
