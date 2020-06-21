using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models;
using MediatR;

namespace BeerAPI.Commands
{
    public class CreateBreweryCommand : IRequest<int>
    {
        public string BreweryName { get; set; }
        public string MasterBrewer { get; set; }
        public string Address { get; set; }
        public string StateAbbr { get; set; }
        public string ZipCode { get; set; }
        public List<Beer> Beers { get; set; }
        public string CreatedBy { get; set; }
        public class CreateBreweryCommandHandler : IRequestHandler<CreateBreweryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBreweryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBreweryCommand command, CancellationToken cancellationToken)
            {
                var brewery = new Brewery();
                brewery.BreweryName = command.BreweryName;
                brewery.MasterBrewer = command.MasterBrewer ;
                brewery.Address = command.Address;
                brewery.StateAbbr = command.StateAbbr;
                brewery.ZipCode = command.ZipCode;
                brewery.Beers = command.Beers;
                
                _context.Breweries.Add(brewery);
                await _context.SaveChangesAsync();
                return brewery.Id;
            }
        }
    }
}