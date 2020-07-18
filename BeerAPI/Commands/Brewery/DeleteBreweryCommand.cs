using System;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Commands.Brewery
{
    public class DeleteBreweryCommand : IRequest<ICommandResult>
    {
        public int Id { get; set; }

        public DeleteBreweryCommand()
        {
        }

        public class DeleteBreweryCommandHandler : IRequestHandler<DeleteBreweryCommand, ICommandResult>
        {
            private IApplicationDbContext _context;
            public DeleteBreweryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            
            public async Task<ICommandResult> Handle(DeleteBreweryCommand command, CancellationToken token)
            {
                try
                {
                    var breweryToDelete = await _context.Breweries.FirstOrDefaultAsync(d => d.Id == command.Id);
                    if (breweryToDelete == null) return default;
                    _context.Breweries.Remove(breweryToDelete);
                    await _context.SaveChangesAsync();
                    var result = new CommandResult()
                    {
                        IsSuccess = true,
                        Result = null
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    return default;
                }

            }
        }

    }
}