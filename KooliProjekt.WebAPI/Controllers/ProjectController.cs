
using KooliProjekt.Application.Features.Projects.All;
using KooliProjekt.Application.Features.Projects.Singular;
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
    }
}
