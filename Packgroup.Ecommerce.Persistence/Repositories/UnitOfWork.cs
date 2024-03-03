using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Persistence.Contexts;

namespace Packgroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }

        public IUsers Users { get; }
        public ICategoriesRepository Categories { get; }

        public IDiscountRepository Discounts { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ICustomerRepository customerRepository, IUsers users, ICategoriesRepository categories, IDiscountRepository discounts, ApplicationDbContext context)
        {
            CustomerRepository = customerRepository;
            Users = users;
            Categories = categories;
            Discounts = discounts;
            _context = context;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
