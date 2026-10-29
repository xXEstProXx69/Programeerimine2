using System.Threading.Tasks;
using KooliProjekt.Application.Features.Tasks;
using KooliProjekt.Application.Features.Tasks.All;
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
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _mediator.Send(new ListTaskQuery());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var task = await _mediator.Send(new TaskQuery { Id = id });

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}