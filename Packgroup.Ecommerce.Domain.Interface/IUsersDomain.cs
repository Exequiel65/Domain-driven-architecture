using Packgroup.Ecommerce.Domain.Entity;

namespace Packgroup.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
