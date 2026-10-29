using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Customers.Singular
{
    public class CustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}