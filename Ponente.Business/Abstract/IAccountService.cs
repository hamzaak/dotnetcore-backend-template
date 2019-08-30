using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Business.Abstract
{
    public interface IAccountService
    {
        Account Get(int id);
        List<Account> GetAll();
        Account Add(Account account);
        Account Update(Account account);
        void Delete(int id);
    }
}
