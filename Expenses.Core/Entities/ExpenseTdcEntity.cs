using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Entities
{
    public class ExpenseTdcEntity
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]        
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]        
        public int Amount { get; set; }
                
        public int? MonthsWithoutInterest { get; set; }

        [Required]
        [DataType(DataType.Date)]        
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}