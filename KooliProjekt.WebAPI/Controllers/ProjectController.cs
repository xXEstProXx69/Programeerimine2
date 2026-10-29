using System.Threading.Tasks;
using KooliProjekt.Application.Features.Projects;
using KooliProjekt.Application.Features.Projects.All;
using KooliProjekt.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _mediator.Send(new ListProjektQuery());
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var project = await _mediator.Send(new ProjektQuery { id = id });

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
    }
}