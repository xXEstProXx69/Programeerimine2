
using KooliProjekt.Application.Features.Projects;
using KooliProjekt.Application.Features.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetProjects(
            [FromQuery] ListProjektQuery query)
        {
            var result = await _mediator.Send(query);
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var query = new ProjektQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }
        [HttpPost("save")]
        public async Task<IActionResult> SaveProject(SaveProjektCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _mediator.Send(
                new DeleteProjektCommand { Id = id });
            return Result(result);
        }
    }
}
