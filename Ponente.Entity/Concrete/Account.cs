using Ponente.Core.Entities;
using Ponente.Entity.Enums;

namespace Ponente.Entity.Concrete
{
    public class Account: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public int CurrencyId { get; set; }
        public int DirectoryId { get; set; }
        public string Description { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Directory Directory { get; set; }
    }
}
