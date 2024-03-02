using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Application.Validator;
using Packgroup.Ecommerce.Transversal.Common;
using System;

namespace Packgroup.Ecommerce.Aplication.UseCases.Users
{
    public class UserApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;
        private readonly UserDTOValidator _validator;
        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<UserApplication> logger, UserDTOValidator validations)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _validator = validations;
        }
        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _validator.Validate(new UserDTO { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _unitOfWork.Users.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
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
