using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Worklog.All
{
    public class ListWorklogQuery : IRequest<IEnumerable<WorkLog>>
    {
    }
}