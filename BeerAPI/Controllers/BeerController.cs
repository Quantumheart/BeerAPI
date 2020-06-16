using System;
using System.Collections.Generic;
using BeerAPI.Data;
using BeerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerController : Controller
    {
        private readonly IBeerRepo _repository;

        public BeerController(IBeerRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult GetAllBeers()
        {
            var beers = _repository.GetAllBeers();
            return Ok(beers);
        }
    }
}