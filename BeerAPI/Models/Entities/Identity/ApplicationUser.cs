using System.Collections.Generic;

namespace BeerAPI.Models.Entities.Identity
{
    public class ApplicationUser 
    {
        public List<Beer> FavoriteBeers { get; set; }
    }
}