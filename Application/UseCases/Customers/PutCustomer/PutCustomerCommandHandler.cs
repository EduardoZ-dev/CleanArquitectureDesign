

using Application.Base;
using Application.Dtos;
using Domain.Base.Interfaces;
using Domain.Entities;
using MediatR;
using System.Net;

namespace Application.UseCases.Customers.PutCustomer
{
    public class PutCustomerCommandHandler : IRequestHandler<PutCustomerCommand, ResponseBase<CustomerDto>>
    {
        private readonly IRepositoryGeneric<Customer> _repo;

        public PutCustomerCommandHandler(IRepositoryGeneric<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<ResponseBase<CustomerDto>> Handle(
            PutCustomerCommand request,CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _repo.Find(request.Id);

                if (customer == null)
                {
                    return new ResponseBase<CustomerDto>
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        Message = "Cliente no encontrado"
                    };
                }

                var emailExist = await _repo.FindBy(x => x.Email == request.Email && x.Id != request.Id);

                if (emailExist.Any())
                {
                    return new ResponseBase<CustomerDto>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ya existe un cliente con ese email"
                    };
                }

                customer.Nombre = request.Nombre;
                customer.Email = request.Email;
                customer.Activo = request.Activo;

                _repo.Update(customer);

                var dto = new CustomerDto
                {
                    Id = customer.Id,
                    Nombre = customer.Nombre,
                    Email = customer.Email,
                    Activo = customer.Activo
                };

                return new ResponseBase<CustomerDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = dto,
                    Message = "Cliente actualizado correctamente"
                };

            }catch (Exception ex)
            {
                return new ResponseBase<CustomerDto>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error actualizando cliente: {ex.Message}"
                };
            }
        }
    }
}
