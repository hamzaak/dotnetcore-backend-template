using System;

namespace Ponente.Entity.DTO
{
    public class TransactionSumByDateDTO
    {
        public decimal Sum { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
