using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Beer>> GetAllBeers()
        {
            return await _context.Beers.ToListAsync();
        }
    }
}