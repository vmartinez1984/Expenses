using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class SubcategoryDtoIn 
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
               
        [Display(Name = "Cantidad")]
        [Range(0, 4000)]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }
    }

    public class SubcategoryDto: SubcategoryDtoIn
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }
    }
}