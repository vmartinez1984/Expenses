using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class CategoryDtoIn
    {
        [StringLength(20)]
        public string Name { get; set; }

    }

    public class CategoryDto : CategoryDtoIn
    {
        public int Id { get; set; }
    }
}
