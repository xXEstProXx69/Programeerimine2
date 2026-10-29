using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Worklog.All
{
    public class ListWorklogQueryHandler : IRequestHandler<ListWorklogQuery, IEnumerable<WorkLog>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorklogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkLog>> Handle(ListWorklogQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.WorkLogs.ToListAsync(cancellationToken);
        }
    }
}