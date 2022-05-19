using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Inputs
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
}