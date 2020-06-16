using System.Collections.Generic;
using BeerAPI.Models;

namespace BeerAPI.Data
{
    public interface IBeerRepo
    {
        IEnumerable<Beer> GetAllBeers();
    }
}