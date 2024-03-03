using Packgroup.Ecommerce.Domain.Entities;

namespace Packgroup.Ecommerce.Aplication.Interface.Persistence
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<Discount> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken);
    }
}
