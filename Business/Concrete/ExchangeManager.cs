using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExchangeManager : IExchangeService
    {
        IExchangeDal _exchangeDal;
        public ExchangeManager(IExchangeDal exchangeDal)
        {
            _exchangeDal = exchangeDal;
        }
        public void AddNewExchanges(ExchangeRates exchangeRates)
        {
           _exchangeDal.Add(exchangeRates);
        }

        public void DeleteExchangeId(int Id)
        {
            var variable = _exchangeDal.Get(e => e.Id == Id);
            _exchangeDal.Delete(variable);
        }

        public List<ExchangeRates> GetAll()
        {
            return _exchangeDal.GetAll();   
        }

        public List<ExchangeRates> GetExchangeById(int id)
        {
            return _exchangeDal.GetAll().Where(e => e.Id == id).ToList();    
        }

        public void UpdateExchange(ExchangeRates exchangeRates)
        {
            _exchangeDal.Update(exchangeRates); 
        }
    }
}
