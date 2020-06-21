using System.Reflection;
using AutoMapper;
using BeerAPI.Data;
using BeerAPI.Helpers;
using BeerAPI.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeerAPI
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            /*services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();*/
            services.AddScoped<IBreweryRepository, BreweryRepository>();
            services.AddControllers();
        }
    }
}