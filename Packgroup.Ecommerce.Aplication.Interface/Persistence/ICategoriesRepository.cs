using Packgroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Aplication.Interface.Persistence
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categorie>> GetAllAsync();
    }
}
