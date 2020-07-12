using System.Threading.Tasks;
using BeerAPI.Commands.Brewery;
using BeerAPI.Models.FormModels;
using BeerAPI.Queries.BreweryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BeerAPI.Controllers
{
    [ApiController]
    [Route("breweries")]
    public class BreweryController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(request: new GetAllBreweriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrewery(int id)
        {
            return Ok(await Mediator.Send(new GetBreweryQuery() {Id = id}));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBrewery([FromBody] AddOrUpdateBreweryForm form)
        {
            var command = new CreateBreweryCommand(form, ModelState);
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(int id)
        {
            var command = new DeleteBreweryCommand() {Id = id};
            return Ok(await Mediator.Send(command));
        }
    }
}