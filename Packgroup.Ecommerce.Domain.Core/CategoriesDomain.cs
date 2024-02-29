using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Domain.Interface;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }
    }
}
