
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tasks
{
    public class TaskQueryHandler : IRequestHandler<TaskQuery, KooliProjekt.Application.Data.Task>
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.Task> Handle(
            TaskQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(
                    t => t.Id == request.Id,
                    cancellationToken);
        }
    }
}
