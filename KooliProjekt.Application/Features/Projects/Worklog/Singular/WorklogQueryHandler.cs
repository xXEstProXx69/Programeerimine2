using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects.Worklog.Singular
{
    public class WorklogQueryHandler : IRequestHandler<WorklogQuery, WorkLog>
    {
        private readonly ApplicationDbContext _dbContext;

        public WorklogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WorkLog> Handle(WorklogQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.WorkLogs
                .FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
        }
    }
}