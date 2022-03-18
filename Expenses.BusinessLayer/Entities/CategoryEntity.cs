using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Entities
{
    public class CategoryEntity : BaseAEntity
    {
        [Required]
        public string Name { get; set; }
    }
}