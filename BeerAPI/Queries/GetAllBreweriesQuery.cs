using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Queries
{
    public class GetAllBreweriesQuery : IRequest<IEnumerable<Brewery>>
    {
        public class GetAllBreweriesQueryHandler : IRequestHandler<GetAllBreweriesQuery, IEnumerable<Brewery>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllBreweriesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Brewery>> Handle(GetAllBreweriesQuery query,
                CancellationToken cancellationToken)
            {
                var productList = await _context.Breweries.ToListAsync();
                if (productList == null)
                {
                    return null;
                }

                return productList.AsReadOnly();
            }
        }
    }
}