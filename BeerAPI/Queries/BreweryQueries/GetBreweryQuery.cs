using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models;
using BeerAPI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Queries.BreweryQueries
{
    public class GetBreweryQuery : IRequest<Brewery>
    {
        public int Id { get; set; }

        public class GetBreweryQueryHandler : IRequest<GetBreweryQuery>
        {
            private readonly IApplicationDbContext _context;

            public GetBreweryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Brewery> Handle(GetBreweryQuery query,
                CancellationToken cancellationToken)
            {
                var brewery = await _context.Breweries.FirstOrDefaultAsync(d => d.Id == query.Id).ConfigureAwait(false);
                return brewery ?? null;
            }
        }
    }
}