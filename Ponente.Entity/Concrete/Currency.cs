using Ponente.Core.Entities;

namespace Ponente.Entity.Concrete
{
    public class Currency: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
