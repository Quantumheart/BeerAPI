using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Data
{
    public class BeerRepo : IBeerRepo
    {
        private readonly ApplicationDbContext _context;

        public BeerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Beer>> GetAllBeers()
        {
            return await _context.Beers.ToListAsync();
        }
    }
}