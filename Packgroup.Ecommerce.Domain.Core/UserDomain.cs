using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Domain.Interface;
using PackGroup.Ecommerce.Infrastructura.Interface;

namespace Packgroup.Ecommerce.Domain.Core
{
    public class UserDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }
    }
}
