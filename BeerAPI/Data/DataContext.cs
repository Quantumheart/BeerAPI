using BeerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=BeerDB.db;");
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().ToTable("Beers");
            modelBuilder.Entity<Brewery>().ToTable("Breweries");
        }
    }
}