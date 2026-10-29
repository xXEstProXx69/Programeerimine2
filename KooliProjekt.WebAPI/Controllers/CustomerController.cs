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
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _mediator.Send(new ListCustomerQuery());
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var customer = await _mediator.Send(new CustomerQuery { Id = id });

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}