
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers.All
{
    public class ListCustomerQueryHandler
        : IRequestHandler<ListCustomerQuery, OperationResult<PagedResult<CustomerListDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CustomerListDto>>> Handle(
            ListCustomerQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Customers
                .AsNoTracking()
               .Select(c => new CustomerListDto
{
    Id = c.Id,
    CustomerName = c.CustomerName
});

            var result = await query.GetPagedAsync(
                request.Page,
                request.PageSize);

            return new OperationResult<PagedResult<CustomerListDto>>(result);
        }
    }
}
