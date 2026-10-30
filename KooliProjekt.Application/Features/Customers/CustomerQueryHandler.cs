using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers
{
    public class CustomerQueryHandler
        : IRequestHandler<CustomerQuery, OperationResult<CustomerDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CustomerDto>> Handle(
            CustomerQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (customer == null)
            {
                return new OperationResult<CustomerDto>()
                    .AddError("Customer not found.");
            }

            var dto = new CustomerDto
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName
            };

            return new OperationResult<CustomerDto>(dto);
        }
    }
}