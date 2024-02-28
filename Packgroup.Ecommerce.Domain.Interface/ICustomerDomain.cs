using Packgroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Packgroup.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region Métodos Síncronos

        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        #endregion

        #region Metodos Asincronicos

        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();

        #endregion
    }
}
