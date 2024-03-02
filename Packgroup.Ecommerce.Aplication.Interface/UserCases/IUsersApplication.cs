using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.Interface.UserCases
{
    public interface IUsersApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
    }
}
