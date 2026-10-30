using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    public class ProjektQueryHandler
        : IRequestHandler<ProjektQuery, OperationResult<ProjektDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjektQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProjektDto>> Handle(
            ProjektQuery request,
            CancellationToken cancellationToken)
        {
            var projekt = await _dbContext.Projekts
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    p => p.Id == request.Id,
                    cancellationToken);

            if (projekt == null)
            {
                return new OperationResult<ProjektDto>()
                    .AddError("Project not found.");
            }

            var dto = new ProjektDto
            {
                Id = projekt.Id,
                Name = projekt.Name,
                Start = projekt.Start,
                Deadline = projekt.Deadline,
                Budget = projekt.Budget,
                HourlyRate = projekt.HourlyRate,
                Team = projekt.Team
            };

            return new OperationResult<ProjektDto>(dto);
        }
    }
}