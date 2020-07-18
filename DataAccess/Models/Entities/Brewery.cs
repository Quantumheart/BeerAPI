using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Entities
{
    public class Brewery : BaseEntity
    {
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
        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}