using MediatR;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record class CreateUserTokenCommand : IRequest<Response<UserDTO>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
