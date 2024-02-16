using System.Data;

namespace Packgroup.Ecommerce.Transversal.Common
{
    public interface IConectionFactory
    {
        IDbConnection GetConnection { get; }

    }
}
