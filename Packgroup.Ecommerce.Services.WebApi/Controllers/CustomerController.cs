using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface;

namespace Packgroup.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region Metodos Sincronos

        [HttpPost("create")]
        public IActionResult Insert([FromBody]CustomersDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Insert(customerDTO);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Update(customerDTO);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete/{customerId}")]
        public IActionResult Delete([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Delete(customerId);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get/{customerId}")]
        public IActionResult Get([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Get(customerId);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        #endregion

        #region Metodos Asíncronos

        [HttpPost("insert-a")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.InsertAsync(customerDTO);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("update-a")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.UpdateAsync(customerDTO);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete-a/{customerID}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string customerId)
        {
           
            var response = await _customerApplication.DeleteAsync(customerId);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-a/{customerId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.GetAsync(customerId);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getAll-a")]
        public async Task<IActionResult> GetAllAsync([FromRoute] string customerId)
        {
            var response = await _customerApplication.GetAllAsync();

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        #endregion
    }
}
