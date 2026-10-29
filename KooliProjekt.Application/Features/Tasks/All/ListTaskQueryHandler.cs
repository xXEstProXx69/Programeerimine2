
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tasks.All
{
    public class ListTaskQueryHandler : IRequestHandler<ListTaskQuery, OperationResult<PagedResult<TaskListDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<TaskListDto>>> Handle(
            ListTaskQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Tasks
                .AsNoTracking()
                .Select(t => new TaskListDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Start = t.Start,
                    Worker = t.Worker,
                    IsCompleted = t.IsCompleted
                });

            var result = await query.GetPagedAsync(
                request.Page,
                request.PageSize);

            return new OperationResult<PagedResult<TaskListDto>>(result);
        }
    }
}
