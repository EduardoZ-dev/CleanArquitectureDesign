using Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }
}
