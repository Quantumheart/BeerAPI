using System;
using BeerAPI.Data;
using BeerAPI.Models;
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
                    BreweryId = 1, CreatedBy = "Bob Vance", BreweryName = "Prairie Artisan Ales",
                    MasterBrewer = "Bob Vance", City = "OKC", CreatedDate = DateTime.Now, 
                };

                context.Breweries.Add(brewery1);

                context.SaveChanges();
            }
        }

        [Fact]
        public void Test1()
        {
        }
    }
}