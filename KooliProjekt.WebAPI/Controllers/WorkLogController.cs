using KooliProjekt.Application.Features.Worklog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkLogController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public WorkLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkLogs(
            [FromQuery] ListWorklogQuery query)
        {
            var result = await _mediator.Send(query);
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLog(int id)
        {
            var result = await _mediator.Send(new WorklogQuery { Id = id });
            return Result(result);
        }
        [HttpPost("save")]
        public async Task<IActionResult> SaveWorkLog(SaveLogCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkLog(int id)
        {
            var result = await _mediator.Send(
                new DeleteLogCommand { Id = id });
            return Result(result);
        }
    }
}