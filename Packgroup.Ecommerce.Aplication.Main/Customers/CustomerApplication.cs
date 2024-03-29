﻿using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Domain.Entities;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Customers
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        public CustomerApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<CustomerApplication> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = _unitOfWork.CustomerRepository.Insert(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!";
            }
            return response;
        }
        public Response<bool> Update(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = _unitOfWork.CustomerRepository.Update(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!";
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            response.Data = _unitOfWork.CustomerRepository.Delete(customerId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Borrado Exitoso!!";
            }
            return response;
        }
        public Response<CustomerDTO> Get(string customerId)
        {
            var response = new Response<CustomerDTO>();

            var customer = _unitOfWork.CustomerRepository.Get(customerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!";
            }

            return response;
        }
        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();

            var listCustomers = _unitOfWork.CustomerRepository.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(listCustomers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!";
                _logger.LogInformation("Consulta Exitosa!!");
            }

            return response;
        }

        public ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();

            var count = _unitOfWork.CustomerRepository.Count();
            var customers = _unitOfWork.CustomerRepository.GetAllWithPagination(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            if (response.Data != null)
            {
                response.PageNumber = pageNumber;
                response.TotalPage = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta Paginada Exitosa!!";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> InsertAsync(CustomerDTO customerDto)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(customerDto);
            response.Data = await _unitOfWork.CustomerRepository.InsertAsync(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!";
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = await _unitOfWork.CustomerRepository.UpdateAsync(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!";
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();

            response.Data = await _unitOfWork.CustomerRepository.DeleteAsync(customerId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Borrado Exitoso!!";
            }

            return response;
        }
        public async Task<Response<CustomerDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDTO>();

            var customer = await _unitOfWork.CustomerRepository.GetAsync(customerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!";
            }

            return response;
        }
        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();

            var listCustomers = await _unitOfWork.CustomerRepository.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(listCustomers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!";
            }

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();

            var count = await _unitOfWork.CustomerRepository.CountAsync();
            var customers = await _unitOfWork.CustomerRepository.GetAllWithPaginationAsync(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            if (response.Data != null)
            {
                response.PageNumber = pageNumber;
                response.TotalPage = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta Paginada Exitosa!!";

            }

            return response;
        }

        #endregion
    }
}
