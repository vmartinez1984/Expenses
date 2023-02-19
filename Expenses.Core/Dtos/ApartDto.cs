using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class ApartDto: ApartDtoIn
    {
        public int Id { get; set; }

    }

    public class ApartDtoIn
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public int SubcategoryId { get; set; }

        [Display(Name = "Subcategoria")]
        public string SubcategoryName { get; set; }

        [Display(Name = "$")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }
    }
}