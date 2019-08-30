using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Entity.DTO
{
    public class TransactionResponseDTO
    {
        public List<Transaction> Transactions { get; set; }
        public int Total { get; set; }
    }
}
