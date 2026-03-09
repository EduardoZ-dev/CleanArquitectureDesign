using Application.Base;
using MediatR;


namespace Application.UseCases.Customers.GetCustomer
{
    public class GetAllCustomerRequest : IRequest<ResponseBase<GetAllCustomerResponse>>
    {
        public bool? Activo { get; set; }
        public string? Nombre { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
