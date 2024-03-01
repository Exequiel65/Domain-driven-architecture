﻿using PackGroup.Ecommerce.Infrastructura.Interface;

namespace Packgroup.Ecommerce.Infraestructura.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }

        public IUsers Users { get; }
        public ICategoriesRepository Categories { get; }

        public UnitOfWork( ICustomerRepository customerRepository, IUsers users, ICategoriesRepository categories )
        {
            CustomerRepository = customerRepository;
            Users = users;
            Categories = categories;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize( this );
        }
    }
}