using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Entities
{
    public class BaseAEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}