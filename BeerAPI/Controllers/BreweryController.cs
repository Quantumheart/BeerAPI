using System.Threading.Tasks;
using AutoMapper;
using BeerAPI.Models;
using BeerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [ApiController]
    [Route("breweries")]
    public class BreweryController : Controller
    {
        private IBreweryRepository _breweryRepository;
        private IMapper _mapper;

        public BreweryController(IBreweryRepository breweryRepository, IMapper mapper)
        {
            _breweryRepository = breweryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetBreweries()
        {
            var breweries = await _breweryRepository.GetBreweries().ConfigureAwait(false);
            return Ok(breweries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrewery(int id)
        {
            var brewery = await _breweryRepository.GetBrewery(id);
            return Ok(brewery);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrewery([FromBody] DtoBrewery brewery)
        {
            var mapped = _mapper.Map<Brewery>(brewery);
            if (await _breweryRepository.AddBrewery(mapped).ConfigureAwait(false))
            {
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrewery([FromBody] DtoBrewery brewery)
        {
            var mapped = _mapper.Map<Brewery>(brewery);
            // refactor update method
            if (await _breweryRepository.UpdateBrewery(mapped).ConfigureAwait(false))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(int id)
        {
            var brewery = await _breweryRepository.GetBrewery(id).ConfigureAwait(false);
            if (await _breweryRepository.DeleteBrewery(brewery).ConfigureAwait(false))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}