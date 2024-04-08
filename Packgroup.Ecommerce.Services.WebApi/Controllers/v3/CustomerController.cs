using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Commands.CreateCustomerCommand;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Commands.DeleteCustomerCommand;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Commands.UpdateCustomerCommand;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetAllCustomerQuery;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetAllWithPaginationQuery;
using Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetCustomerQuery;
namespace Packgroup.Ecommerce.Services.WebApi.Controllers.v3
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("3.0")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] CreateCustomerCommand command)
        {
            if (command == null) return BadRequest();

            var response = await _mediator.Send(command);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand command)
        {
            var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = command.CustomerId });

            if (customerDto.Data == null) return BadRequest();

            if (command == null) return BadRequest();

            var response = await _mediator.Send(command);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete/{customerID}")]
        public async Task<IActionResult> Delete([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = customerId});

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get/{customerId}")]
        public async Task<IActionResult> Get([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId});

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllCustomerQuery());

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationCustomerQuery() { PageNumber = pageNumber, PageSize = pageSize});

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        #endregion
    }
}
