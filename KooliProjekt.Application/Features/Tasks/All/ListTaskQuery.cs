using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

using TaskEntity = KooliProjekt.Application.Data.Task;

namespace KooliProjekt.Application.Features.Tasks.All
{
    public class ListTaskQuery : IRequest<IEnumerable<TaskEntity>>
    {
    }
}