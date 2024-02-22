using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Services.WebApi.Helpers;
using Packgroup.Ecommerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Packgroup.Ecommerce.Services.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;
        public UserController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UsersDTO usersDTO)
        {
            var response = _usersApplication.Authenticate(usersDTO.UserName, usersDTO.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuilderToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }
            return BadRequest(response.Message);
        }

        private string BuilderToken(Response<UsersDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
