
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tasks
{
    public class TaskQueryHandler : IRequestHandler<TaskQuery, OperationResult<TaskDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<TaskDto>> Handle(
            TaskQuery request,
            CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    t => t.Id == request.Id,
                    cancellationToken);

            if (task == null)
            {
                return new OperationResult<TaskDto>()
                    .AddError("Task not found.");
            }

            var dto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Start = task.Start,
                EstimatedHours = task.EstimatedHours,
                Worker = task.Worker,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                FixedPrice = task.FixedPrice,
                ProjektId = task.ProjektId
            };

            return new OperationResult<TaskDto>(dto);
        }
    }
}
