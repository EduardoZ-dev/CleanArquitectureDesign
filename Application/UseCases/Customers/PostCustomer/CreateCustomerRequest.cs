using Application.Base;
using MediatR;


namespace Application.UseCases.Customers.CreateCustomer
{
    public class CreateCustomerRequest : IRequest<ResponseBase<CreateCustomerResponse>>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; }


    }
}
