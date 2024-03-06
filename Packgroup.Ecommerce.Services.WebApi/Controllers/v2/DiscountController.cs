using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Asp.Versioning;

namespace Packgroup.Ecommerce.Services.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountApplication _discountApplication;

        public DiscountController(IDiscountApplication discountApplication)
        {
            _discountApplication = discountApplication;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] DiscountDto discountDto)
        {
            if (discountDto == null) return BadRequest();

            var response = await _discountApplication.Create(discountDto);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] DiscountDto discountDto)
        {
            var discountDtoExist = await _discountApplication.Get(id);
            if (discountDtoExist.Data == null) return NotFound();

            if (discountDto == null) return BadRequest();

            var response = await _discountApplication.Update(discountDto);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var response = await _discountApplication.Delete(id);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            var response = await _discountApplication.Get(id);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _discountApplication.GetAll();

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAllPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await _discountApplication.GetAllWithPaginationAsync(pageNumber, pageSize);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

    }
}
