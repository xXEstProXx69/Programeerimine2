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

namespace KooliProjekt.Application.Features.Projects
{
    public class DeleteProjektCommandHandler : IRequestHandler<DeleteProjektCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteProjektCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteProjektCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Projekts
                .Where(item => item.Id == request.Id)
                .ExecuteDeleteAsync();

            await _dbContext.Projekts
                .Where(list => list.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
