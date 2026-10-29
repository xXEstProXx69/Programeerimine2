using KooliProjekt.Application.Features.Projects.Worklog.Singular;
using KooliProjekt.Application.Features.Worklog;
using KooliProjekt.Application.Features.Worklog.All;
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
        public async Task<IActionResult> GetWorkLogs()
        {
            var workLogs = await _mediator.Send(new ListWorklogQuery());
            return Ok(workLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLog(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var workLog = await _mediator.Send(new WorklogQuery { Id = id });

            if (workLog == null)
            {
                return NotFound();
            }

            return Ok(workLog);
        }
    }
}