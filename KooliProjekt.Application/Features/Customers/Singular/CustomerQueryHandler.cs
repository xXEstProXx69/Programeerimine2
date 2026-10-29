using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers.Singular
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, Customer>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        }
    }
}