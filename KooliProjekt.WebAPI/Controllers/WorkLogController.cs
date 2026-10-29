using KooliProjekt.Application.Features.Worklog.All;
using KooliProjekt.Application.Features.Worklog.Singular;
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
    }
}