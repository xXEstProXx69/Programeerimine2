using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Worklog
{
    public class SaveLogCommandHandler : IRequestHandler<SaveLogCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveLogCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveLogCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var userExists = await _dbContext.WorkLogs
                .AnyAsync(user => user.Id == request.UserId);
            if (!userExists)
            {
                return result.AddPropertyError("UserId", "Cannot find user with ID " + request.UserId);
            }

            var log = new WorkLog();

            if (request.Id == 0)
            {
                _dbContext.Add(log);
            }
            else
            {
                log = await _dbContext.FindAsync<WorkLog>(request.Id);
            }

            log.Id = request.UserId;
            log.Description = request.Description;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
