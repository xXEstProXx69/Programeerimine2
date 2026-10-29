using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Worklog
{
    public class WorklogQuery : IRequest<WorkLog>
    {
        public int Id { get; set; }
    }
}