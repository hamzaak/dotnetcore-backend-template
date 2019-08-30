using Ponente.Business.Abstract;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Ponente.Business.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IDirectoryService _directoryService;
        private readonly ICurrencyService _currencyService;

        public AccountService(
            IAccountRepository accountRepository,
            IDirectoryService directoryService,
            ICurrencyService currencyService)
        {
            _accountRepository = accountRepository;
            _directoryService = directoryService;
            _currencyService = currencyService;
        }

        public Account Add(Account account)
        {
            account = _accountRepository.Add(account);
            account = Get(account.Id);
            return account;
        }

        public void Delete(int id)
        {
            var account = Get(id);
            _accountRepository.Delete(account);
        }

        public Account Get(int id)
        {
            var account = _accountRepository.Get(x => x.Id == id);
            account.Currency = _currencyService.Get(account.CurrencyId);
            account.Directory = _directoryService.Get(account.DirectoryId);
            return account;
        }

        public List<Account> GetAll()
        {
            var accounts = _accountRepository.GetList().OrderBy(x=>x.Name).ToList();
            foreach(var account in accounts)
            {
                account.Currency = _currencyService.Get(account.CurrencyId);
                account.Directory = _directoryService.Get(account.DirectoryId);
            }
            return accounts;
        }

        public Account Update(Account account)
        {
            account = _accountRepository.Update(account);
            account = Get(account.Id);
            return account;
        }
    }
}
