using Ponente.Business.Abstract;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;
using Ponente.Entity.DTO;
using Ponente.Entity.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Ponente.Business.Concrete
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository transactionRepository, IAccountService accountService)
        {
            _transactionRepository = transactionRepository;
            _accountService = accountService;
        }

        public Transaction Add(Transaction transaction)
        {
            return _transactionRepository.Add(transaction);
        }

        public void Delete(string id)
        {
            var transaction = Get(id);
            _transactionRepository.Delete(transaction);
        }

        public Transaction Get(string id)
        {
            return _transactionRepository.Get(x => x.Id == id);
        }

        public TransactionResponseDTO GetAll(TransactionRequestDTO dto)
        {
            var filteredItems = _transactionRepository.GetList()
                .Where(x => x.AccountId == dto.AccountId &&
                    x.Date >= dto.Date[0] && x.Date <= dto.Date[1] &&
                    x.Amount >= dto.Amount[0] && x.Amount <= dto.Amount[1] &&
                    (x.Type == dto.Type || dto.Type == TransactionType.All) &&
                    x.Description.Contains(dto.Description));
            var pagedItems = filteredItems
                .OrderByDescending(x => x.Date)
                .Skip((dto.CurrentPage - 1) * dto.PageSize)
                .Take(dto.PageSize);

            return new TransactionResponseDTO { Transactions = pagedItems.ToList(), Total = filteredItems.ToList().Count };
        }

        public List<TransactionSumByAccountDTO> GetSumsByAccount()
        {
            var transactions = _transactionRepository.GetList();
            foreach (var item in transactions)
            {
                item.Account = _accountService.Get(item.AccountId);
            }
            return transactions.GroupBy(x => x.AccountId)
                .Select(
                    g => new TransactionSumByAccountDTO
                    {
                        AccountId = g.Key,
                        Account = g.First().Account,
                        OriginalSum = g.Sum(s => s.Type == TransactionType.Income ? s.Amount : -1 * s.Amount),
                        Sum = g.Sum(s => s.Type == TransactionType.Income ? s.Amount : -1 * s.Amount) * g.First().Account.Currency.Value
                    })
                    .Where(x => x.Sum > 0)
                    .ToList();
        }

        public List<TransactionSumByDateDTO> GetSumsByDate()
        {
            var transactions = _transactionRepository.GetList();
            foreach (var item in transactions)
            {
                item.Account = _accountService.Get(item.AccountId);
            }
            var result = transactions.OrderBy(x => x.Date).GroupBy(x => x.Date)
                 .Select(
                     g => new TransactionSumByDateDTO
                     {
                         Date = g.First().Date,
                         Sum = g.Sum(t =>
                            t.Account.Type == AccountType.Income
                                ? (t.Type == TransactionType.Income ? t.Amount * t.Account.Currency.Value : -1 * t.Amount * t.Account.Currency.Value)
                                : (t.Type == TransactionType.Income ? -1 * t.Amount * t.Account.Currency.Value : t.Amount * t.Account.Currency.Value)),
                         Total = 0
                     })
                     .Where(x => x.Sum != 0)
                     .ToList();

            decimal total = 0;
            foreach (var item in result)
            {
                total += item.Sum;
                item.Total = total;
            }
            return result;
        }

        public List<TransactionSumByDateDTO> GetTransactionReport(TransactionRequestDTO dto)
        {
            var transactions = _transactionRepository.GetList().Where(x => x.Date >= dto.Date[0] && x.Date <= dto.Date[1]);
            foreach (var item in transactions)
            {
                item.Account = _accountService.Get(item.AccountId);
            }
            var result = transactions.OrderBy(x => x.Date).GroupBy(x => x.Date)
                 .Select(
                     g => new TransactionSumByDateDTO
                     {
                         Date = g.First().Date,
                         Sum = g.Sum(t =>
                            t.Account.Type == AccountType.Income
                                ? (t.Type == TransactionType.Income ? t.Amount * t.Account.Currency.Value : -1 * t.Amount * t.Account.Currency.Value)
                                : (t.Type == TransactionType.Income ? -1 * t.Amount * t.Account.Currency.Value : t.Amount * t.Account.Currency.Value)),
                         Total = 0
                     })
                     .Where(x => x.Sum != 0)
                     .ToList();

            decimal total = 0;
            foreach (var item in result)
            {
                total += item.Sum;
                item.Total = total;
            }
            return result;
        }

        public List<TransactionAccountsReportDTO> GetAccountsReport()
        {
            var transactions = _transactionRepository.GetList();
            foreach (var item in transactions)
            {
                item.Account = _accountService.Get(item.AccountId);
            }
            return transactions.GroupBy(x => x.AccountId)
                .Select(
                    g => new TransactionAccountsReportDTO
                    {
                        AccountId = g.Key,
                        Account = $"{g.First().Account.Directory.Name} > {g.First().Account.Name} ({g.First().Account.Currency.Name})",
                        Description = g.First().Account.Description,
                        Sum = g.Sum(s => s.Type == TransactionType.Income ? s.Amount : -1 * s.Amount)
                    })
                    .Where(x => x.Sum > 0)
                    .ToList();
        }

        public void Transfer(TransactionTransferDTO dto)
        {
            var fromAccount = _accountService.Get(dto.FromAccountId);
            var toAccount = _accountService.Get(dto.ToAccountId);

            var transactionFrom = new Transaction
            {
                AccountId = dto.FromAccountId,
                Amount = dto.Amount + dto.Commission,
                Type = TransactionType.Expense,
                Date = dto.Date,
                Description = dto.Description
            };

            var transactionTo = new Transaction
            {
                AccountId = dto.ToAccountId,
                Amount = dto.Amount * fromAccount.Currency.Value / toAccount.Currency.Value,
                Type = TransactionType.Income,
                Date = dto.Date,
                Description = dto.Description
            };

            Add(transactionFrom);
            Add(transactionTo);
        }

        public Transaction Update(Transaction transaction)
        {
            return _transactionRepository.Update(transaction);
        }
    }
}
