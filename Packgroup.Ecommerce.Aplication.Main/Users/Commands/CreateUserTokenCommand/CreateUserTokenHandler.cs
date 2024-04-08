using AutoMapper;
using MediatR;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Users.Commands.CreateUserTokenCommand
{

    public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDTO>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDTO>();
          
            try
            {
                var user = await _unitOfWork.Users.Authenticate(request.UserName, request.Password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa";
                return response;
            }
            catch (InvalidOperationException ex)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            return response;
        }
    }
}
