﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Delete
{
    public record DeleteCustomerCommandRequest(int Id) : IRequest<DeleteCustomerCommandResponse>;
}
