using System.ComponentModel.DataAnnotations;

namespace BeerAPI.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}