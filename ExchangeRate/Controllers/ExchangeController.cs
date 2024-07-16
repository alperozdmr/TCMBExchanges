using Business.Concrete;
using Business.Helpers;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Controllers
{
    public class ExchangeController : Controller
    {
        ExchangeManager exchangeManager = new ExchangeManager(new EfExchangeDal());
        public IActionResult Index()
        {
            var result = exchangeManager.GetAll();
            return View(result);
        }
       
        public async Task<IActionResult> Update()
        {
            var rates = await XMLReader.GetExchanges();
            foreach (var rate in rates)
            {
                var result = exchangeManager.GetAll().Find(x => x.Isim == rate.Isim);
                var tempResult = new ExchangeRates
                {
                    Id = result.Id,
                    BanknoteBuying = rate.BanknoteBuying,
                    BanknoteSelling = rate.BanknoteSelling,
                    CurrencyCode = rate.CurrencyCode,
                    CurrencyName = rate.CurrencyName,
                    ForexBuying = rate.ForexBuying,
                    ForexSelling = rate.ForexSelling,
                    Isim = rate.Isim,
                    Unit = rate.Unit,
                };
                exchangeManager.UpdateExchange(tempResult);
            }
            return RedirectToAction("Index", "Exchange");
        }
    }
}
