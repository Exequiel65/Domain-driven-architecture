using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Domain.Interface;
using PackGroup.Ecommerce.Infrastructura.Interface;

namespace Packgroup.Ecommerce.Domain.Core
{
    public class UserDomain : IUsersDomain
    {
        private readonly IUsers _usersRepository;
        public UserDomain(IUsers users)
        {
            _usersRepository = users;
        }
        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
