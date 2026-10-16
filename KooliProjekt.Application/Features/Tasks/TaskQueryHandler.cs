using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

using TaskEntity = KooliProjekt.Application.Data.Task;

namespace KooliProjekt.Application.Features.Tasks
{
    public class TaskQueryHandler : IRequestHandler<TaskQuery, TaskEntity>
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async global::System.Threading.Tasks.Task<TaskEntity> Handle(TaskQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(task => task.Id == request.id, cancellationToken);
        }
    }
}
