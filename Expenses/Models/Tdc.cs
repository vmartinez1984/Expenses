using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class Tdc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        public string BankName { get; set; }

        [Required]
        [Column("Decimal(5,2)")]
        public decimal InterestRate { get; set; }

        [Required]
        public DateTime DateCute { get; set; }
    }
}
