
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks(
            [FromQuery] ListTaskQuery query)
        {
            var result = await _mediator.Send(query);
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var result = await _mediator.Send(new TaskQuery { Id = id });
            return Result(result);
        }
        [HttpPost("save")]
        public async Task<IActionResult> SaveTask(SaveTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _mediator.Send(
                new DeleteTaskCommand { Id = id });
            return Result(result);
        }
    }
}
