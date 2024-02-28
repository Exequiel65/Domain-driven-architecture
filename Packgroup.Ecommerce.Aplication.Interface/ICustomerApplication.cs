using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Aplication.Interface
{
    public interface ICustomerApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomersDTO customer);
        Response<bool> Update(CustomersDTO customer);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Metodos Asincronicos

        Task<Response<bool>> InsertAsync(CustomersDTO customer);
        Task<Response<bool>> UpdateAsync(CustomersDTO customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
