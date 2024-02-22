using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packgroup.Ecommerce.Aplication.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
