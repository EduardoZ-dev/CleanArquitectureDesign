using Application.UseCases.Customers.DeleteCustomer;
using Application.UseCases.Customers.PutCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class CustomerMapper
    {
        public static PutCustomerCommand ToUpdateCommand(Guid id, PutCustomerRequest dto)
        {
            return new PutCustomerCommand
            {
                Id = id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Activo = dto.Activo,
            };
        }
        public static DeleteCustomerCommand ToDeleteCommand(Guid id)
        {
            return new DeleteCustomerCommand
            {
                Id = id
            };
        }
    }
}
