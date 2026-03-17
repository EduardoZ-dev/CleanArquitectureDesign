

namespace Application.UseCases.Customers.PutCustomer
{
    public class PutCustomerRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
