using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Customers
{
    public class DeleteCustomerCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
