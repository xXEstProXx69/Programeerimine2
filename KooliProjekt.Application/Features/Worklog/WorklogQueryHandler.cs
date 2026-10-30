using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Worklog
{
    public class WorklogQueryHandler
        : IRequestHandler<WorklogQuery, OperationResult<WorkLogDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public WorklogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WorkLogDto>> Handle(
            WorklogQuery request,
            CancellationToken cancellationToken)
        {
            var workLog = await _dbContext.WorkLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    w => w.Id == request.Id,
                    cancellationToken);

            if (workLog == null)
            {
                return new OperationResult<WorkLogDto>()
                    .AddError("Work log not found.");
            }

            var dto = new WorkLogDto
            {
                Id = workLog.Id,
                Date = workLog.Date,
                Hours = workLog.Hours,
                Worker = workLog.Worker,
                Description = workLog.Description
            };

            return new OperationResult<WorkLogDto>(dto);
        }
    }
}