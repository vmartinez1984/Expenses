using System.ComponentModel.DataAnnotations;

namespace Expenses.Dtos.Inputs{
    public class CategoryDtoIn
    {
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Name{get; set;}
    }
}