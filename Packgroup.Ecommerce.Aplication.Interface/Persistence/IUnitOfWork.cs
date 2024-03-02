using System;

namespace Packgroup.Ecommerce.Aplication.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IUsers Users { get; }

        ICategoriesRepository Categories { get; }
    }
}
