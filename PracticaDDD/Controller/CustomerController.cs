using Application.UseCases.Customers.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaDDD.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpGet("getCustomer")]
        public async Task<IActionResult> GetCustomer([FromQuery] GetAllCustomerRequest request, CancellationToken ct)
        {
            var response = await mediator.Send(request, ct);
            return Ok(response);
        }

    }
}
