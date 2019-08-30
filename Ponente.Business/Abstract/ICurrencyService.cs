using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Business.Abstract
{
    public interface ICurrencyService
    {
        Currency Get(int id);
        List<Currency> GetAll();
        Currency Add(Currency currency);
        Currency Update(Currency currency);
        void Delete(int id);
    }
}
