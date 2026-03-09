using Application.Base;
using Application.Dtos;
using Domain.Base.Interfaces;
using Domain.Contracts.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.UseCases.Customers.GetCustomer
{
    public class GetAllCustomerQuery :
        IRequestHandler<GetAllCustomerRequest, ResponseBase<GetAllCustomerResponse>>
    {

        private readonly IRepositoryGeneric<Customer> _repo;

        public GetAllCustomerQuery(IRepositoryGeneric<Customer> repo)
        {
            _repo = repo;
        }


        public async Task<ResponseBase<GetAllCustomerResponse>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _repo.FindBy();

                if (request.Activo.HasValue)
                    query = query.Where(x => x.Activo == request.Activo.Value);

                if (!string.IsNullOrWhiteSpace(request.Nombre))
                {
                    var nombre = request.Nombre.Trim();
                    query = query.Where(x => x.Nombre.Contains(nombre));
                }

                query = query.OrderBy(x => x.Nombre);

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;

                var totalRecords = await query.CountAsync(cancellationToken);

                var result = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                var customers = result.Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Email = x.Email,
                    Activo = x.Activo
                }).ToList();

                return new ResponseBase<GetAllCustomerResponse>
                {
                    Data = new GetAllCustomerResponse
                    {
                        Customers = customers,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalRecords = totalRecords,
                        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
                    },
                    StatusCode = HttpStatusCode.OK,
                    Message = "Consulta realizada correctamente."
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<GetAllCustomerResponse>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Message = $"Error obteniendo customers: {ex.Message}"
                };
            }
        }
    }
}
