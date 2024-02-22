using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Transversal.Common;
using System;

namespace Packgroup.Ecommerce.Aplication.Main
{
    public class UserApplication: IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        public UserApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _mapper = mapper;
            _usersDomain = usersDomain;
        }
        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Párametros no pueden ser vacíos";
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa";
                return response;
            }
            catch (InvalidOperationException ex)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
