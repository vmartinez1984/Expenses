using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Entities
{
    public class CategoryEntity : BaseAEntity
    {
        [Required]
        public string Name { get; set; }
    }
}