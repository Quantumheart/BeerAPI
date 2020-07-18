using System.Collections.Generic;
using DataAccess.Models.Entities;

namespace BeerAPI.Models.FormModels
{
    public class AddOrUpdateBreweryForm
    {
        public int Id { get; set; }
        public string BreweryName { get; set; }
        public string MasterBrewer { get; set; }
        public string Address { get; set; }
        public string StateAbbr { get; set; }
        public string ZipCode { get; set; }
        public List<Beer> Beers { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}