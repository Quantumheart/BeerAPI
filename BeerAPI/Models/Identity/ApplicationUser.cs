using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BeerAPI.Models.Identity
{
    public class ApplicationUser 
    {
        public List<Beer> FavoriteBeers { get; set; }
    }
}