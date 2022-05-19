using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class ExpenseDtoOut
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Subcategoria")]
        public string SubcategoryName { get; set; }
        public int SubcategoryId { get; set; }

        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }
}