using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Commands.Brewery
{
    public class DeleteBreweryCommand : IRequest<int>
    {
        private int Id { get; set; }
        private IApplicationDbContext _context;

        public DeleteBreweryCommand(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteBreweryCommand command, CancellationToken token)
        {
            var breweryToDelete = await _context.Breweries.FirstOrDefaultAsync(d => d.Id == command.Id);
            if (breweryToDelete == null) return default;
            _context.Breweries.Remove(breweryToDelete);
            await _context.SaveChangesAsync();
            return breweryToDelete.Id;
        }
    }
}