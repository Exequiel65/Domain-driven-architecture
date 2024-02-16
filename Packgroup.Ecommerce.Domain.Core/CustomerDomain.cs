using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Domain.Interface;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Packgroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _repository;

        public CustomerDomain(ICustomerRepository repository)
        {
            _repository = repository;
        }

        #region Métodos Síncronicos
        public bool Insert(Customers customer)
        {
            return _repository.Insert(customer);
        }

        public bool Update(Customers customer)
        {
            return _repository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return _repository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _repository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _repository.GetAll();
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _repository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _repository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _repository.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _repository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        #endregion
    }
}
