
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class ProjektQuery : IRequest<Projekt>
    {
        public int id { get; set; }
    }
}
