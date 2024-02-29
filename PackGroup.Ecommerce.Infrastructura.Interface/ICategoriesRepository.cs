using Packgroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackGroup.Ecommerce.Infrastructura.Interface
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAllAsync();
    }
}
