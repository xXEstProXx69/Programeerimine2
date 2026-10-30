using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskEntity = KooliProjekt.Application.Data.Task;
namespace KooliProjekt.Application.Features.Tasks
{
    public class SaveTaskCommandHandler : IRequestHandler<SaveTaskCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveTaskCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var taskExists = await _dbContext.Tasks
                .AnyAsync(task => task.Id == request.Id);
            if (!taskExists)
            {
                return result.AddPropertyError("Id", "Cannot find task with ID " + request.Id);
            }

            var task = new TaskEntity();

            if (request.Id == 0)
            {
                _dbContext.Add(task);
            }
            else
            {
                task = await _dbContext.FindAsync<TaskEntity>(request.Id);
            }

            task.Title = request.Title;
            task.Id = request.UserId;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
