using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual List<Subcategory> ListSubcategory { get; set; }
    }
}