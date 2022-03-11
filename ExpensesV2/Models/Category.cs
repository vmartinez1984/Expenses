using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}