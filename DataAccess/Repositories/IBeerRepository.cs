using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models.Entities;

namespace DataAccess.Repositories
{
    public interface IBeerRepository
    {
        Task<List<Beer>> GetAllBeers();
    }
}