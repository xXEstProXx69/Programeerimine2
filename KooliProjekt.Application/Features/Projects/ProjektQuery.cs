using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class ProjektQuery : IRequest<OperationResult<ProjektDto>>
    {
        public int Id { get; set; }
    }
}