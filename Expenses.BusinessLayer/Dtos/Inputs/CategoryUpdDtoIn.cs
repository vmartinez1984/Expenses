using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class CategoryUpdDtoIn : CategoryDtoIn
    {
        [Required]
        public int Id { get; set; }
    }
}
