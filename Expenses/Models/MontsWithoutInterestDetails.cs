using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class MontsWithoutInterestDetails
    {
        public MontsWithoutInterestDetails()
        {

        }
         
        public MontsWithoutInterestDetails(int id, int amount, int expenseNumber, int montsWithoutInterestId)
        {
            this.Id = id;
            this.Amount = amount;
            this.ExpenseNumber = expenseNumber;
            this.MontsWithoutInterestId = montsWithoutInterestId;
            this.IsActive = true;
            this.DateStart= DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
                
        
        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [Range(1, 2000)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Numero de pago")]
        [Range(1,36)]
        public int ExpenseNumber { get; set; }

        [Required]
        [ForeignKey(nameof(MontsWithoutInterest))]
        [Display(Name = "Compra")]
        public int MontsWithoutInterestId { get; set; }

        [Display(Name = "Compra")]
        public virtual MontsWithoutInterest MontsWithoutInterest { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
