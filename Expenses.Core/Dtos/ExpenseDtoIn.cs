using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Expenses.Core.Dtos
{
    public class ExpenseDtoIn
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [Range(1, 5000)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Subcategoria")]
        public int SubcategoryId { get; set; }


        [Required]
        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }
    }

    public class ExpenseDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }
        
        [Display(Name = "Presupuesto")]
        [DataType(DataType.Currency)]
        public int Budget { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Subcategoria")]
        public string SubcategoryName { get; set; }

        [Display(Name = "Subcategoria")]
        public int SubcategoryId { get; set; }

        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime? DateRegister { get; set; } = DateTime.Now;
    }
}