using Application.Base;
using Application.Dtos;
using MediatR;


namespace Application.UseCases.Customers.PutCustomer
{
    public class PutCustomerCommand : IRequest<ResponseBase<CustomerDto>>
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; } = default!;

        public string Email { get; set; } = default!;

        public bool Activo { get; set; }
    }
}
