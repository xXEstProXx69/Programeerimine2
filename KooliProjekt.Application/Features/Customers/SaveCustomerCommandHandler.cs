using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Customers;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers;


public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, OperationResult>
{
    private readonly ApplicationDbContext _dbContext;

    public SaveCustomerCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = new OperationResult();

        var userExists = await _dbContext.Customers
            .AnyAsync(user => user.Id == request.UserId);
        if (!userExists)
        {
            return result.AddPropertyError("UserId", "Cannot find user with ID " + request.UserId);
        }

        var customer = new Customer();

        if (request.Id == 0)
        {
            _dbContext.Add(customer);
        }
        else
        {
            customer = await _dbContext.FindAsync<Customer>(request.Id);
        }

        customer.CustomerName = request.Title;
        customer.Id = request.UserId;

        await _dbContext.SaveChangesAsync();

        return result;
    }
}
