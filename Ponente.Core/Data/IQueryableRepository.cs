using Ponente.Core.Entities;
using System.Linq;

namespace Ponente.Core.Data
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
