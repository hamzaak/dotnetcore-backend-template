using System.Collections.Generic;
using Ponente.Business.Abstract;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;

namespace Ponente.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User Get(string username, string password)
        {
            return _userRepository.Get(p => p.Username == username && p.Password == password);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetList();
        }
    }
}
