using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Domain.Interface;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Packgroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Métodos Síncronicos
        public bool Insert(Customers customer)
        {
            return _unitOfWork.CustomerRepository.Insert(customer);
        }

        public bool Update(Customers customer)
        {
            return _unitOfWork.CustomerRepository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return _unitOfWork.CustomerRepository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _unitOfWork.CustomerRepository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.CustomerRepository.GetAll();
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _unitOfWork.CustomerRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _unitOfWork.CustomerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.CustomerRepository.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _unitOfWork.CustomerRepository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }
        #endregion
    }
}
