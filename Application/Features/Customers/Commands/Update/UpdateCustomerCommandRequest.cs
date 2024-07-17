using MediatR;
using Domain.Entities;

namespace WebAPI.Features.Customers.Commands.Update
{
    public record UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Role { get; init; }
        public string Company { get; init; }
        public ContactInfo ContactInfo { get; init; }

    }
}
