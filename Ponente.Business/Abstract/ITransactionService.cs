using Ponente.Entity.Concrete;
using Ponente.Entity.DTO;
using System.Collections.Generic;

namespace Ponente.Business.Abstract
{
    public interface ITransactionService
    {
        Transaction Get(string id);
        TransactionResponseDTO GetAll(TransactionRequestDTO dto);
        List<TransactionSumByAccountDTO> GetSumsByAccount();
        List<TransactionSumByDateDTO> GetSumsByDate();
        List<TransactionSumByDateDTO> GetTransactionReport(TransactionRequestDTO dto);
        List<TransactionAccountsReportDTO> GetAccountsReport();

        void Transfer(TransactionTransferDTO dto);
        Transaction Add(Transaction transaction);
        Transaction Update(Transaction transaction);
        void Delete(string id);
    }
}
