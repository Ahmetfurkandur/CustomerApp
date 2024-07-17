using MediatR;
using System.Text.Json;
using Domain.Entities;
using Application.Repositories;

namespace WebAPI.Features.Customers.Commands.Add
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
    {
        readonly ICustomerRepository _repository;

        public AddCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var contactInfo = JsonSerializer.Serialize(request.ContactInfo);

            var customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role,
                Company = request.Company,
                ContactInfo = contactInfo
            };

            await _repository.AddAsync(customer);
            return new();
        }
    }
}
