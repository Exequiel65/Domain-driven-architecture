using Packgroup.Ecommerce.Domain.Entity;

namespace Packgroup.Ecommerce.Aplication.Interface.Persistence
{
    public interface IUsers : IGenericRepository<User>
    {
        User Authenticate(string userName, string password);
    }
}
