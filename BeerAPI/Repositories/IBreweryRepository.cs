using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Models;

namespace BeerAPI.Repositories
{
    public interface IBreweryRepository
    {
        public Task<List<Brewery>> GetBreweries();
        public Task<Brewery> GetBrewery(int id);
        public Task<bool> AddBrewery(Brewery brewery);
        public Task<bool> UpdateBrewery(Brewery brewery);
        public Task<bool> DeleteBrewery(Brewery brewery);
    }
}