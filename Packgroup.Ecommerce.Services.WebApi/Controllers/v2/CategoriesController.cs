using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Transversal.Common;
using Swashbuckle.AspNetCore.Annotations;
using Packgroup.Ecommerce.Aplication.DTO;

namespace Packgroup.Ecommerce.Services.WebApi.Controllers.v2
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [SwaggerTag("Get Categories of Producs")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesApplication _categoriesApplication;

        public CategoriesController(ICategoriesApplication categoriesApplication)
        {
            _categoriesApplication = categoriesApplication;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get Categories", Description = "This Endpoint will return all categories", OperationId = "GetAll", Tags = new string[] { "GetAll" })]
        [SwaggerResponse(200, "Listo of Categories", typeof(Response<IEnumerable<CategorieDto>>))]
        [SwaggerResponse(404, "Not Found Categories")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoriesApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
