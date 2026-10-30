using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Worklog
{
    public class DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteLogCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.WorkLogs
                .Where(item => item.Id == request.Id)
                .ExecuteDeleteAsync();

            await _dbContext.WorkLogs
                .Where(list => list.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
