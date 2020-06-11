using System;
using System.Collections.Generic;

namespace BeerAPI.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string BreweryName { get; set; }
        public string MasterBrewer { get; set; }
        public string Address { get; set; }
        public string StateAbbr { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public List<Brewery> Beers { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}