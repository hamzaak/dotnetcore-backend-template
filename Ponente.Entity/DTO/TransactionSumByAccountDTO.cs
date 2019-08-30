using Ponente.Entity.Concrete;

namespace Ponente.Entity.DTO
{
    public class TransactionSumByAccountDTO
    {
        public decimal Sum { get; set; }
        public decimal OriginalSum { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
