using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class MontsWithoutInterestDetails
    {
        [Key]
        public int Id { get; set; }
                
        
        [Required]
        [Display(Name = "Cantidad")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Numero de pago")]
        public int ExpenseNumber { get; set; }

        [Required]
        [ForeignKey(nameof(MontsWithoutInterest))]
        public int MontsWithoutInterestId { get; set; }
        public virtual MontsWithoutInterest MontsWithoutInterest { get; set; }

        [Required]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
