using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Features.Customers.Commands.Add;
using WebAPI.Features.Customers.Commands.Update;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCustomersQueryRequest());
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddCustomerCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCustomerCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery]DeleteCustomerCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

    }
}
