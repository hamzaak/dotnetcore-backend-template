using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Business.Abstract
{
    public interface IUserService
    {
        User Get(string username, string password);
        List<User> GetAll();
        void Add(User user);
    }
}
