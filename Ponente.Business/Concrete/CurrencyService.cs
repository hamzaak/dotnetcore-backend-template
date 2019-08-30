using Ponente.Business.Abstract;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Business.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public Currency Add(Currency currency)
        {
            return _currencyRepository.Add(currency);
        }

        public void Delete(int id)
        {
            var currency = Get(id);
            _currencyRepository.Delete(currency);
        }

        public Currency Get(int id)
        {
            return _currencyRepository.Get(x => x.Id == id);
        }

        public List<Currency> GetAll()
        {
            return _currencyRepository.GetList();
        }

        public Currency Update(Currency currency)
        {
            return _currencyRepository.Update(currency);
        }
    }
}
