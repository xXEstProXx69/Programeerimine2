using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Worklog
{
    public class WorklogQuery : IRequest<OperationResult<WorkLogDto>>
    {
        public int Id { get; set; }
    }
}