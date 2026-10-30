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

namespace KooliProjekt.Application.Features.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteCustomerCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Customers
                .Where(item => item.Id == request.Id)
                .ExecuteDeleteAsync();

            await _dbContext.Customers
                .Where(list => list.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
