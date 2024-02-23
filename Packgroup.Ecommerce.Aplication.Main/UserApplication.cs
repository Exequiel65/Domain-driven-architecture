using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Transversal.Common;
using System;

namespace Packgroup.Ecommerce.Aplication.Main
{
    public class UserApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;
        public UserApplication(IUsersDomain usersDomain, IMapper mapper, IAppLogger<UserApplication> logger)
        {
            _mapper = mapper;
            _usersDomain = usersDomain;
            _logger = logger;
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
                _logger.LogInformation("Autenticación exitosa");
                return response;
            }
            catch (InvalidOperationException ex)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                _logger.LogWarning("Usuario no existe");
                _logger.LogWarning(ex.Message);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
