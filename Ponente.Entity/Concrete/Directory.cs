using Ponente.Core.Entities;

namespace Ponente.Entity.Concrete
{
    public class Directory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
