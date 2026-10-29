using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects.Singular
{
    public class ProjektQuery : IRequest<Projekt>
    {
        public int id { get; set; }
    }
}