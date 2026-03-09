using Application.UseCases.Customers.GetCustomer;
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
























    }
}
