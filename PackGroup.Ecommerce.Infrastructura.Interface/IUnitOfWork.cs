using System;

namespace PackGroup.Ecommerce.Infrastructura.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IUsers Users { get; }
    }
}
