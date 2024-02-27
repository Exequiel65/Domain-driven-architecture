using PackGroup.Ecommerce.Infrastructura.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packgroup.Ecommerce.Infraestructura.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }

        public IUsers Users { get; }

        public UnitOfWork( ICustomerRepository customerRepository, IUsers users )
        {
            CustomerRepository = customerRepository;
            Users = users;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize( this );
        }
    }
}
