using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Tasks
{
    public class TaskQuery : IRequest<KooliProjekt.Application.Data.Task>
    {
        public int Id { get; set; }
    }
}