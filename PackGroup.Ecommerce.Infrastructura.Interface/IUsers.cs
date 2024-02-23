using Packgroup.Ecommerce.Domain.Entity;

namespace PackGroup.Ecommerce.Infrastructura.Interface
{
    public interface IUsers
    {
        Users Authenticate(string userName, string password);
    }
}
