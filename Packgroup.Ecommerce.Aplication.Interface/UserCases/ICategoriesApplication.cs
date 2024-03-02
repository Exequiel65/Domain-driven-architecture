using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Aplication.Interface.UserCases
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategorieDto>>> GetAll();
    }
}
