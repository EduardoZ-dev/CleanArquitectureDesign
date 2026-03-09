using Application.Dtos;

namespace Application.UseCases.Customers.GetCustomer
{
    public class GetAllCustomerResponse
    {
        public List<CustomerDto> Customers { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
