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

namespace KooliProjekt.Application.Features.Tasks
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Tasks
                .Where(item => item.Id == request.Id)
                .ExecuteDeleteAsync();

            await _dbContext.Tasks
                .Where(list => list.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
