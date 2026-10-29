using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Customers.All
{
    public class ListCustomerQuery : IRequest<IEnumerable<Customer>>
    {
    }
}