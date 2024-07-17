using Application.Dtos;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersQueryResponse>
    {
        
        readonly ICustomerRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();
            List<GetAllCustomersDto> deserializedCustomers = new List<GetAllCustomersDto>();

            foreach (var customer in customers) {
                deserializedCustomers.Add(new GetAllCustomersDto(){ 
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Role = customer.Role,
                    Company = customer.Company,
                    ContactInfo = JsonSerializer.Deserialize<ContactInfo>(customer.ContactInfo) 
                    });
            }

            return new(deserializedCustomers);
        }
    }
}
