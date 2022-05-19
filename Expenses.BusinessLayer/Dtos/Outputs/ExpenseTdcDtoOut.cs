using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class ExpenseTdcDtoOut
    {
       [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name= "Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cantidad")]
        public int Amount { get; set; }
        
        [Display(Name = "Meses sin intereses")]
        public int? MonthsWithoutInterest { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}