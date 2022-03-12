using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Entities
{
    public class BaseAEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}