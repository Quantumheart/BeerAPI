using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerAPI.Models
{
    public class Brewery
    {
        [Key]
        public int BreweryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BreweryName { get; set; }
        [MaxLength(50)]
        public string MasterBrewer { get; set; }
        [MaxLength(30)]
        public string Address { get; set; }
        [MaxLength(2)]
        public string StateAbbr { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(9)]
        public string ZipCode { get; set; }
        public List<Beer> Beers { get; set; }
        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class DtoBrewery
    {
        public int BreweryId { get; set; }
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