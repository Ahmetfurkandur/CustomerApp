using MediatR;
using Application.Repositories;
using System.Text.Json;
using Domain.Entities;

namespace WebAPI.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {

        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var contactInfo = JsonSerializer.Serialize(request.ContactInfo);
            var customer = new Customer()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role,
                Company = request.Company,
                ContactInfo = contactInfo
            };

            await _repository.UpdateAsync(customer);
            return new();
        }
    }
}
