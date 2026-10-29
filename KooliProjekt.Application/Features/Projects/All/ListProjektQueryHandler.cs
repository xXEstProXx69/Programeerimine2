using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects.All
{
    public class ListProjektQueryHandler
        : IRequestHandler<ListProjektQuery, OperationResult<PagedResult<ProjektListDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjektQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProjektListDto>>> Handle(
            ListProjektQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Projekts
                .AsNoTracking()
                .Select(p => new ProjektListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Start = p.Start,
                    Deadline = p.Deadline
                });

            var result = await query.GetPagedAsync(
                request.Page,
                request.PageSize);

            return new OperationResult<PagedResult<ProjektListDto>>(result);
        }
    }
}