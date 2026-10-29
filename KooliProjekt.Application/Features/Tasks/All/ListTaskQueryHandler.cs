using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

using TaskEntity = KooliProjekt.Application.Data.Task;

namespace KooliProjekt.Application.Features.Tasks.All
{
    public class ListTaskQueryHandler : IRequestHandler<ListTaskQuery, IEnumerable<TaskEntity>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskEntity>> Handle(ListTaskQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Tasks.ToListAsync(cancellationToken);
        }
    }
}