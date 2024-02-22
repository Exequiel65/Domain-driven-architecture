using Packgroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackGroup.Ecommerce.Infrastructura.Interface
{
    public interface IUsers
    {
        Users Authenticate(string userName, string password);
    }
}
