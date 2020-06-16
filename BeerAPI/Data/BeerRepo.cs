using System.Collections.Generic;
using System.Linq;
using BeerAPI.Models;

namespace BeerAPI.Data
{
    public class BeerRepo : IBeerRepo
    {
        private readonly ApplicationDbContext _context;

        public BeerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }
    }
}