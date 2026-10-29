
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Customers.All;
using KooliProjekt.Application.Features.Customers.Singular;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(
            [FromQuery] ListCustomerQuery query)
        {
            var result = await _mediator.Send(query);
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _mediator.Send(
                new CustomerQuery { Id = id });

            return Result(result);
        }
    }
}
