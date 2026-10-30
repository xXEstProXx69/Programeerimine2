using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Worklog
{
    public class ListWorklogQueryHandler
        : IRequestHandler<ListWorklogQuery, OperationResult<PagedResult<WorkLogListDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorklogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WorkLogListDto>>> Handle(
            ListWorklogQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.WorkLogs
                .AsNoTracking()
                .Select(w => new WorkLogListDto
                {
                    Id = w.Id,
                    Date = w.Date,
                    Hours = w.Hours,
                    Worker = w.Worker
                });

            var result = await query.GetPagedAsync(
                request.Page,
                request.PageSize);

            return new OperationResult<PagedResult<WorkLogListDto>>(result);
        }
    }
}