using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Models;
using BeerAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brewery>().ToTable("Breweries");
            var brewery = new Brewery()
            {
                Id = 1,
                BreweryName = "Prairie Artisan Ales",
                CreatedBy = "Bob Vance",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Bob Vance",
                ModifiedDate = DateTime.Now
            };
            modelBuilder.Entity<Brewery>().HasData(brewery);
            modelBuilder.Entity<Beer>().ToTable("Beers").HasOne(d => d.Brewer);
            modelBuilder.Entity<Beer>().HasData( new Beer()
            {
                Id=1,
                BreweryId = brewery.Id,
                BeerName = "Prairie Bomb!",
                Abv = new decimal(14.00),
                CreatedBy = "Bob Vance",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Bob Vance",
                ModifiedDate = DateTime.Now
            });
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            var guid = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = guid,
                Email = "bob@gmail.com",
                UserName = "bob@gmail.com",
            });
            
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("User Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("Role Claims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("User Claims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("User Tokens");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("User Logins");
        }
    }
}