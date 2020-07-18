using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerController : Controller
    {
        private readonly IBeerRepository _repository;

        public BeerController(IBeerRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await _repository.GetAllBeers();
            return Ok(beers);
        }
    }
}