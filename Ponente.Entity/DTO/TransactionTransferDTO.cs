using System;
using System.Collections.Generic;
using System.Text;

namespace Ponente.Entity.DTO
{
    public class TransactionTransferDTO
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
        public string Description { get; set; }
    }
}
