using Ponente.Core.Data.Ef;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;

namespace Ponente.Data.Concrete.Ef
{
    public class EfUserRepository : EfEntityRepository<User, PonenteDbContext>, IUserRepository { }
}
