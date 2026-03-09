using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> FindBy();
        // luego: Add, Update, Delete si aplica
    }
}
