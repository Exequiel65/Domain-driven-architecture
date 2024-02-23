using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
