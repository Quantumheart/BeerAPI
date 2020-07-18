using System.Collections.Generic;

namespace DataAccess.Models.Entities.Identity
{
    public class ApplicationUser 
    {
        public List<Beer> FavoriteBeers { get; set; }
    }
}