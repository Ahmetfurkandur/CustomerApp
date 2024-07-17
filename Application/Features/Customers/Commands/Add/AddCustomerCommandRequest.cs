using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace WebAPI.Features.Customers.Commands.Add
{
    public record AddCustomerCommandRequest : IRequest<AddCustomerCommandResponse>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Role { get; init; }
        public string Company { get; init; }
        public ContactInfo ContactInfo { get; init; }
    }
}
