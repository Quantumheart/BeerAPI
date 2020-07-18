using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Queries.BreweryQueries
{
    public class GetBreweryQuery : IRequest<Brewery>
    {
        public int Id { get; set; }

        public class GetBreweryQueryHandler : IRequestHandler<GetBreweryQuery, Brewery>
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