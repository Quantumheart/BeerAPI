using System.Collections.Generic;

namespace BeerAPI.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public List<Brewery> Beers { get; set; }

    }
}