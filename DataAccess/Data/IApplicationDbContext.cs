using System.Threading.Tasks;
using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        Task<int> SaveChangesAsync();
    }
}