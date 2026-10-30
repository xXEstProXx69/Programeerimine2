using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Worklog
{
    public class DeleteLogCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
