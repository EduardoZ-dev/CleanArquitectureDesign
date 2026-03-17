using Application.Mappers;
using Application.UseCases.Customers.CreateCustomer;
using Application.UseCases.Customers.GetCustomer;
using Application.UseCases.Customers.PutCustomer;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDDD.Controllers.v1
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpGet("getCustomer")]
        public async Task<IActionResult> GetCustomers() 
        {
            var response = await mediator.Send(new GetAllCustomerRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            var result = await mediator.Send(request);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut("PutCustomer/{id}")]
        public async Task<IActionResult> Update(Guid id, PutCustomerRequest body)
        {
            var command = CustomerMapper.ToUpdateCommand(id, body);

            var result = await mediator.Send(command);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = CustomerMapper.ToDeleteCommand(id);

            var result = await mediator.Send(command);

            return StatusCode((int)result.StatusCode, result);
        }



    }
}
