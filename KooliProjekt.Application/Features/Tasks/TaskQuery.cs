using MediatR;

using TaskEntity = KooliProjekt.Application.Data.Task;

namespace KooliProjekt.Application.Features.Tasks
{
    public class TaskQuery : IRequest<TaskEntity>
    {
        public int Id { get; set; }
    }
}