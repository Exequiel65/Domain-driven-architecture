using System;
using FluentValidation;
using Packgroup.Ecommerce.Aplication.DTO;

namespace Packgroup.Ecommerce.Application.Validator
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator() 
        {
            RuleFor(user => user.UserName)
                .NotNull()
                .NotEmpty();

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty();

        }
    }
}
