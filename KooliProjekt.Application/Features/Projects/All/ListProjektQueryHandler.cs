
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects.All
{
    public class ListProjektQueryHandler
        : IRequestHandler<ListProjektQuery, IEnumerable<Projekt>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjektQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Projekt>> Handle(
            ListProjektQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Projekts
                .ToListAsync(cancellationToken);
        }
    }
}
