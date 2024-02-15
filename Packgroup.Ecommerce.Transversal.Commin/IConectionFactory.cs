using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Packgroup.Ecommerce.Transversal.Common
{
    public interface IConectionFactory
    {
        IDbConnection GetConnection { get; }

    }
}
