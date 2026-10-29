using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects.Worklog.Singular
{
    public class WorklogQuery : IRequest<WorkLog>
    {
        public int Id { get; set; }
    }
}