using System.Threading.Tasks;
using BeerAPI.Models;
using BeerAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        Task<int> SaveChangesAsync();
    }
}