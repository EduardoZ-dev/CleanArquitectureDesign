using Application.Dtos;

namespace Application.UseCases.Customers.CreateCustomer
{
    public class CreateCustomerResponse
    {
        public CustomerDto Customer { get; set; } = default!;

    }
}
