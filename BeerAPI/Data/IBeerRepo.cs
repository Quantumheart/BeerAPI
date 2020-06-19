using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Models;

namespace BeerAPI.Data
{
    public interface IBeerRepo
    {
        Task<List<Beer>> GetAllBeers();
    }
}