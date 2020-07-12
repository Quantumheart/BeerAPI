using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models;
using BeerAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Repositories
{
    public class BreweryRepository : IBreweryRepository
    {
        private ApplicationDbContext _context;

        public BreweryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Brewery>> GetBreweries()
        {
            return await _context.Breweries.ToListAsync();
        }

        public async Task<Brewery> GetBrewery(int id)
        {
            return await _context.Breweries.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> AddBrewery(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBrewery(Brewery brewery)
        {
            brewery.ModifiedDate = DateTime.Now;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBrewery(Brewery brewery)
        {
            _context.Breweries.Remove(brewery);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}