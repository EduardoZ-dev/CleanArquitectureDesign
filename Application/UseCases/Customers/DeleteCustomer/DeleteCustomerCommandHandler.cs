using Application.Base;
using Domain.Base.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseBase<bool>>
    {
        private readonly IRepositoryGeneric<Customer> _repo;

        public DeleteCustomerCommandHandler(IRepositoryGeneric<Customer> repo) 
        {
            _repo = repo;
        }

        public async Task<ResponseBase<bool>> Handle(
            DeleteCustomerCommand request,
            CancellationToken cancellationToken
            )
        {
            try
            {
                var customer = await _repo.Find(request.Id);

                if(customer == null)
                {
                    return new ResponseBase<bool>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = false,
                        Message = "Cliente no encontrado"
                    };
                }

                _repo.Delete(customer);

                return new ResponseBase<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true,
                    Message = "Cliente eliminado correctamente"
                };

            }catch(Exception ex)
            {
                return new ResponseBase<bool>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = false,
                    Message = $"Ocurrio un error al intentar eliminar el Cliente: {ex.Message}"
                };
            }
        }

    }
}
