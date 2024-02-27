using Packgroup.Ecommerce.Domain.Entity;

namespace PackGroup.Ecommerce.Infrastructura.Interface
{
    public interface IUsers : IGenericRepository<Users>
    {
        Users Authenticate(string userName, string password);
    }
}
