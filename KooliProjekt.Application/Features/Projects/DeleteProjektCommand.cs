using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class DeleteProjektCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
