using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using Entities.Concrete;
using Business.Concrete;
using Business.Helpers;
using DataAccess.Concrete;

public class Program
{
    public async static Task Main(string[] args)
    {
        
        var currencyData = await XMLReader.GetExchanges();
        ExchangeManager exchangeManager = new ExchangeManager(new EfExchangeDal());

        //for(int i = 13; i <=24; i++) { 
        //    exchangeManager.DeleteExchangeId(i);    
        //}

        //if (currencyData != null)
        //{
        //    foreach (var currency in currencyData)
        //    {               
        //        exchangeManager.AddNewExchanges(currency);
        //        await Task.Delay(10000);
        //    }
        //}
    }

    
}