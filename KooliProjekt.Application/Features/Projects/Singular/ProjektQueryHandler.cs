using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects.Singular
{
    public class ProjektQueryHandler : IRequestHandler<ProjektQuery, Projekt>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjektQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Projekt> Handle(
            ProjektQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Projekts
                .FirstOrDefaultAsync(
                    p => p.Id == request.id,
                    cancellationToken);
        }
    }
}