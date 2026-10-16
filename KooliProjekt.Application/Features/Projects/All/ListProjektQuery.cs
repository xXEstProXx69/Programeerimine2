
using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects.All
{
    public class ListProjektQuery : IRequest<IEnumerable<Projekt>>
    {
    }
}
