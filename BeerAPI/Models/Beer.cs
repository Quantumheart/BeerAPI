using System;

namespace BeerAPI.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public string BeerClass { get; set; }
        public string BeerDescription { get; set; }
        public decimal Abv { get; set; }
        public Brewery Brewer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}