using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class ExpenseDtoOut
    {
        [Key]
        public int Id { get; set; }

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
        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }
}