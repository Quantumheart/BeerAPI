using System;
using System.Linq;
using DataAccess.Data;
using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestBeerAPI
{
    public class TestBreweryRepository
    {
        protected TestBreweryRepository(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var brewery1 = new Brewery()
                {
                    Id = 1, CreatedBy = "Bob Vance", BreweryName = "Prairie Artisan Ales",
                    MasterBrewer = "Bob Vance", City = "OKC", CreatedDate = DateTime.Now, 
                };

                context.Breweries.Add(brewery1);

                context.SaveChanges();
            }
        }

        [Fact]
        public void GetBreweries()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
                
            var breweries =  context.Breweries.ToList();
        }
    }
}