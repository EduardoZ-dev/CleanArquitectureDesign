using Application.Base;
using Application.Dtos;
using Domain.Base.Interfaces;
using Domain.Entities;
using MediatR;
using System.Net;


namespace Application.UseCases.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerRequest, ResponseBase<CreateCustomerResponse>>
    {
        private readonly IRepositoryGeneric<Customer> _repo;


        public CreateCustomerCommandHandler(IRepositoryGeneric<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<ResponseBase<CreateCustomerResponse>> Handle(
           CreateCustomerRequest request,
           CancellationToken cancellationToken)
        {
            try
            {
                var customersWithSameEmail = await _repo.FindBy(x => x.Email == request.Email);

                if (customersWithSameEmail.Any())
                {
                    return new ResponseBase<CreateCustomerResponse>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "Ya existe un cliente con ese email"
                    };
                }

                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Nombre = request.Nombre,
                    Email = request.Email,
                    Activo = request.Active,
                    CreatedAt = DateTime.UtcNow
                };

                _repo.Add(customer);

                var customerDto = new CustomerDto
                {
                    Id = customer.Id,
                    Nombre = customer.Nombre,
                    Email = customer.Email,
                    Activo = customer.Activo
                };

                var response = new CreateCustomerResponse
                {
                    Customer = customerDto
                };

                return new ResponseBase<CreateCustomerResponse>
                {
                    StatusCode = HttpStatusCode.Created,
                    Data = response,
                    Message = "Cliente creado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<CreateCustomerResponse>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Message = $"Error Creando el cliente: {ex.Message}"
                };
            }
        }
    }
}
