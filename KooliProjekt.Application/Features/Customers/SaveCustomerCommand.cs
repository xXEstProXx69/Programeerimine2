using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Customers;

public class SaveCustomerCommand : IRequest<OperationResult>, ITransactional
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
}
