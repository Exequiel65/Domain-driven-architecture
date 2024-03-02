using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Aplication.Interface.UserCases
{
    public interface ICustomerApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomerDTO customer);
        Response<bool> Update(CustomerDTO customer);
        Response<bool> Delete(string customerId);
        Response<CustomerDTO> Get(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Metodos Asincronicos

        Task<Response<bool>> InsertAsync(CustomerDTO customer);
        Task<Response<bool>> UpdateAsync(CustomerDTO customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
