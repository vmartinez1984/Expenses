using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class ExpenseTdc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
