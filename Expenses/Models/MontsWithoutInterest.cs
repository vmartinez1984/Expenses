using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class MontsWithoutInterest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Total de pagos")]
        public int ExpensesTotal { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}