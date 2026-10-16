using System.Threading.Tasks;
using KooliProjekt.Application.Features.Projects;
using KooliProjekt.Application.Features.Projects.All;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var query = new ListProjektQuery();
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid project ID.");
            }

            var query = new ProjektQuery { id = id };
            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
    }
}
