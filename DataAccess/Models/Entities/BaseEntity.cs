using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}