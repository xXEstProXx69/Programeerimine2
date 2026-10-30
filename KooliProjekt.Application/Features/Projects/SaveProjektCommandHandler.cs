using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Projects;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    public class SaveProjektCommandHandler: IRequestHandler<SaveProjektCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProjektCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(
            SaveProjektCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var projektExists = await _dbContext.Projekts
                .AnyAsync(p => p.Id == request.Id, cancellationToken);

            if (!projektExists)
            {
                return result.AddPropertyError(
                    "Id",
                    "Cannot find project with ID " + request.Id);
            }

            Projekt projekt;

            if (request.Id == 0)
            {
                projekt = new Projekt();
                _dbContext.Projekts.Add(projekt);
            }
            else
            {
                projekt = await _dbContext.Projekts
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (projekt == null)
                {
                    return result.AddPropertyError(
                        "Id",
                        "Cannot find project with ID " + request.Id);
                }
            }

            projekt.Name = request.Title;
            projekt.CustomerId = request.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}