using System.Threading.Tasks;
using AutoMapper;
using BeerAPI.Models;
using BeerAPI.Queries;
using BeerAPI.Repositories;
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
    }
}