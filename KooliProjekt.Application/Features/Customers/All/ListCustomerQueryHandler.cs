using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers.All
{
    public class ListCustomerQueryHandler : IRequestHandler<ListCustomerQuery, IEnumerable<Customer>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }
    }
}