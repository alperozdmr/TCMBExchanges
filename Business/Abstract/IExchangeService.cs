using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExchangeService
    {
        void AddNewExchanges(ExchangeRates exchangeRates);
        void DeleteExchangeId(int Id);
        void UpdateExchange(ExchangeRates exchangeRates);
        List<ExchangeRates> GetAll();
        List<ExchangeRates> GetExchangeById(int id);
    }
}
